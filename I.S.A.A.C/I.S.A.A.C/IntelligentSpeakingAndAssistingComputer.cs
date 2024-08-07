﻿using System;
using System.Linq;
using System.Reflection;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using ISAAC.Booting;
using ISAAC.Brain;
using ISAAC.Networking;
using ISAAC.Utility;
using NLog;

namespace ISAAC
{
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
				Rate = 1,
                
			};

            foreach (var v in _speechSynthesizer.GetInstalledVoices().Select(v => v.VoiceInfo))
            {
                Console.WriteLine("Name:{0}, Gender:{1}, Age:{2}",
                  v.Name, v.Gender, v.Age);
            }

            _speechSynthesizer.SelectVoice("Microsoft Hedda Desktop");

            
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

}
