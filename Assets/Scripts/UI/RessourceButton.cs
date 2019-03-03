using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RessourceButton : MonoBehaviour
{
    EventSystem eventSystem;
    public int value; // 0 : round , 1 : star , 2 : triangle, 3 : square
    Button button;

    // intern
    private bool isHightlighted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        eventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IsClicked()
    {
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
            eventSystem.SetSelectedGameObject(button.gameObject);
        }
       
    }


}
