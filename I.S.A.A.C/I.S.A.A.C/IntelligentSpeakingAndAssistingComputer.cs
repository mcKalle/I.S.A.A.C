using System;
using System.Reflection;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using ISAAC.Networking;
using ISAAC.Utility;
using NLog;
using ISAAC.SpeakEngine;
using ISAAC.Brain;
using ISAAC.Brain.Memorizing.WordPronunciation;

namespace ISAAC
{
    class IntelligentSpeakingAndAssistingComputer
    {
        public string Name { get; set; }
        public string Introduction { get; set; }

        public VoiceController VoiceController { get; set; }
        public BrainController BrainController { get; set; }

        public TcpServerClient TcpServerClient { get; set; }

        /// <summary>
        /// Sets or gets the interaction modus (f.e. the commando is written and the answer is spoken)
        /// </summary>
        public InteractionMode Interaction { get; set; }

        public enum InteractionMode { SpeakSpeak = 1, WriteSpeak = 2, SpeakWrite = 3, WriteWrite = 4 };


        private Logger _logger;

        public IntelligentSpeakingAndAssistingComputer()
        {
            _logger = LogManager.GetLogger("mainLogger");

            _logger.Info(String.Format("--- Starting ISAAC v{0} ---", Assembly.GetExecutingAssembly().GetName().Version));
            _logger.Info("Initializing string constants");
            StringConstants.InitializeConstants();

            _logger.Info("Creating Networking Components");
            TcpServerClient = new TcpServerClient(9999);

            VoiceController = new VoiceController();
            BrainController = new BrainController();

            //Choices phrases = new Choices();
            //phrases.Add("Hallo Isaac");
            //phrases.Add("Wie geht es dir");
            //phrases.Add("Magst du mich");

            //GrammarBuilder gb = new GrammarBuilder();
            //gb.Append(phrases);

            // Create the Grammar instance.
            //Grammar g = new Grammar(gb);

            //_speechEngine.LoadGrammar(g);

            //_speechEngine.RecognizeAsync();
        }



        public string InterpreteUserInput(string text)
        {
            text = text.Replace(".", "").Replace(",", "").Replace("!", "").Replace("?", "").Replace("\"", "").Replace(";", "").Replace(":", "");
            //remove space at the end
            while (text.EndsWith(" "))
            {
                text = text.Remove(text.Length - 1);
            }
            //remove space at the beginning
            while (text.StartsWith(" "))
            {
                text = text.Remove(0, 1);
            }
            text = text.ToLower();

            switch (text)
            {
                case "hallo isaac":
                case "hallo":
                    VoiceController.Speak("Hallo Sir!");
                    break;
                case "wie geht es dir":
                case "wie geht's":
                case "wie gehts":
                    VoiceController.Speak("Da ich ein Computer bin habe ich keinen Gemütszustand, aber der Höflichkeit halber: Danke gut, und Ihnen Sir?");
                    break;
                case "magst du mich":
                    VoiceController.Speak("Da Sie mich konstruiert haben ist es ein Privileg Sie zu mögen, da es für meine Lebenserhaltung essentiell ist. Also ja, ich empfinde eine gewisse Zuneigung zu Ihnen.");
                    break;
            }

            return text;
        }


        public void Introduce()
        {
            VoiceController.SpellWord("Philipp");
            //VoiceController.Speak(string.Format("Mein Name ist {0} und ich bin Ihr persönlicher Assistent", Name));
        }
    }
}
