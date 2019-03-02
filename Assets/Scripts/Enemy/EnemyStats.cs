using UnityEngine;

[System.Serializable]
public class EnemyStats
{
    public float maxHP = 100;
    public float currentHP = 100;

    public int damage = 1;
    [Range(1f, 10f)]
    public float moveSpeed = 2;

    public int worth = 10;   // the amount of gold earned by killing

    public bool isBoss = false;
}
