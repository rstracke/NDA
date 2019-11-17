using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : MonoBehaviour
{
	public GameObject player;

	public static LocalPlayer Singleton;

	private void Awake()
	{
		Singleton = this;
	}

}
