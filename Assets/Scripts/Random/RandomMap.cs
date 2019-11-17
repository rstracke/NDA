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

	public GameObject rail;
	public GameObject railPanel;

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
	public int trapMinWight;

	private int maxRandomCount;

	public int start_x, start_y;
	public int startWightMap;
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
			ReloadMap(true);
		else
			ReloadMap(false);
	}

	int x, y;

	private void MapRandom(bool flag)
	{
		x = (int)start_x;
		y = (int)start_y;
		if (flag)
		{
			x = start_x - 1;
			FillUnderFloor(-1);
			SpawnBackgroundRandom();
			for (int i = 0; i < 2; i++)
				SpawnWallLeft(-i - 1);
			y = start_y + 3;
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
			x = start_x + 1;
			FillUnderFloor(-1);
			SpawnBackgroundRandom();
			for (int i = 0; i < 2; i++)
				SpawnWallRight(-i - 1);
			y = start_y + 3;
			SpawnBoard(false);
			for (int i = 0; i < 5; i++)
			{
				x++;
				SpawnFloor();
				SpawnBackgroundRandom();
			}
		}
		x = (int)start_x;
		y = (int)start_y;
		int count = flag ? start_x + 5 : start_x - 5;
		int increment = flag ? 1 : -1;
		for (;flag ? x < count : x > count; x += increment)
		{
			GameObject obj = Instantiate(oneFloor, new Vector3(x, y, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform;
			SpawnBackgroundRandom();
			FillUnderFloor(0);
		}
		count = flag ? start_x + startWightMap : start_x - startWightMap; 
		Generate(flag, count, increment);

	}

	private void Generate(bool flag, int count, int increment)
	{
		Debug.Log("Generate " + flag);
		//count = flag ? x + count : x - count;
		if (flag)
			count += x;
		else
			count = x - count;

		for (; flag ? x < count : x > count; x += increment)
		{
			int rand = Random.Range(0, maxRandomCount);
			if (rand >= 0 && rand < floor)
				SpawnFloor();
			else if (rand >= floor && rand < maxRandomCount - down - trap)
			{
				SpawnRapmDown(flag);
				SpawnBackgroundRandom();

				if (flag)
					x++;
				else
					x--;
				SpawnFloor();
			}
			else if (rand >= floor + up && rand < maxRandomCount - trap)
			{
				SpawnRampUp(flag);
				SpawnBackgroundRandom();

				if (flag)
					x++;
				else
					x--;
				SpawnFloor();
			}
			else if (rand >= maxRandomCount - trap && rand < maxRandomCount)
			{
				int count2 = Random.Range(trapMinWight, trapMaxWight);
				if (count2 == 3)
					CreateRail(flag);
				SpawnBoard(flag);
				FillUnderFloor(1);
				SpawnBackgroundRandom();
				if (flag)
					x++;
				else
					x--;
				SpawnTrap(flag, count2);
				//SpawnBackgroundRandom();
				if (flag)
					x++;
				else
					x--;
				SpawnBoard(!flag);
				FillUnderFloor(1);
			}
			SpawnBackgroundRandom();
			RandomLights(flag);
		}
	}

	public void CreateRail(bool flag)
	{
		if (flag)
		{
			GameObject obj = Instantiate(rail, new Vector3(x + 3, y + 5, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform;
			obj = Instantiate(railPanel, new Vector3(x + 1, y + 1, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform;
			for (int i = 0; i < 6; i++)
			{
				SpawnFloor();
				SpawnBackgroundRandom();
				x++;
			}
		}
		else
		{
			GameObject obj = Instantiate(rail, new Vector3(x - 3, y + 5, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform;
			obj = Instantiate(railPanel, new Vector3(x - 1, y + 1, 0), Quaternion.identity);
			obj.transform.parent = globalStatic.transform; 
			for (int i = 0; i < 6; i++)
			{
				SpawnFloor();
				SpawnBackgroundRandom();
				x--;
			}
		}



	}

	#region Spawn static Tiles
	private void SpawnFloor()
	{
		FillUnderFloor(0);
		GameObject obj = Instantiate(oneFloor, new Vector3(x, y, 0), Quaternion.identity);
		obj.transform.parent = globalStatic.transform;
		SpawnObject(barrel, chanceBarrel);
		if (GetComponent<RandomEnemy>())
			GetComponent<RandomEnemy>().SpawnEnemy(x, y);
	}

	private void SpawnRapmDown(bool flag)
	{
		FillUnderFloor(-1);
		y++;
		GameObject obj = Instantiate(oneRampDown, new Vector3(x, y, 0), Quaternion.identity);
		if (!flag)
			obj.transform.eulerAngles = new Vector3(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z - 90);
		obj.transform.parent = globalStatic.transform;
	}

	private void SpawnRampUp(bool flag)
	{
		FillUnderFloor(0);
		GameObject obj = Instantiate(oneRampUp, new Vector3(x, y, 0), Quaternion.identity);
		if (!flag)
			obj.transform.eulerAngles = new Vector3(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y, obj.transform.eulerAngles.z + 90);
		obj.transform.parent = globalStatic.transform;
		y--;
	}

	private void SpawnTrap(bool flag, int count)
	{
		if (trapMaxWight <= 0)
			trapMaxWight = 1;
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
			{
				if (flag)
					x++;
				else
					x--;
			}
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

	private void RandomLights(bool flag)
	{
		if (GetComponent<RandomProps>())
			GetComponent<RandomProps>().CreateLight(x, y + 3, flag);
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

	private void ReloadMap(bool flag)
	{
		flag2 = flag;
		player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
		if (flag)
		{
			start_x = (int)player.transform.position.x - 3;
			start_y = (int)player.transform.position.y - 2;
		}
		else
		{
			start_x = (int)player.transform.position.x + 3;
			start_y = (int)player.transform.position.y - 2;
		}

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

	private void ContinueMap(bool flag)
	{
		if (flag && player.transform.position.x + 10 >= x)
			Generate(flag, 10, 1);
		else if (!flag && player.transform.position.x - 10 <= x)
			Generate(flag, 10, -1);
	}

	bool flag2;

	[Header("Генерация новой карты")]
	public bool generateMap;
	public float player_pos_x = 0;
	public float player_check_pos = 0;
	private void Update()
	{
		/*
		if (player_pos_x + 10 <  && ForwardRandomMap != "right")
		{
			ForwardRandomMap = "right";
			ReloadMap(true);
		}
		if (ForwardRandomMap != "left")
		{
			ForwardRandomMap = "left";
			ReloadMap(false);
		}
			*/
		if (ForwardRandomMap == "right")
		{
			player_check_pos = player.transform.position.x;
			if (player_check_pos > player_pos_x)
				player_pos_x = player.transform.position.x;
			else if (player_check_pos + 10 <= player_pos_x)
			{
				ForwardRandomMap = "left";
				ReloadMap(false);
				flag2 = false;
			}
		}
		else
		{
			player_check_pos = player.transform.position.x;
			if (player_check_pos < player_pos_x)
				player_pos_x = player.transform.position.x;
			else if (player_check_pos - 10 >= player_pos_x)
			{
				ForwardRandomMap = "right";
				ReloadMap(true);
				flag2 = true;
			}
		}

		ContinueMap(flag2);
	}
}
