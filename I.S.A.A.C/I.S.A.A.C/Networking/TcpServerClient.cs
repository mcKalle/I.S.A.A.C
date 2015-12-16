using System.Net;
using System.Net.Sockets;
using NLog;

namespace ISAAC.Networking
{
	class TcpServerClient
	{
		public int Port { get; set; }

		private TcpListener _listener;
		private Logger _logger;

		public TcpServerClient(int port)
		{
			_logger = LogManager.GetLogger("networkingLogger");

			Port = port;
			_listener = new TcpListener(IPAddress.Any, Port);

			_logger.Info("Creating new TcpServerClient with the port " + Port);
		}

	}
}
