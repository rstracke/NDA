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
			GameObject obj = Instantiate(enemy[Random.Range(0, enemy.Length)], new Vector3(x, y + 2, 0), Quaternion.identity);
			obj.transform.parent = GetComponent<RandomMap>().globalEnemy.transform;
		}
	}

	public void Apocalipsis(int x, int y)
	{
		apoc = true;
	}
}
