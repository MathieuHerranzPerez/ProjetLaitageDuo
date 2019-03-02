using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody m_Shell;

    public Transform m_FireTransform;
    public float m_MinLaunchForce = 10f;
    public float m_MaxLaunchForce = 30f;
    public float m_MaxChargeTime = 0.75f;
    private float m_CurrentLaunchForce;
    private float m_ChargeSpeed;
    private bool m_Fired;

    private string m_FireButton;

    // Start is called before the first frame update
    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
    }

    private void Start()
    {
        m_FireButton = "Fire";

        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }

    private void Update()
    {
        // Track the current state of the fire button and make decisions based on the current launch force.
        
        if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
        {
            m_CurrentLaunchForce = m_MaxLaunchForce;
            Fire();
        }
        else if (Input.GetButtonDown(m_FireButton))
        {
            m_Fired = false;
            m_CurrentLaunchForce = m_MinLaunchForce;
        }
        else if (Input.GetButton(m_FireButton) && !m_Fired)
        {
            m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;
        }
        else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
        {
            Fire();
        }
    }

    private void Fire()
    {
        // Instantiate and launch the shell.
        m_Fired = true;

        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;
        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}
