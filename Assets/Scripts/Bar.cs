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
    Image icon;

    // Update is called once per frame
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        text = transform.GetChild(0).GetComponent<Text>();
        icon = transform.GetChild(1).GetComponent<Image>();
    }
    void Update()
    {
        if((text.text == "" || text.text == "New Text") && window != null)
        {
            text.text = window.name;
            icon.sprite = window.icon;
        }
    }
    public void OpenYourWindow()
    {
        window.OpenWindow();
    }
}
