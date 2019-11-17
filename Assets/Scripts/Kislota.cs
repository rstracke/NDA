using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kislota : MonoBehaviour
{
	private void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.GetComponent<EnemyFollow>())
			collision.gameObject.GetComponent<EnemyFollow>().HP -= 0.1f;
		else if (collision.gameObject.GetComponent<PlayerInfo>())
			collision.gameObject.GetComponent<PlayerInfo>().HP -= 0.1f;
	}
}
