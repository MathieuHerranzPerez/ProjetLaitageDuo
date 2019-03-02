
public class RedEnemy : Enemy
{
    public override void TakeDamageFormCurrentBullet(float amount, ShellExplosion bullet)
    {
        base.TakeDamageFormCurrentBullet(amount, bullet);
        if (bullet.IsRed())
        {
            TakeDamage(amount);
        }
    }
}
