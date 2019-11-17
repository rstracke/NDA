using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderExit : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Player")
		{
			LocalPlayer.Singleton.player.transform.position = new Vector3(0, -200, 0);
			LocalPlayer.Singleton.player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			LocalPlayer.Singleton.Trader = false;
			LocalPlayer.Singleton.GetComponent<RandomMap>().ReloadMap(true, true, 0, -201);
			LocalPlayer.Singleton.GetComponent<RandomMap>().cicle = 0;
		}
	}
}
