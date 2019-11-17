using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLaserPlayer : MonoBehaviour
{
	float timer = 5;
	GameObject player;
	Rigidbody2D rb;
	Vector3 vector;
	public int koof;

	private void Start()
	{
		player = LocalPlayer.Singleton.player;
		rb = GetComponent<Rigidbody2D>();
		vector = transform.right * koof;// new Vector3(2, 0, 1);
		Debug.Log(vector);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90);


		for (; vector.magnitude < 20;)
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
		if ((collision.gameObject != null) && collision.gameObject.GetComponent<EnemyFollow>())
			collision.gameObject.GetComponent<EnemyFollow>().HP -= LocalPlayer.Singleton.player.GetComponent<PlayerInfo>().DAMAGE;
	}
}
