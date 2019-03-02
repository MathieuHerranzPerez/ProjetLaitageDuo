
public class GreenEnemy : Enemy
{
    public override void TakeDamageFormCurrentBullet(float amount, ShellExplosion bullet)
    {
        base.TakeDamageFormCurrentBullet(amount, bullet);
        if (bullet.IsGreen())
        {
            TakeDamage(amount);
        }
    }
}
