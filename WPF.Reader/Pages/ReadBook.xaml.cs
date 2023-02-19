using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
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
        SpeechSynthesizer synth = new SpeechSynthesizer();
        public bool IsPauseValue { get; set; } = false;
        public bool IsFirstTimePlayed { get; set; } = true;
        public ReadBook()
        {
            InitializeComponent();
        }

        private void PauseOrResume(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if(IsFirstTimePlayed)
            {
                var content = button.CommandParameter;
                this.synth.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("fr-fr"));
                synth.SpeakAsync((string)content);
                IsFirstTimePlayed = false;
                IsPauseValue = !IsPauseValue;
                button.Content = "⏸︎ Pause";
                button.Background = new SolidColorBrush(Color.FromArgb(255, 255, 64, 102));
                return;
            }
            if (IsPauseValue)
            {
                synth.Pause();
                IsPauseValue = !IsPauseValue;
                button.Content = "▶ Play";
                button.Background = new SolidColorBrush(Color.FromArgb(255, 127, 255, 0));
            }
            else
            {
                synth.Resume();
                IsPauseValue = !IsPauseValue;
                button.Content = "⏸︎ Pause";
                button.Background = new SolidColorBrush(Color.FromArgb(255, 255, 64, 102));
            }
        }
    }
}
