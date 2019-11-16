using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
	public GameObject barrel;
	public GameObject oneAcidUp;
	public GameObject oneAcidDown;
	public GameObject oneFloor;
	public GameObject oneRampLeft;
	public GameObject oneRampRight;
	public GameObject oneWallLeft;
	public GameObject oneWallRight;

	GameObject[] objects = new GameObject[8];

	void Start()
    {
		objects[0] = barrel;
		objects[1] = oneAcidUp;
		objects[2] = oneAcidDown;
		objects[3] = oneFloor;
		objects[4] = oneRampLeft;
		objects[5] = oneRampRight;
		objects[6] = oneWallLeft;
		objects[7] = oneWallRight;
		MapRandom();
    }

	public float start_x, start_y;

	private void MapRandom()
	{
		for (int x = 0; x < 100; x++)
		{
			GameObject obj = Instantiate(objects[Random.Range(0, 6)]);
			obj.transform.position = new Vector3(x, 0, 0);
		}

	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			MapRandom();
		}
	}
}
