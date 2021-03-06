using UnityEngine;
using System.Collections;

public class ServerConnectManager : MonoBehaviour
{
	//マスターサーバーに接続するスクリプト　サーバー側
	
	public static string GAME_TYPE_NAME = "UGJ ChatSystem";
	public GameObject userManager;

	void Start ()
	{
		Network.InitializeSecurity ();
		Network.InitializeServer (256, 25002, !Network.HavePublicAddress ());
	}

	void OnServerInitialized ()
	{
		MasterServer.RegisterHost (GAME_TYPE_NAME, "ChatSystem");
		Network.Instantiate (userManager, Vector3.zero, Quaternion.identity, 1);
	}
	
	void OnMasterServerEvent (MasterServerEvent msEvent)
	{
		Debug.Log ("msEvent : " + msEvent);
		MasterServer.RequestHostList ("UGJ ChatSystem");
	}
	
	void Update ()
	{
		if (MasterServer.PollHostList ().Length != 0)
			foreach (HostData h in MasterServer.PollHostList())
				Debug.Log (h.gameName);
	}
}
