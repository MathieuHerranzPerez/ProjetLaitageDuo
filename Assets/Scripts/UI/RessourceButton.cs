using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceButton : MonoBehaviour
{
    public int value; // 0 : round , 1 : star , 2 : triangle, 3 : square
    Button button;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void IsClicked()
    {
        Debug.Log("button clicked");
        if (PlayerStats.Money >= 10)
        {
            if (value == 0)
                PlayerStats.NbRound += 1;
            else if (value == 1)
                PlayerStats.NbStar += 1;
            else if (value == 2)
                PlayerStats.NbTriangle += 1;
            else if (value == 3)
                PlayerStats.NbSquare += 1;

            PlayerStats.Money -= 10;

            // check if a recipe is available
            RecipeManager.ressourcesUpdated();

            // disable and check if the combinaison of disabled buttons is a pattern
            button.interactable = false;
            RecipeManager.checkButtonCombinaison();
        }
       
    }


}
