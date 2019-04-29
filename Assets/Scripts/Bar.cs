using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Window window;
    [HideInInspector]
    public RectTransform rect;
    Text text;

    // Update is called once per frame
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        text = transform.GetChild(0).GetComponent<Text>();
    }
    void Update()
    {
        if((text.text == "" || text.text == "New Text") && window != null)
        {
            text.text = window.name;
        }
    }
    public void OpenYourWindow()
    {
        window.OpenWindow();
    }
}
