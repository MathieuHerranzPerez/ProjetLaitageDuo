
using UnityEngine;

public class BlueEnemy : Enemy
{
    public override void TakeDamageFormCurrentBullet(float amount, ShellExplosion bullet)
    {
        base.TakeDamageFormCurrentBullet(amount, bullet);
        if (bullet.IsBlue())
        {
            TakeDamage(amount);
            Debug.Log("tuched : " + stats.currentHP); // affD
        }
    }
}
