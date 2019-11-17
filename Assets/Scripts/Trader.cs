using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
	bool trade;
	private void Update()
	{
		if (trade)
		{

		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Player")
			trade = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.name == "Player")
			trade = false;
	}
}
