using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Window : MonoBehaviour
{
    public bool open;
    public bool minimized;
    public Sprite icon;
    [HideInInspector]
    public RectTransform rect;
    [HideInInspector]
    public RectTransform display;
    [HideInInspector]
    public RectTransform grabBar;
    // Start is called before the first frame update
    void Awake()
    {
        rect = transform.GetComponent<RectTransform>();
        display = transform.GetChild(0).GetComponent<RectTransform>();
        grabBar = display.GetChild(0).GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        display.gameObject.SetActive(open);
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
}
