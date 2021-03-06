using UnityEngine;
using System.Collections;

public class ClientConnectManager : MonoBehaviour
{
	//サーバーに接続するスクリプト　クライアント側
	
	private bool isConnect = false;
	public GameObject userManager;

	void Start ()
	{
		MasterServer.RequestHostList (ServerConnectManager.GAME_TYPE_NAME);
	}
	
	void Update ()
	{
		if (MasterServer.PollHostList ().Length != 0 && !isConnect)
			foreach (HostData h in MasterServer.PollHostList()) {
				isConnect = true;
				Network.Connect (h);
			}
	}
}
