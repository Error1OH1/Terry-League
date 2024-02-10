using Sandbox;
using Sandbox.Network;

public sealed class ServerHost : Component
{
	[Group("TerryLeague")]
	[Title("Network Manager")]
	public class NetworkManager : Component, Component.INetworkListener
	{
		[Property] public PrefabScene playerPrefab {  get; set; }
	protected override void OnStart()
	{
			if (!GameNetworkSystem.IsActive)
			{
				GameNetworkSystem.CreateLobby();
			}
			base.OnStart();
	}

		void INetworkListener.OnConnected(Sandbox.Connection conn )
		{
			var player = playerPrefab.Clone();
			player.NetworkSpawn( conn );
		}
	}
}
