
public class GreenEnemy : Enemy
{
    public override void TakeDamageFormCurrentBullet(float amount, ShellExplosion bullet)
    {
        if (bullet.IsGreen())
        {
            TakeDamage(amount);
        }
    }
}
