using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLaser : MonoBehaviour
{
	private GameObject player;
	private Rigidbody2D rb;
	private Vector3 vector;
	private float timer;
	private void Start()
	{
		timer = 5;
		player = LocalPlayer.Singleton.player;
		rb = GetComponent<Rigidbody2D>();
		vector = player.transform.position - transform.position;
		//transform.LookAt(LocalPlayer.Singleton.player.transform.position);
		transform.right = player.transform.position - transform.position;
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90);


		for (; vector.magnitude < 50;)
			vector *= 2;
	}

	private void Update()
	{
		timer -= Time.deltaTime;
		if (timer < 0)
			Destroy(gameObject);

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


