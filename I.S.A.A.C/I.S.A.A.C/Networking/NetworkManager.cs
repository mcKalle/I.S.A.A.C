
namespace ISAAC.Networking
{
	class NetworkManager
	{
		public TcpServerClient ServerClient { get; set; }

		public NetworkManager()
		{
			ServerClient = new TcpServerClient(9999);
		}
	}
}
