using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomProps : MonoBehaviour
{
	public GameObject[] lights;
	public int lightsChance;
	private int lightsPositionCheck;

	public void CreateLight(int x, int y, bool flag)
	{
		if ((flag && lightsPositionCheck + 3 > x) || (!flag && lightsPositionCheck - 3 < x))
			return;
		if (Random.Range(0, 100) < lightsChance)
		{
			lightsPositionCheck = x;
			GameObject obj = Instantiate(lights[Random.Range(0, lights.Length)], new Vector3(x, y, 0), Quaternion.identity);
			obj.transform.parent = GetComponent<RandomMap>().globalStatic.transform;
		}
	}


}
