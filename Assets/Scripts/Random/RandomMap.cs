using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
	[Header("Иерархия")]
	public GameObject globalBackground;
	public GameObject globalStatic;

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

	[Header("Коллекция заднего фона")]
	public GameObject[] background;
	public GameObject[] fillFloor;
	public int backgroundCount;

	[Header("Коэффицие́нты рандома")]
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
		MapRandom();
    }

	public float start_x, start_y;
	int x, y;

	private void MapRandom()
	{
		x = y = 0;
		for (x = 0; x < 5; x++)
		{
			GameObject obj = Instantiate(oneFloor, new Vector3(x, y, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform;
			SpawnBackgroundRandom();
			FillUnderFloor(0);
		}

		for (x = 5; x < 100; x++)
		{
			int rand = Random.Range(0, maxRandomCount);
			if (rand >= 0 && rand < floor)
				SpawnFloor();
			else if (rand >= floor && rand < maxRandomCount - down - trap)
			{
				SpawnRapmDown();
				SpawnBackgroundRandom();

				x++;
				SpawnFloor();
			}
			else if (rand >= floor + up && rand < maxRandomCount - trap)
			{
				SpawnRampUp();
				SpawnBackgroundRandom();

				x++;
				SpawnFloor();
			}
			else if (rand >= maxRandomCount - trap && rand < maxRandomCount)
			{
				SpawnBoard(true);
				SpawnBackgroundRandom();
				x++;
				SpawnTrap();
				SpawnBackgroundRandom();
				x++;
				SpawnBoard(false);
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
		FillUnderFloor(1);
	}

	#endregion

	#region Spawn fill under floor Tiles
	private void FillUnderFloor(int down)
	{
		for (int x = 1 + down; x < floorDown + down; x++)
		{
			GameObject obj = Instantiate(fillFloor[Random.Range(0, fillFloor.Length)], new Vector3(this.x, y - x, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform;
		}
	}
	#endregion

	#region Spawn Background Tiles
	private void SpawnBackgroundRandom()
	{
		for (int x = backgroundCount / 2 * -1; x < backgroundCount / 2; x++)
		{
			GameObject obj = Instantiate(background[Random.Range(0, background.Length)], new Vector3(this.x, y + x, 0), Quaternion.identity);
			obj.transform.parent = globalBackground.transform;
		}
	}
	#endregion

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			MapRandom();
		}
	}
}
