using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Button northBtn;
    public Button southBtn;
    public Button eastBtn;
    public Button westBtn;

    public TPManager tpManager;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // tp control
        checkControllerButton("controllerYbtn", northBtn);
        checkControllerButton("controllerAbtn", southBtn);
        checkControllerButton("controllerBbtn", eastBtn);
        checkControllerButton("controllerXbtn", westBtn);

        // select a ressource button
    }

    void checkControllerButton(string buttonController,Button buttonUI)
    {
        if (Input.GetButtonDown(buttonController))
        {
            FadeToColor(buttonUI.colors.pressedColor,buttonUI);
            //  action when the button is clicked
            buttonUI.onClick.Invoke();
        }
        else if (Input.GetButtonUp(buttonController))
        {
            FadeToColor(buttonUI.colors.normalColor,buttonUI);
        }
    }

    void FadeToColor(Color color,Button buttonUI)
    {
        Graphic graphic = buttonUI.GetComponent<Graphic>();
        graphic.CrossFadeColor(color, buttonUI.colors.fadeDuration, true, true);

    }
}
