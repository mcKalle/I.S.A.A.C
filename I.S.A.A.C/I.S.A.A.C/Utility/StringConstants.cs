using System.IO;
using System.Reflection;

namespace ISAAC.Utility
{
	public static class StringConstants
	{
		public static string LoggingLocation { get; private set; }

		public static void InitializeConstants()
		{
			LoggingLocation = Path.Combine(Path.GetFullPath(Assembly.GetExecutingAssembly().Location), "Logs");
		}
	}
}
