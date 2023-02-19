using System.Globalization;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Reader.Pages
{
    /// <summary>
    /// Interaction logic for ReadBook.xaml
    /// </summary>
    public partial class ReadBook : Page
    {
        private SpeechSynthesizer? synthsizer;

        public ReadBook()
        {
            InitializeComponent();

            this.synthsizer = null;
        }

        private void InitializeEnabledState()
        {
            this.btnsay.IsEnabled = true;
            this.btnpause.IsEnabled = false;
            this.btnstop.IsEnabled = true;
            this.btnplayselection.IsEnabled = false;
        }

        private void InitializeSynthsizer()
        {
            this.synthsizer = new SpeechSynthesizer();
            this.synthsizer.StateChanged += Synthsizer_StateChanged;
            this.synthsizer.SpeakCompleted += Synthsizer_SpeakCompleted;
            this.synthsizer.SpeakProgress += Synthsizer_SpeakProgress;
            this.synthsizer.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("fr-fr"));
        }

        private void Synthsizer_StateChanged(object? sender, StateChangedEventArgs e)
        {
            switch (e.State)
            {
                case SynthesizerState.Paused:
                    if (this.synthsizer != null)
                    {
                        this.synthsizer.Pause();
                    }
                    break;
            }
        }

        private void Synthsizer_SpeakCompleted(object? sender, SpeakCompletedEventArgs e)
        {
            if (this.synthsizer != null)
            {
                this.synthsizer.Dispose();
                this.synthsizer = null;
            }

            this.btnpause.Content = "⏸︎ Pause";
            this.btnsay.IsEnabled = true;
            this.Livre.IsInactiveSelectionHighlightEnabled = false;

            if (this.Livre.SelectedText.Length > 0)
                this.btnplayselection.IsEnabled = true;
            else
                this.btnplayselection.IsEnabled = false;
        }

        private void Synthsizer_SpeakProgress(object? sender, SpeakProgressEventArgs e)
        {

            if (btnplayselection.IsEnabled == false)
            {
                this.Livre.Focus();
                this.Livre.Select(e.CharacterPosition, e.Text.Length);
            }
            else
            {
                this.Livre.Focus();
                this.Livre.Select(this.Livre.SelectionStart, this.Livre.SelectionLength);
            }
        }

        private void Btnsay_Click(object sender, RoutedEventArgs e)
        {
            if (synthsizer != null)
            {
                synthsizer.Dispose();
            }

            if (Livre.Text.ToString().Trim().Length == 0)
            {
                MessageBox.Show("Sélectionnez du texte");
                return;
            }

            InitializeSynthsizer();

            if (synthsizer != null)
            {
                synthsizer.SpeakAsync(this.Livre.Text);
            }

            this.btnpause.IsEnabled = true;
            this.btnplayselection.IsEnabled = false;
        }

        private void Btnpause_Click(object sender, RoutedEventArgs e)
        {
            if (btnpause.Content.ToString() == "⏸︎ Pause")
            {
                if (this.synthsizer != null)
                {
                    this.btnsay.IsEnabled = false;
                    this.synthsizer.Pause();
                    this.btnpause.Content = "▶ Resume";
                }
            }
            else if (btnpause.Content.ToString() == "▶ Resume")
            {
                if (this.synthsizer != null)
                {
                    this.btnsay.IsEnabled = true;
                    this.synthsizer.Resume();
                    this.btnpause.Content = "⏸︎ Pause";
                }
            }
        }

        private void Btnplayselection_Click(object sender, RoutedEventArgs e)
        {
            if (this.Livre.SelectionLength > 0)
            {
                PlaySelectedText(this.Livre.SelectedText.ToString());
            }
        }

        private void PlaySelectedText(string selectedTxt)
        {
            if (synthsizer != null)
            {
                synthsizer.Dispose();
                synthsizer = null;
            }
            InitializeSynthsizer();
            this.synthsizer.SpeakAsync(selectedTxt);
        }

        private void Btnstop_Click(object sender, RoutedEventArgs e)
        {

            this.btnpause.Content = "⏸︎ Pause";
            this.btnpause.IsEnabled = false;
            this.btnsay.IsEnabled = true;
            this.Livre.IsInactiveSelectionHighlightEnabled = false;
            this.btnplayselection.IsEnabled = false;
            this.Livre.SelectionLength = 0;
            this.Livre.SelectionStart = 0;

            if (this.synthsizer != null)
            {
                this.synthsizer.Dispose();
                this.synthsizer = null;
            }
        }

        private void LivrePreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.synthsizer == null)
            {
                if (this.Livre.SelectedText.Length > 0)
                {
                    btnplayselection.IsEnabled = true;
                }
                else
                {
                    btnplayselection.IsEnabled = false;
                }
            }
            else
            {
                btnplayselection.IsEnabled = false;
            }
        }
    }
}