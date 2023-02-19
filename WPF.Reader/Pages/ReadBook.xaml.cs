using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.Reader.Pages
{
    /// <summary>
    /// Interaction logic for ReadBook.xaml
    /// </summary>
    public partial class ReadBook : Page
    {
        SpeechSynthesizer synth;
        public bool IsPauseValue { get; set; } = false;
        public bool IsFirstTimePlayed { get; set; } = true;
        public ReadBook()
        {
            InitializeComponent();
            btnStop.IsEnabled = false;
        }

        private void PauseOrResume(object sender, RoutedEventArgs e)
        {
            if (IsFirstTimePlayed)
            {
                synth = new SpeechSynthesizer();
                synth.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("fr-fr"));
                synth.SpeakAsync((string)btnplayorresume.CommandParameter);
                IsFirstTimePlayed = false;
                IsPauseValue = !IsPauseValue;
                btnplayorresume.Content = "⏸︎ Pause";
                btnplayorresume.Background = new SolidColorBrush(Color.FromArgb(255, 255, 64, 102));
                btnStop.IsEnabled = true;
                return;
            }
            if (IsPauseValue)
            {
                synth.Pause();
                IsPauseValue = !IsPauseValue;
                btnplayorresume.Content = "▶ Play";
                btnplayorresume.Background = new SolidColorBrush(Color.FromArgb(255, 127, 255, 0));
            }
            else
            {
                synth.Resume();
                IsPauseValue = !IsPauseValue;
                btnplayorresume.Content = "⏸︎ Pause";
                btnplayorresume.Background = new SolidColorBrush(Color.FromArgb(255, 255, 64, 102));
            }
        }

        private void PlaySelection_Click(object sender, RoutedEventArgs e)
        {
            if (Livre.SelectionLength > 0)
            {
                PlaySelectedText(Livre.SelectedText.ToString());
            }
        }

        private void PlaySelectedText(string selectedTxt)
        {
            if (synth != null)
            {
                synth.Dispose();
            }
            synth = new SpeechSynthesizer();
            synth.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("fr-fr"));
            btnStop.IsEnabled = true;
            synth.SpeakAsync(selectedTxt);
        }
        private void Stop(object sender, RoutedEventArgs e)
        {
            if (synth != null)
            {
                synth.Dispose();
            }
            btnStop.IsEnabled = false;
            IsFirstTimePlayed = true;
            IsPauseValue = !IsPauseValue;
            btnplayorresume.Content = "▶ Play";
            btnplayorresume.Background = new SolidColorBrush(Color.FromArgb(255, 127, 255, 0));
        }
    }
}
