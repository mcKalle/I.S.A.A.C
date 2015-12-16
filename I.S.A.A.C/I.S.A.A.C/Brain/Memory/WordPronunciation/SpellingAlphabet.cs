
using System.Collections.Generic;

namespace ISAAC.Brain.Memory.WordPronunciation
{
	public static class SpellingAlphabet
	{
		static Dictionary<char, string> spellingAlphabetDictionary;
		static bool isInitialized;

		public static string GetSpellingWord(char letterIn)
		{
			if (!isInitialized)
			{
				Initialize();
				isInitialized = true;
			}

			return spellingAlphabetDictionary[letterIn];
		}

		private static void Initialize()
		{
			spellingAlphabetDictionary = new Dictionary<char, string>
			{
				{ 'A', "Anton" }, 
				{ 'Ä', "Ärger" }, 
				{ 'B', "Berta" }, 
				{ 'C', "Cäsar" }, 
				{ 'D', "Dora" }, 
				{ 'E', "Emil" }, 
				{ 'F', "Friedrich" }, 
				{ 'G', "Gustav" }, 
				{ 'H', "Heinrich" },
				{ 'I', "Ida" }, 
				{ 'J', "Julius" }, 
				{ 'K', "Konrad" }, 
				{ 'L', "Ludwig" }, 
				{ 'M', "Martha" }, 
				{ 'N', "Nordpol" }, 
				{ 'O', "Otto" }, 
				{ 'Ö', "Österreich" }, 
				{ 'P', "Paula" }, 
				{ 'Q', "Quelle" },
				{ 'R', "Richard" }, 
				{ 'S', "Siegfried" }, 
				{ 'ß', "scharfes S" }, 
				{ 'T', "Theodor" }, 
				{ 'U', "Ulrich" }, 
				{ 'Ü', "Übel" }, 
				{ 'V', "Viktor" }, 
				{ 'W', "Wilhelm" }, 
				{ 'X', "Xaver" }, 
				{ 'Y', "Ypsilon" }, 
				{ 'Z', "Zeppelin" }
			};
		}
	}
}
