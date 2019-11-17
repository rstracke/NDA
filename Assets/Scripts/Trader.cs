using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class Trader : MonoBehaviour
{
	bool trade;

	public GameObject CanvasPanel;
	public GameObject CanvasStart;
	public GameObject CanvasAutors;
	public GameObject CanvasMagazin;

	public GameObject CanvasText;

	private void Start()
	{
		DisplayOff();
	}

	bool one;

	private void Update()
	{
		if (trade)
		{
			if (!CanvasMagazin.activeSelf && Input.GetKeyDown(KeyCode.E))
				MagazinOn();
			else if (CanvasMagazin.activeSelf && Input.GetKeyDown(KeyCode.Escape))
				DisplayOn();
			if (!CanvasAutors.activeSelf && Input.GetKeyDown(KeyCode.F))
				AutorsOn();
			else if (!CanvasAutors.activeSelf && Input.GetKeyDown(KeyCode.Escape))
				DisplayOn();

			if (CanvasMagazin.activeSelf)
			{
				Debug.Log("покупка на один один");
				if (Input.GetKeyDown(KeyCode.Alpha1) && !one)
				{
					Debug.Log("покупка на один");
					if (LocalPlayer.Singleton.points < 5000)
					{
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().text = "Недостаточно средств";
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().color = Color.yellow;
					}
					else
					{
						one = true;
						LocalPlayer.Singleton.points -= 5000;
						LocalPlayer.Singleton.GetComponent<RandomMap>().trap = 0;
					}
					//отключение магнитов
				}
				if (Input.GetKeyDown(KeyCode.Alpha2))
				{
					CanvasText.GetComponent<FadeIn>().GetComponent<Text>().text = "Неa";
					CanvasText.GetComponent<FadeIn>().GetComponent<Text>().color = Color.yellow;
				}
				if (Input.GetKeyDown(KeyCode.Alpha3))
				{
					if (LocalPlayer.Singleton.points < 100)
					{
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().text = "Недостаточно средств";
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().color = Color.yellow;
					}
					else
					{

						LocalPlayer.Singleton.points -= 100;
						LocalPlayer.Singleton.player.GetComponent<PlatformerCharacter2D>().m_MaxSpeed += 0.5f;
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().text = "Продано, тому роботу который рядом";
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().color = Color.yellow;
					}
				}
				if (Input.GetKeyDown(KeyCode.Alpha4))
				{
					if (LocalPlayer.Singleton.points < 100)
					{
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().text = "Недостаточно средств";
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().color = Color.yellow;
					}
					else
					{

						LocalPlayer.Singleton.points -= 100;
						LocalPlayer.Singleton.player.GetComponent<PlayerInfo>().HP += 10f;
						LocalPlayer.Singleton.player.GetComponent<PlayerInfo>().SaveHP += 10f;
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().text = "Продано";
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().color = Color.yellow;
					}
				}

				if (Input.GetKeyDown(KeyCode.Alpha5))
				{
					if (LocalPlayer.Singleton.points < 100)
					{
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().text = "Недостаточно средств";
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().color = Color.yellow;
					}
					else
					{

						LocalPlayer.Singleton.points -= 100;
						LocalPlayer.Singleton.player.GetComponent<PlayerInfo>().DAMAGE += 1f;
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().text = "Продано";
						CanvasText.GetComponent<FadeIn>().GetComponent<Text>().color = Color.yellow;
					}
				}
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Player")
		{
			trade = true;
			DisplayOn();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.name == "Player")
		{
			trade = false;
			DisplayOff();
		}
	}

	private void DisplayOff()
	{
		CanvasPanel.SetActive(false);
		CanvasStart.SetActive(true);
		CanvasAutors.SetActive(false);
		CanvasMagazin.SetActive(false);
	}

	private void DisplayOn()
	{
		CanvasPanel.SetActive(true);
		CanvasStart.SetActive(true);
		CanvasAutors.SetActive(false);
		CanvasMagazin.SetActive(false);
	}

	private void MagazinOn()
	{
		CanvasStart.SetActive(false);
		CanvasMagazin.SetActive(true);
	}

	private void AutorsOn()
	{
		CanvasStart.SetActive(false);
		CanvasAutors.SetActive(true);
	}
}
