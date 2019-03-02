using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    public EnemyStats stats;

    [Header("Animations")]
    public GameObject deathEffect;
    public GameObject hitEffect;

    [Header("Health UI")]
    [SerializeField]
    private GameObject healthBarCanvas;
    [SerializeField]
    private Image healthBar;

    void Start()
    {
        stats.currentHP = stats.maxHP;
    }

    //public abstract void TakeDamageFormCurrentBullet(float amount, ShellExplosion bullet);

    protected void TakeDamage(float amount)
    {
        healthBarCanvas.SetActive(true);

        stats.currentHP -= amount;

        healthBar.fillAmount = stats.currentHP / stats.maxHP;

        if(stats.currentHP <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        // add money to the user
        PlayerStats.Money += stats.worth;
        // increment nb enemies killed
        ++ PlayerStats.NbEnemyKilled;

        // effect on death
        // GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 3f);

        Destroy(gameObject);
    }
}
