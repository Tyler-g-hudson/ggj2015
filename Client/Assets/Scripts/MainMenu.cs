﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public Communicator communicator;
	public UnityEngine.UI.Selectable textInput;

	public void TextSubmitted()
	{
		if (Network.peerType == NetworkPeerType.Disconnected)
		{
			string connectionIP = ((UnityEngine.UI.InputField)textInput).text;
			communicator.Connect(connectionIP);
		}
	}

	public void StartGame()
	{
		if (Network.peerType == NetworkPeerType.Client)
		{
			Application.LoadLevel("Main");
		}
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	void Update()
	{
		textInput.enabled = (Network.peerType == NetworkPeerType.Disconnected);
	}
}
