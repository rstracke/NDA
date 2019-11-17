using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemy : MonoBehaviour
{
	public GameObject[] enemy;
	public int enemyChance;
	public bool apoc;

	public void SpawnEnemy(int x, int y)
	{
		if (Random.Range(0, 100) < enemyChance)
		{
			int cicle = LocalPlayer.Singleton.GetComponent<RandomMap>().cicle;
			GameObject obj = Instantiate(enemy[Random.Range(0, enemy.Length)], new Vector3(x, y + 2, 0), Quaternion.identity);
			obj.transform.parent = GetComponent<RandomMap>().globalEnemy.transform;
			if (cicle != 0)
			{
				obj.GetComponent<EnemyFollow>().speedMove *= cicle;
				obj.GetComponent<EnemyFollow>().HP *= cicle;
				obj.GetComponent<EnemyFollow>().minDamage *= cicle;
				obj.GetComponent<EnemyFollow>().maxDamage *= cicle;
				obj.GetComponent<EnemyFollow>().minPoints *= cicle;
				obj.GetComponent<EnemyFollow>().maxPoints *= cicle;

					/*
					 	public float speedMove = 30.0f;
	public float HP;
	public float minDamage, maxDamage;
	public float minPoints, maxPoints;
					 */
			}
		}
	}

	public void Apocalipsis(int x, int y)
	{
		apoc = true;
	}
}
