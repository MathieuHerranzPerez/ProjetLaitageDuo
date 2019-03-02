using UnityEngine;

public abstract class ShellExplosion : MonoBehaviour
{
    public LayerMask m_EnemyMask;
    public ParticleSystem m_ExplosionParticles;
    public AudioSource m_explosionAudio;

    public float m_MaxDamage = 150f;
    public float m_ExplosionForce = 120f;
    public float m_MaxLifeTime = 2f;
    public float m_ExplosionRadius = 100f;


    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        //Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_EnemyMask);

        //foreach (Collider collider in colliders)
        //{
        //    Rigidbody targetRigidBody = collider.GetComponent<Rigidbody>();
        //    if (!targetRigidBody)
        //        continue;
        //    targetRigidBody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
        //    Enemy target = targetRigidBody.GetComponent<Enemy>();
        //    if (!target)
        //        continue;

        //    Enemy enemy = collider.GetComponent<Enemy>();
        //    if (enemy)
        //    {
        //        float damageAmount = CalculateDamage(enemy.gameObject.transform.position);
        //        enemy.TakeDamageFormCurrentBullet(damageAmount, this);
        //    }
        //}
        //m_ExplosionParticles.transform.parent = null;
        //m_ExplosionParticles.Play();

        //Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
        //Destroy(gameObject);

        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_EnemyMask);

        foreach (Collider collider in colliders)
        {
            Rigidbody targetRigidBody = collider.GetComponent<Rigidbody>();
            if (!targetRigidBody)
                continue;
            targetRigidBody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
            Enemy target = targetRigidBody.GetComponent<Enemy>();
            if (!target)
                continue;

            float damageAmount = CalculateDamage(targetRigidBody.position);
            target.TakeDamageFormCurrentBullet(damageAmount, this);
        }
        m_ExplosionParticles.transform.parent = null;
        m_ExplosionParticles.Play();
        m_explosionAudio.Play();

        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
        Destroy(gameObject);
    }


    private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
        Vector3 explosionToTarget = targetPosition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
        float damage = relativeDistance * m_MaxDamage;
        damage = Mathf.Max(0f, damage);
        return damage;
    }

    public virtual bool IsGreen()
    {
        return false;
    }
    public virtual bool IsRed()
    {
        return false;
    }
    public virtual bool IsBlue()
    {
         return false;
    }
}