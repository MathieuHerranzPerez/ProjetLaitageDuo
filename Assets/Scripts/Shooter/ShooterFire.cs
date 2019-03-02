using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterFire : MonoBehaviour
{

    public Transform m_FireTransform;
    public float m_MinLaunchForce = 10f;
    public float m_MaxLaunchForce = 30f;
    public float m_MaxChargeTime = 0.75f;
    


    public  Rigidbody m_GreenShell;
    public  Rigidbody m_RedShell;
    public  Rigidbody m_BlueShell;

    private float m_CurrentLaunchForce;
    private float m_ChargeSpeed;
    private bool m_Fired;
    public Rigidbody m_currentShell;
    private string m_FireButton;
    private string m_RedShellSelectionButton;
    private string m_GreenShellSelectionButton;
    private string m_BlueShellSelectionButton;

    // Start is called before the first frame update
    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
    }

    private void Start()
    {
        m_FireButton = "Fire";
        m_RedShellSelectionButton = "Red";
        m_GreenShellSelectionButton = "Green";
        m_BlueShellSelectionButton = "Blue";
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
        m_currentShell = m_BlueShell;
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

        if (Input.GetButtonDown(m_RedShellSelectionButton))
        {
            ChangeAmmo(m_RedShell);
        }
        if (Input.GetButtonDown(m_GreenShellSelectionButton))
        {
            ChangeAmmo(m_GreenShell);
        }
        if (Input.GetButtonDown(m_BlueShellSelectionButton))
        {
            ChangeAmmo(m_BlueShell);
        }
    }

    private void ChangeAmmo(Rigidbody shell)
    {
        m_currentShell = shell;
    }

    private void Fire()
    {
        // Instantiate and launch the shell.
        m_Fired = true;

        Rigidbody shellInstance = Instantiate(m_currentShell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;
        m_CurrentLaunchForce = m_MinLaunchForce;
    }
}
