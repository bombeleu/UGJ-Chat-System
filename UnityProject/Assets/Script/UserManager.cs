using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserManager : MonoBehaviour
{
	//コメントやユーザー名の同期を取るスクリプト サーバー＆クライアント
	
	public List<string> userNameList = new List<string> ();
	public List<string> commentList = new List<string> ();

	[RPC]
	void AddName (string playerName)
	{
		if (userNameList.Contains (playerName)) {
			return;
		}
		userNameList.Add (playerName);
	}

	[RPC]
	void Comment (string name, string comment)
	{
		commentList.Add (name + "," + comment + "," + System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
	}
}
