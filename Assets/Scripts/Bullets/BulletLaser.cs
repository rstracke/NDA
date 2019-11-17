using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLaser : MonoBehaviour
{
	private GameObject player;
	private Rigidbody2D rb;
	private Vector3 vector;
	private void Start()
	{
		player = LocalPlayer.Singleton.player;
		rb = GetComponent<Rigidbody2D>();
		vector = player.transform.position - transform.position;
		//transform.LookAt(LocalPlayer.Singleton.player.transform.position);
		transform.right = player.transform.position - transform.position;
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90);
	}

	private void Update()
	{
		for (; vector.magnitude < 10;)
			vector *= 2;
		for (; vector.magnitude > 10;)
			vector /= 2;
		rb.velocity = vector;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Player")
		{
			Destroy(gameObject);
			LocalPlayer.Singleton.player.GetComponent<PlayerInfo>().HP--;
		}
	}
}


