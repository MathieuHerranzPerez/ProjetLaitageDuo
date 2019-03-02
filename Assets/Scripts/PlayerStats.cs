using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public static int NbEnemyKilled;

    public int startMoney = 20;
    public int startLives = 3;


    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        Lives = startLives;

        NbEnemyKilled = 0;
    }
}
