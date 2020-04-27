using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    public Slider slider;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        panel.GetComponent<RectTransform>().anchorMin = new Vector2(panel.GetComponent<RectTransform>().anchorMin.x, 2.1f*slider.value - 2.1f);
        panel.GetComponent<RectTransform>().anchorMax = new Vector2(panel.GetComponent<RectTransform>().anchorMax.x, panel.GetComponent<RectTransform>().anchorMin.y+3);
    }
}
