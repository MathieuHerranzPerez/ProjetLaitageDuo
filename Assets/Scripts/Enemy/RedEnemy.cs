
public class RedEnemy : Enemy
{
    public override void TakeDamageFormCurrentBullet(float amount, ShellExplosion bullet)
    {
        if (bullet.IsRed())
        {
            TakeDamage(amount);
        }
    }
}
