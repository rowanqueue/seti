using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    public bool open;
    public bool minimized;
    [HideInInspector]
    public RectTransform rect;
    RectTransform display;
    RectTransform grabBar;


    public Vector2 defaultSize = new Vector2(100, 100);
    //change window size
    [HideInInspector]
    public Vector2 displaySize = new Vector2(100, 100);
    // Start is called before the first frame update
    void Awake()
    {
        rect = transform.GetComponent<RectTransform>();
        display = transform.GetChild(0).GetComponent<RectTransform>();
        grabBar = display.GetChild(0).GetComponent<RectTransform>();
        UpdateSizes();
    }

    // Update is called once per frame
    void Update()
    {
        display.gameObject.SetActive(open);
    }
    public void UpdateSizes()
    {
        display.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, displaySize.x);
        display.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, displaySize.y);
        grabBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, displaySize.x);
    }
    public void OpenWindow()
    {
        open = true;
        minimized = false;
        WindowManager.me.AddWindow(this);
    }
    public void CloseWindow()
    {
        open = false;
        minimized = false;
        WindowManager.me.RemoveWindow(this);
    }
    public void MinimizeWindow()
    {
        open = false;
        minimized = true;
    }
    public void MaximizeWindow()
    {
        //maximize x:-332,y:162,w:764,h:390
        rect.anchoredPosition = new Vector2(-332, 162);
        displaySize = new Vector2(764, 390);
        UpdateSizes();
    }
}
