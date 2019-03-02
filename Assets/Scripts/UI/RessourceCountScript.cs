using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceCountScript : MonoBehaviour
{

    public int value; // 0 : round , 1 : star , 2 : triangle
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (value == 0)
            text.text = PlayerStats.NbRound.ToString();
        else if (value == 1)
            text.text = PlayerStats.NbStar.ToString();
        else if (value == 2)
            text.text = PlayerStats.NbTriangle.ToString();
    }
}
