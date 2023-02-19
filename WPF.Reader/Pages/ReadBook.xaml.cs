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
        public ReadBook()
        {
            InitializeComponent();
        }


        private void LireVoixHaute(object sender, RoutedEventArgs e)
        {
            
            // Configure the audio output.   
            
            //this.synth.SetOutputToDefaultAudioDevice();

            // Speak a string.  
            var button = sender as Button;
            var content = button.CommandParameter;
            this.synth.SelectVoiceByHints(VoiceGender.Neutral, VoiceAge.NotSet, 0, CultureInfo.GetCultureInfo("fr-fr"));
            this.synth.SpeakAsync((string)content);

        }
        private void Pause(object sender, RoutedEventArgs e)
        {
            this.synth.Pause();
        }
        private void Reprendre(object sender, RoutedEventArgs e)
        {
            this.synth.Resume();
        }
        private void Stop(object sender, RoutedEventArgs e)
        {
            this.synth.Dispose();
        }
    }
}
