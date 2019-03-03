using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public static int NbEnemyKilled;
    public static float TimeSurvived;
    public static int NbGreenAmmo;
    public static int NbRedAmmo;
    public static int NbBlueAmmo;
    public static int NbStar;
    public static int NbTriangle;
    public static int NbRound;
    public static int NbSquare;

    public int startMoney = 20;
    public int startLives = 3;
    public int startNbGreenAmmo = 5;
    public int startNbRedAmmo = 5;
    public int startNbBlueAmmo = 5;
    public int startNbStar = 0;
    public int startNbTriangle = 0;
    public int startNbRound= 0;
    public int startNbSquare= 0;

    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        NbGreenAmmo = startNbGreenAmmo;
        NbRedAmmo = startNbRedAmmo;
        NbBlueAmmo = startNbBlueAmmo;
        NbStar = startNbStar;
        NbTriangle = startNbTriangle;
        NbRound = startNbRound;
        NbSquare = startNbSquare;

        NbEnemyKilled = 0;
        TimeSurvived = 0f;
    }


    void Update()
    {
        TimeSurvived += Time.deltaTime;
    }
}
