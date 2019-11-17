using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
	Text text;
	public bool fadeIn;
	public float speed;

	private void Start()
	{
		text = GetComponent<Text>();
	}
	void Update()
    {
		if (fadeIn)
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - speed);
		else
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + speed);
	}
}
