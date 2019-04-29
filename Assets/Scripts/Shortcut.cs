using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortcut : MonoBehaviour
{
    public GameObject myWindow;
    Window window;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject obj = Instantiate(myWindow, transform.parent);
        window = obj.GetComponent<Window>();
    }
    public void OpenMyWindow()
    {
        window.OpenWindow();
    }
}
