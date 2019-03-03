using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance;
    // Audio Source when completing a recipe and adding ammo of player
    public static AudioSource AmmoAudio;
    public AudioSource ammoAudio = null;

    public static int[] RecipeRed = new int[4];
    public static int[] RecipeGreen = new int[4];
    public static int[] RecipeBlue = new int[4];
    public static int bonusAmo;


    public static Button[] patternButton1 = new Button[4];
    public static Button[] patternButton2 = new Button[3];
    public static Button[] patternButton3 = new Button[3];
    public static Text notifier;

    public static Color RedColor;
    public static Color GreenColor;
    public static Color BlueColor;


    public int[] startRecipeRed = new int[4];
    public int[] startRecipeGreen = new int[4];
    public int[] startRecipeBlue = new int[4];
    public int startBonusAmmo;

    public Button[] startPatternButton1 = new Button[4];
    public Button[] startPatternButton2 = new Button[3];
    public Button[] startPatternButton3 = new Button[3];

    public Text startNotifier;

    public Color redColor;
    public Color greenColor;
    public Color blueColor;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        RecipeRed = startRecipeRed;
        RecipeGreen = startRecipeGreen;
        RecipeBlue = startRecipeBlue;
        notifier = startNotifier;
        bonusAmo = startBonusAmmo;

        patternButton1 = startPatternButton1;
        patternButton2 = startPatternButton2;
        patternButton3 = startPatternButton3;

        RedColor = redColor;
        GreenColor = greenColor;
        BlueColor = blueColor;

        AmmoAudio = ammoAudio;
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
            AmmoAudio.Play();
            Notify("red");
        }
        if (CheckRecipe(RecipeGreen))
        {
            PlayerStats.NbGreenAmmo += bonusAmo;
            AmmoAudio.Play();
            Notify("green");
        }
        if (CheckRecipe(RecipeBlue))
        {
            PlayerStats.NbBlueAmmo += bonusAmo;
            AmmoAudio.Play();
            Notify("blue");
        }

    }

    private static void Notify(string color)
    {
        string textToDisplay = "x" + bonusAmo + " " + color + " ammo created !";
        if (color.CompareTo("red") == 0)
            notifier.color = RedColor;
        else if (color.CompareTo("blue") == 0)
            notifier.color = BlueColor;
        else if (color.CompareTo("green") == 0)
            notifier.color = GreenColor;

        notifier.text = textToDisplay;

        Instance.lauchTimer();


    }

    public void lauchTimer()
    {
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        float t = 0f;
        while(t < 1f)
        {
            t += Time.deltaTime;
            yield return null;
        }
        notifier.text = "";

    }

    static bool CheckRecipe(int[] recipe)
    {
        int[] playerRessources = { PlayerStats.NbRound, PlayerStats.NbStar, PlayerStats.NbTriangle, PlayerStats.NbSquare };
        if ((PlayerStats.NbRound - recipe[0]) >= 0 && (PlayerStats.NbStar - recipe[1]) >= 0 && (PlayerStats.NbTriangle - recipe[2]) >= 0 && (PlayerStats.NbSquare - recipe[3]) >= 0)
        {
           
            PlayerStats.NbRound -= recipe[0];
            PlayerStats.NbStar -= recipe[1];
            PlayerStats.NbTriangle -= recipe[2];
            PlayerStats.NbSquare -= recipe[3];
            return true;
        }

        return false;
    }
}
