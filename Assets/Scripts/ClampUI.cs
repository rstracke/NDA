using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampUI : MonoBehaviour
{
    public Text capture;
    public Image img;
    private Vector2 uiPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (capture != null)
        {
            uiPos = Camera.main.WorldToScreenPoint(transform.position);
            capture.transform.position = uiPos;
        }
          
        if (capture != null)
        {
            uiPos = Camera.main.WorldToScreenPoint(transform.position);
            img.transform.position = uiPos;
        }
    }
}
