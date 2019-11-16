using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
	[Header("Иерархия")]
	public GameObject globalBackground;
	public GameObject globalStatic;
	public GameObject player;

	[Header("Основные коллайдеры")]
	public GameObject oneBoardUp;
	public GameObject oneBoardDown;
	public GameObject oneAcidUp;
	public GameObject oneAcidDown;
	public GameObject oneFloor;
	public GameObject oneRampUp;
	public GameObject oneRampDown;
	public GameObject oneWallLeft;
	public GameObject oneWallRight;

	[Header("Объекты в мире")]
	public GameObject barrel;
	public int chanceBarrel;

	[Header("Коллекция заднего фона")]
	public GameObject[] background;
	public GameObject[] fillFloor;
	public int backgroundCount;

	[Header("Коэффицие́нты рандома")]
	public string ForwardRandomMap;

	public int floor;
	public int floorDown;

	public int up;

	public int down;

	public int trap;
	public int trapMaxWight;

	private int maxRandomCount;

	GameObject[] statics = new GameObject[6];

	void Start()
    {
		statics[0] = oneAcidUp;
		statics[2] = oneFloor;
		statics[3] = oneRampUp;
		statics[4] = oneRampDown;
		statics[5] = oneWallLeft;
		statics[1] = oneWallRight;

		maxRandomCount = floor + up + down + trap;
		if (ForwardRandomMap == "right")
			MapRandom(true);
		else
			MapRandom(false);
    }

	public float start_x, start_y;
	int x, y;

	private void MapRandom(bool flag)
	{
		x = y = 0;
		if (flag)
		{
			x = -1;
			FillUnderFloor(-1);
			SpawnBackgroundRandom();
			for (int i = 0; i < 2; i++)
				SpawnWallLeft(-i - 1);
			y = 3;
			SpawnBoard(true);
			for (int i = 0; i < 5; i++)
			{
				x--;
				SpawnFloor();
				SpawnBackgroundRandom();
			}
		}
		else
		{
			x = 1;
			FillUnderFloor(-1);
			SpawnBackgroundRandom();
			for (int i = 0; i < 2; i++)
				SpawnWallRight(-i - 1);
			y = 3;
			SpawnBoard(false);
			for (int i = 0; i < 5; i++)
			{
				x++;
				SpawnFloor();
				SpawnBackgroundRandom();
			}
		}
		x = y = 0;
		int count = flag ? 5 : -5;
		int increment = flag ? 1 : -1;
		for (;flag ? x < count : x > count; x += increment)
		{
			GameObject obj = Instantiate(oneFloor, new Vector3(x, y, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform;
			SpawnBackgroundRandom();
			FillUnderFloor(0);
		}

		count = flag ? 100 : -100;
		for (; flag ? x < count : x > count; x += increment)
		{
			int rand = Random.Range(0, maxRandomCount);
			if (rand >= 0 && rand < floor)
				SpawnFloor();
			else if (rand >= floor && rand < maxRandomCount - down - trap)
			{
				SpawnRapmDown();
				SpawnBackgroundRandom();

				if (flag)
					x++;
				else
					x--;
				SpawnFloor();
			}
			else if (rand >= floor + up && rand < maxRandomCount - trap)
			{
				SpawnRampUp();
				SpawnBackgroundRandom();

				if (flag)
					x++;
				else
					x--;
				SpawnFloor();
			}
			else if (rand >= maxRandomCount - trap && rand < maxRandomCount)
			{
				SpawnBoard(true);
				FillUnderFloor(1);
				SpawnBackgroundRandom();
				if (flag)
					x++;
				else
					x--;
				SpawnTrap();
				SpawnBackgroundRandom();
				if (flag)
					x++;
				else
					x--;
				SpawnBoard(false);
				FillUnderFloor(1);
			}
			SpawnBackgroundRandom();
		}
	}

	#region Spawn static Tiles
	private void SpawnFloor()
	{
		FillUnderFloor(0);
		GameObject obj = Instantiate(oneFloor, new Vector3(x, y, 0), Quaternion.identity);
		obj.transform.parent = globalStatic.transform;
		SpawnObject(barrel, chanceBarrel);
	}

	private void SpawnRapmDown()
	{
		FillUnderFloor(-1);
		y++;
		GameObject obj = Instantiate(oneRampDown, new Vector3(x, y, 0), Quaternion.identity);
		obj.transform.parent = globalStatic.transform;
	}

	private void SpawnRampUp()
	{
		FillUnderFloor(0);
		GameObject obj = Instantiate(oneRampUp, new Vector3(x, y, 0), Quaternion.identity);
		obj.transform.parent = globalStatic.transform;
		y--;
	}

	private void SpawnTrap()
	{
		if (trapMaxWight <= 0)
			trapMaxWight = 1;
		int count = Random.Range(1, trapMaxWight);
		for (int i = 0; i < count; i++)
		{
			SpawnBackgroundRandom();
			FillUnderFloor(2);
			GameObject obj = Instantiate(oneAcidUp, new Vector3(x, y, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform;
			//создаем нижний уровень яда
			obj = Instantiate(oneAcidDown, new Vector3(x, y - 1, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform;
			//создаём пол под ядом
			obj = Instantiate(oneFloor, new Vector3(x, y - 2, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform;
			if (i + 1 < count)
				x++;
		}
	}

	private void SpawnWallLeft(int koof)
	{
		GameObject obj = Instantiate(oneWallLeft, new Vector3(x, y - koof, 0), Quaternion.identity);
		obj.transform.parent = globalStatic.transform;
	}

	private void SpawnWallRight(int koof)
	{
		GameObject obj = Instantiate(oneWallRight, new Vector3(x, y - koof, 0), Quaternion.identity);
		obj.transform.parent = globalStatic.transform;
	}
	//true == вниз, false == вверх
	private void SpawnBoard(bool flag)
	{
		if (flag)
		{
			GameObject obj = Instantiate(oneBoardDown, new Vector3(x, y, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform;
			SpawnWallLeft(1);
		}
		else
		{
			GameObject obj = Instantiate(oneBoardUp, new Vector3(x, y, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform;
			SpawnWallRight(1);
		}
	}

	#endregion

	#region Spawn fill under floor Tiles
	private void FillUnderFloor(int down)
	{
		for (int i = 1 + down; i < floorDown + down; i++)
		{
			GameObject obj = Instantiate(fillFloor[Random.Range(0, fillFloor.Length)], new Vector3(x, y - i, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform;
		}
	}
	#endregion

	#region Spawn Background Tiles
	private void SpawnBackgroundRandom()
	{
		for (int i = backgroundCount / 2 * -1; i < backgroundCount / 2; i++)
		{
			GameObject obj = Instantiate(background[Random.Range(0, background.Length)], new Vector3(this.x, y + i, 0), Quaternion.identity);
			obj.transform.parent = globalBackground.transform;
		}
	}
	#endregion

	#region Spawn Objects
	private void SpawnObject(GameObject obj, int chance)
	{
		if (Random.Range(0, 100) < chance)
		{
			GameObject newObj = Instantiate(obj, new Vector3(x, y + 1, 0), Quaternion.identity);
			newObj.transform.parent = globalBackground.transform;
		}
	}

	#endregion

	#region Destroy AllMap
	private void DestroyMap()
	{
		for (int i = 0; i < globalStatic.transform.childCount; i++)
			Destroy(globalStatic.transform.GetChild(i).gameObject);
		for (int i = 0; i < globalBackground.transform.childCount; i++)
			Destroy(globalBackground.transform.GetChild(i).gameObject);
	}
	#endregion

	[Header("Генерация новой карты")]
	public bool generateMap;
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R) || generateMap)
		{
			player.transform.position = new Vector3(0, 5, 0);
			player.GetComponent<Rigidbody2D>().isKinematic = true;
			player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			DestroyMap();
			if (ForwardRandomMap == "right")
				MapRandom(true);
			else
				MapRandom(false);
			player.GetComponent<Rigidbody2D>().isKinematic = false;
			generateMap = false;
		}
	}
}
