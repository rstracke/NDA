using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInfo : MonoBehaviour
{
	Text text;

	private void Start()
	{
		text = GetComponent<Text>();
	}

	void Update()
    {
		text.text = "HP: " + LocalPlayer.Singleton.player.GetComponent<PlayerInfo>().HP + ", points: " + LocalPlayer.Singleton.points;

	}
}
