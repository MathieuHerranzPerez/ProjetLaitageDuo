using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public LayerMask m_EnemyMask;
    public ParticleSystem m_ExplosionParticles;
    public float m_MaxDamage = 100f;
    public float m_ExplosionForce = 1000f;
    public float m_MaxLifeTime = 2f;
    public float m_ExplosionRadius = 5f;
    private string Color;


    private void Start()
    {
        Destroy(gameObject, m_MaxLifeTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Find all the tanks in an area around the shell and damage them.
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius, m_EnemyMask);

        /*foreach (Collider collider in colliders)
        {
            Rigidbody targetRigidBody = collider.GetComponent<Rigidbody>();
            if (!targetRigidBody)
                continue;
            targetRigidBody.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius);
            TankHealth targetHealth = targetRigidBody.GetComponent<TankHealth>();
            if (!targetHealth)
                continue;

            float damage = CalculateDamage(targetRigidBody.position);
            targetHealth.TakeDamage(damage);
        }*/
        m_ExplosionParticles.transform.parent = null;
        m_ExplosionParticles.Play();

        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);
        Destroy(gameObject);
    }


    /*private float CalculateDamage(Vector3 targetPosition)
    {
        // Calculate the amount of damage a target should take based on it's position.
        Vector3 explosionToTarget = targetPosition - transform.position;
        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
        float damage = relativeDistance * m_MaxDamage;
        damage = Mathf.Max(0f, damage);
        return damage;
    }*/

    public bool IsGreen()
    {
        return (Color.Equals("green"));
    }
    public bool IsRed()
    {
        return (Color.Equals("red"));
    }
    public bool IsBlue()
    {
        return (Color.Equals("blue"));
    }
}