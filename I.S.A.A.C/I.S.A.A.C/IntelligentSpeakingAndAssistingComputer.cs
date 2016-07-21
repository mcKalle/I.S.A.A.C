using System;
using System.Reflection;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using ISAAC.Booting;
using ISAAC.Brain;
using ISAAC.Networking;
using ISAAC.Utility;
using NLog;
using ISAAC.SpeakEngine;
using ISAAC.Brain;
using ISAAC.Brain.Memorizing.WordPronunciation;

namespace ISAAC
{
<<<<<<< HEAD
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
=======
	class IntelligentSpeakingAndAssistingComputer
	{
		public string Name { get; set; }
		public string Introduction { get; set; }

		public Mind Brain { get; set; }
		public BootManager BootManager { get; set; }
		public NetworkManager NetworkManager { get; set; }

		/// <summary>
		/// Sets or gets the interaction modus (f.e. the commando is written and the answer is spoken)
		/// </summary>
		public InteractionMode Interaction { get; set; }

		public enum InteractionMode { SpeakSpeak = 1, WriteSpeak = 2, SpeakWrite = 3, WriteWrite = 4 };

		private SpeechRecognitionEngine _speechEngine;
		private SpeechSynthesizer _speechSynthesizer;

		private Logger _logger;

		public IntelligentSpeakingAndAssistingComputer()
		{
			_logger = LogManager.GetLogger("mainLogger");

			_logger.Info(String.Format("--- Starting ISAAC v{0} ---", Assembly.GetExecutingAssembly().GetName().Version));

			Initialize();

			_speechSynthesizer = new SpeechSynthesizer
			{
				Rate = 1
			};


			Choices phrases = new Choices();
			phrases.Add("Hallo Isaac");
			phrases.Add("Wie geht es dir");
			phrases.Add("Magst du mich");

			GrammarBuilder gb = new GrammarBuilder();
			gb.Append(phrases);

			// Create the Grammar instance.
			Grammar g = new Grammar(gb);

			_speechEngine.LoadGrammar(g);

			//_speechEngine.RecognizeAsync();
		}

		private void Initialize()
		{
            _logger.Info("+++++++++++++ Starting I.S.A.A.C v1.0 +++++++++++++");
            _logger.Info("--- Intelligent Speaking and Assisting Computer ---");

            _logger.Info("Initializing string constants");
			StringConstants.InitializeConstants();

			_logger.Info("Creating Networking Components");
			NetworkManager = new NetworkManager();
            _logger.Info("Networking Components initialized");
            _logger.Info("Creating BootManager Components");
			BootManager = new BootManager();
            _logger.Info("BootManager initialized");

            _speechEngine = new SpeechRecognitionEngine();
			_speechEngine.SpeechRecognized += SpeechRecognized;
		}

		private void SpeechRecognized(object senderIn, SpeechRecognizedEventArgs eventArgsIn)
		{
			InterpreteUserInput(eventArgsIn.Result.Text);
		}

		public string InterpreteUserInput(string textIn)
		{
			textIn = textIn.Replace(".", "").Replace(",", "").Replace("!", "").Replace("?", "").Replace("\"", "").Replace(";", "").Replace(":", "");
			//remove space at the end
			while (textIn.EndsWith(" "))
			{
				textIn = textIn.Remove(textIn.Length - 1);
			}
			//remove space at the beginning
			while (textIn.StartsWith(" "))
			{
				textIn = textIn.Remove(0, 1);
			}
			textIn = textIn.ToLower();

			switch (textIn)
			{
				case "hallo isaac":
				case "hallo":
					Speak("Hallo Sir!");
					break;
				case "wie geht es dir":
				case "wie geht's":
				case "wie gehts":
					Speak("Da ich ein Computer bin habe ich keinen Gemütszustand, aber der Höflichkeit halber: Danke gut, und Ihnen Sir?");
					break;
				case "magst du mich":
					Speak("Da Sie mich konstruiert haben ist es ein Privileg Sie zu mögen, da es für meine Lebenserhaltung essentiell ist. Also ja, ich empfinde eine gewisse Zuneigung zu Ihnen.");
					break;
			}

			return textIn;
		}

		public void Speak(string textIn)
		{
			_speechSynthesizer.SpeakAsync(textIn);
		}

		public void Introduce()
		{
			Speak(String.Format("Mein Name ist {0} und ich bin Ihr persönlicher Assistent", Name));
		}
	}
>>>>>>> origin/master
}
