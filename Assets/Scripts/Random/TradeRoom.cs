using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeRoom : MonoBehaviour
{
	public int start_x, start_y;
	private int x, y;
	RandomMap randomMap;

	private void Start()
	{
		x = start_x;
		y = start_y;
		randomMap = GetComponent<RandomMap>();

		for (int i = 0; i < 100; i++)
			SpawnFloor();
	}

	private void SpawnFloor()
	{
		GameObject obj = Instantiate(randomMap.oneFloor, new Vector3(x, y, 0), Quaternion.identity);
		Debug.Log("debug: " + x + ":" + y);
		obj.transform.parent = randomMap.globalStatic.transform;
		obj.name = "111111111111111111111111111111";
		x++;
	}

	private void SpawnRapmDown(bool flag)
	{
		y++;
		GameObject obj = Instantiate(randomMap.oneRampDown, new Vector3(x, y, 0), Quaternion.identity);
		if (!flag)
			obj.transform.eulerAngles = new Vector3(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z - 90);
		obj.transform.parent = randomMap.globalStatic.transform;
	}

	private void SpawnRampUp(bool flag)
	{
		GameObject obj = Instantiate(randomMap.oneRampUp, new Vector3(x, y, 0), Quaternion.identity);
		if (!flag)
			obj.transform.eulerAngles = new Vector3(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z + 90);
		obj.transform.parent = randomMap.globalStatic.transform;
		y--;
	}
}