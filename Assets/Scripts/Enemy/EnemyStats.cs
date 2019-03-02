using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats
{
    public float maxHP;
    public float currentHP;

    public float damage;
    [Range(1f, 10f)]
    public float moveSpeed;

    public int worth;   // the amount of gold earned by killing

    public bool isBoss;
}
