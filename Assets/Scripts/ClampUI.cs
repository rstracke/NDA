using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampUI : MonoBehaviour
{
    public Text capture;

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
    }
}
