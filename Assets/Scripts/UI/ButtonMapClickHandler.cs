using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMapClickHandler : MonoBehaviour
{

    public KeyCode key;
    public TPManager tpManager;
    private Button button;

    // Start is called before the first frame update

    void Awake()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            FadeToColor(button.colors.pressedColor);
            //  action when the button is clicked
            tpManager.TPtoNorth();
        }
        else if(Input.GetKeyUp(key))
        {
            FadeToColor(button.colors.normalColor);
        }
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, button.colors.fadeDuration, true, true);

    }

}
