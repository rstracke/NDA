using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeRoom : MonoBehaviour
{
	public GameObject trade;
	public int start_x, start_y;
	private int x, y;
	RandomMap randomMap;

	private void Start()
	{
		x = start_x;
		y = start_y;
		randomMap = GetComponent<RandomMap>();

		for (int i = 1; i < 10; i++)
			SpawnWallLeft(i);

		for (int i = 1; i < 10; i++)
			SpawnFloor();
		x++;

		for (int i = 1; i < 10; i++)
			SpawnWallRight(i);
	}

	private void SpawnFloor()
	{
		x++;
		GameObject obj = Instantiate(randomMap.oneFloor, new Vector3(x, y, 0), Quaternion.identity);
		obj.transform.parent = trade.transform;
		Debug.Log("debug: " + x + ":" + y);
	}

	private void SpawnRapmDown(bool flag)
	{
		y++;
		GameObject obj = Instantiate(randomMap.oneRampDown, new Vector3(x, y, 0), Quaternion.identity);
		if (!flag)
			obj.transform.eulerAngles = new Vector3(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z - 90);
		obj.transform.parent = trade.transform;
	}

	private void SpawnRampUp(bool flag)
	{
		GameObject obj = Instantiate(randomMap.oneRampUp, new Vector3(x, y, 0), Quaternion.identity);
		if (!flag)
			obj.transform.eulerAngles = new Vector3(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z + 90);
		obj.transform.parent = trade.transform; 
		y--;
	}

	private void SpawnWallLeft(int koof)
	{
		GameObject obj = Instantiate(randomMap.oneWallLeft, new Vector3(x, y + koof, 0), Quaternion.identity);
		obj.transform.parent = trade.transform;
	}

	private void SpawnWallRight(int koof)
	{
		GameObject obj = Instantiate(randomMap.oneWallRight, new Vector3(x, y + koof, 0), Quaternion.identity);
		obj.transform.parent = trade.transform;
	}
}