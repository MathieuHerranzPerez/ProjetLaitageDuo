﻿using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public static int NbEnemyKilled;
    public static float TimeSurvived;
    public static int NbGreenAmo;
    public static int NbRedAmo;
    public static int NbBlueAmo;

    public int startMoney = 20;
    public int startLives = 3;
    public int startNbGreenAmo = 5;
    public int startNbRedAmo = 5;
    public int startNbBlueAmo = 5;


    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        NbGreenAmo = startNbGreenAmo;
        NbRedAmo = startNbRedAmo;
        NbBlueAmo = startNbBlueAmo;

        NbEnemyKilled = 0;
        TimeSurvived = 0f;
    }

    void Update()
    {
        TimeSurvived += Time.deltaTime;
    }
}
