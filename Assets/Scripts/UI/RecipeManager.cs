using UnityEngine;

public class RecipeManager : MonoBehaviour
{

    public static int[] RecipeRed = new int[4];
    public static int[] RecipeGreen = new int[4];
    public static int[] RecipeBlue = new int[4];

    public static int bonusAmo;

    public int[] startRecipeRed = new int[4];
    public int[] startRecipeGreen = new int[4];
    public int[] startRecipeBlue = new int[4];

    public int startBonusAmo;

    // Start is called before the first frame update
    void Start()
    {
        RecipeRed = startRecipeRed;
        RecipeGreen = startRecipeGreen;
        RecipeBlue = startRecipeBlue;
        bonusAmo = startBonusAmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // function called each time ressource counter is incremented
    static public void ressourcesUpdated()
    {
        if(CheckRecipe(RecipeRed))
        {
            PlayerStats.NbRedAmo += bonusAmo;
            Debug.Log("red munitions + 5 : " + PlayerStats.NbRedAmo);
        }
        if (CheckRecipe(RecipeGreen))
        {
            PlayerStats.NbGreenAmo += bonusAmo;
            Debug.Log("green munitions + 5 : " + PlayerStats.NbGreenAmo );
        }
        if (CheckRecipe(RecipeBlue))
        {
            PlayerStats.NbBlueAmo += bonusAmo;
            Debug.Log("blue munitions + 5 : " + PlayerStats.NbBlueAmo);
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
