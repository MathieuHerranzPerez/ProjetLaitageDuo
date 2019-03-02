using System;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour
{

    public static int[] RecipeRed = new int[4];
    public static int[] RecipeGreen = new int[4];
    public static int[] RecipeBlue = new int[4];
    public static int bonusAmo;

    public static Button[] patternButton1 = new Button[4];
    public static Button[] patternButton2 = new Button[3];
    public static Button[] patternButton3 = new Button[3];

    public int[] startRecipeRed = new int[4];
    public int[] startRecipeGreen = new int[4];
    public int[] startRecipeBlue = new int[4];
    public int startBonusAmo;

    public Button[] startPatternButton1 = new Button[4];
    public Button[] startPatternButton2 = new Button[3];
    public Button[] startPatternButton3 = new Button[3];
    

    // Start is called before the first frame update
    void Start()
    {
        RecipeRed = startRecipeRed;
        RecipeGreen = startRecipeGreen;
        RecipeBlue = startRecipeBlue;
        bonusAmo = startBonusAmo;

        patternButton1 = startPatternButton1;
        patternButton2 = startPatternButton2;
        patternButton3 = startPatternButton3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void checkButtonCombinaison()
    {

        checkCombinaison(patternButton1);
        checkCombinaison(patternButton2);
        checkCombinaison(patternButton3);
    }

    static void checkCombinaison(Button[] pattern)
    {
        int nbButtonLocked = 0;

        foreach (Button btn in pattern)
        {
            if (btn.interactable == false)
                nbButtonLocked++;
        }
        if (nbButtonLocked == pattern.Length)
            foreach (Button btn in pattern)
            {
                btn.interactable = true;
            }
    }

    // function called each time ressource counter is incremented
    static public void ressourcesUpdated()
    {
        if(CheckRecipe(RecipeRed))
        {
            PlayerStats.NbRedAmmo += bonusAmo;
            Debug.Log("red munitions + 5 : " + PlayerStats.NbRedAmmo);
        }
        if (CheckRecipe(RecipeGreen))
        {
            PlayerStats.NbGreenAmmo += bonusAmo;
            Debug.Log("green munitions + 5 : " + PlayerStats.NbGreenAmmo );
        }
        if (CheckRecipe(RecipeBlue))
        {
            PlayerStats.NbBlueAmmo += bonusAmo;
            Debug.Log("blue munitions + 5 : " + PlayerStats.NbBlueAmmo);
        }


    }

    static bool CheckRecipe(int[] recipe)
    {
        int[] playerRessources = { PlayerStats.NbRound, PlayerStats.NbStar, PlayerStats.NbTriangle, PlayerStats.NbSquare };
        Debug.Log("check recipe with " + playerRessources);
        if ((PlayerStats.NbRound - recipe[0]) >= 0 && (PlayerStats.NbStar - recipe[1]) >= 0 && (PlayerStats.NbTriangle - recipe[2]) >= 0 && (PlayerStats.NbSquare - recipe[3]) >= 0)
        {
           
            PlayerStats.NbRound -= recipe[0];
            PlayerStats.NbStar -= recipe[1];
            PlayerStats.NbTriangle -= recipe[2];
            PlayerStats.NbSquare -= recipe[3];
            Debug.Log("Find ! " + playerRessources[0] + " / " + playerRessources[1] + " / " + playerRessources[2] + " / " + playerRessources[3]);
            return true;
        }

        return false;
    }
}
