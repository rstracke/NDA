using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class EnemyFollow : MonoBehaviour
{
	float rot_x, rot_y, rot_z;
    void Update()
    {
		if (transform.position.x < LocalPlayer.Singleton.player.transform.position.x)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.transform.eulerAngles.z);
			//if (transform.position.x < LocalPlayer.Singleton.player.transform.position.x)

		}
		else
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, -180, transform.transform.eulerAngles.z);
	}
}
*/
class EnemyFollow : MonoBehaviour
{
	GameObject player;
	Rigidbody2D rb;
	public float speedMove = 30.0f;
	public float HP;

	void Start()
	{
		player = LocalPlayer.Singleton.player;
		rb = GetComponent<Rigidbody2D>();
	}

	float speed;
	void Update()
	{
		Follow();
		Fire();

		if (HP <= 0)
		{
			Destroy(gameObject);
		}
		//transform.GetChild(0).gameObject.GetComponent<Animator>().Play("SolderDie");

	}

	public float delay, newDelay;
	public GameObject bullet;
	public bool target;
	private void Follow()
	{
		if ((player.transform.position - transform.position).magnitude > 8)
		{
			target = false;
			return;
		}
		else
			target = true;
		if (transform.position.x < LocalPlayer.Singleton.player.transform.position.x)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.transform.eulerAngles.z);
			speed = rb.velocity.x + speedMove;
			rb.velocity = new Vector2(speed, rb.velocity.y);
		}
		else
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, -180, transform.transform.eulerAngles.z);
			speed = rb.velocity.x - speedMove;
			rb.velocity = new Vector2(speed, rb.velocity.y);
		}
		if (Mathf.Abs(transform.position.x - player.transform.position.x) > 2 && rb.velocity.magnitude < 1 && Random.Range(0, 100) < 50)
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 5);
	}

	private void Fire()
	{
		delay -= Time.deltaTime;
		if (delay < 0 && target)
		{
			GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
			newBullet.name = "Bullet";
			delay = newDelay;
		}
	}
}