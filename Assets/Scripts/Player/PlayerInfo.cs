using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
	public float HP;
	public float DAMAGE;
	public GameObject bullet;

	private void Update()
	{
		if (HP < 0)
		{
			LocalPlayer.Singleton.GetComponent<RandomMap>().DestroyMap();
			transform.position = Vector3.zero;
			LocalPlayer.Singleton.Trader = true;
			HP = 100;
		}

		Attack();
	}

	private void Attack()
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.3f), Quaternion.identity);
			newBullet.name = "Bullet";
			if (transform.localScale.x < 0)
				newBullet.GetComponent<BulletLaserPlayer>().koof = -1;
			else
				newBullet.GetComponent<BulletLaserPlayer>().koof = 1;
			newBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.4f), Quaternion.identity);
			newBullet.name = "Bullet";
			if (transform.localScale.x < 0)
				newBullet.GetComponent<BulletLaserPlayer>().koof = -1;
			else
				newBullet.GetComponent<BulletLaserPlayer>().koof = 1;
		}
	}


}
