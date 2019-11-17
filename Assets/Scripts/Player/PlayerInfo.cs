using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
	public float HP;

	private void Update()
	{
		if (HP < 0)
		{
			LocalPlayer.Singleton.GetComponent<RandomMap>().DestroyMap();
			transform.position = Vector3.zero;
			LocalPlayer.Singleton.Trader = true;
			HP = 100;
		}
	}

	private void Attack()
	{

	}
}
