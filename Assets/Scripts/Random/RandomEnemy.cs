using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemy : MonoBehaviour
{
	public GameObject[] enemy;
	public int enemyChance;

	public void SpawnEnemy(int x, int y)
	{
		if (Random.Range(0, 100) < enemyChance)
			Instantiate(enemy[Random.Range(0, enemy.Length)], new Vector3(x, y + 1, 0), Quaternion.identity);
	}
}
