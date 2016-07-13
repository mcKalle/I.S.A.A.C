using ISAAC.Brain.Memorizing.WordPronunciation;
using ISAAC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace ISAAC.SpeakEngine
{
    public class VoiceController
    {

        private SpeechRecognitionEngine _speechEngine;
        private SpeechSynthesizer _speechSynthesizer;

        public VoiceController()
        {

            _speechEngine = new SpeechRecognitionEngine();
            _speechEngine.SpeechRecognized += SpeechRecognized;

            _speechSynthesizer = new SpeechSynthesizer();

            _speechSynthesizer.Rate = 1;
        }

        private void SpeechRecognized(object senderIn, SpeechRecognizedEventArgs eventArgsIn)
        {
            // InterpreteUserInput(eventArgsIn.Result.Text);
        }

        public void Speak(string text)
        {
            _speechSynthesizer.SpeakAsync(text);
        }

        public void SpellWord(string word)
        {
            Speak(Resources.SpellingInfoText + word);

            // convert word to upper, because the spelling alphabet 
            // contains only upper case letters
            word = word.ToUpper();

            foreach (char c in word)
            {
                string spellingWord = SpellingAlphabet.GetSpellingWord(c);
                Speak(spellingWord);
            }
        }
    }
}
