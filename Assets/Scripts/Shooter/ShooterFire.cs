using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShooterFire : MonoBehaviour
{
    // Weapon Stats
    public Transform m_FireTransform;
    public float m_MinLaunchForce = 10f;
    public float m_MaxLaunchForce = 30f;
    public float m_MaxChargeTime = 0.75f;

    
    private float m_CurrentLaunchForce;
    private float m_ChargeSpeed;
    private bool m_Fired;

    

    // Different Shell types from which to choose
    public  Rigidbody m_GreenShell;
    public  Rigidbody m_RedShell;
    public  Rigidbody m_BlueShell;

    // Display of current shell type
    public MeshRenderer m_AmmoTypeDisplay;

    // Display text fields for ammo stock
    public Text textGreenAmmo;
    public Text textRedAmmo;
    public Text textBlueAmmo;

    // Current shell type to be fired
    [HideInInspector]
    public Rigidbody m_currentShell;

    
    
    // Player Controls
    private string m_FireButton;
    private string m_RedShellSelectionButton;
    private string m_GreenShellSelectionButton;
    private string m_BlueShellSelectionButton;

    // Material
    public Material BlueMaterial;
    public Material GreenMaterial;
    public Material RedMaterial;

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
        m_AmmoTypeDisplay.material = BlueMaterial;

        textRedAmmo.text = PlayerStats.NbRedAmmo.ToString();
        textGreenAmmo.text = PlayerStats.NbRedAmmo.ToString();
        textBlueAmmo.text = PlayerStats.NbBlueAmmo.ToString();
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

        // Chnage ammo type on button down
        if (Input.GetButtonDown(m_RedShellSelectionButton))
        {
            ChangeAmmo(m_RedShell);
            m_AmmoTypeDisplay.material = RedMaterial;
        }
        if (Input.GetButtonDown(m_GreenShellSelectionButton))
        {
            ChangeAmmo(m_BlueShell);
            m_AmmoTypeDisplay.material = BlueMaterial;
        }
        if (Input.GetButtonDown(m_BlueShellSelectionButton))
        {
            ChangeAmmo(m_GreenShell);
            m_AmmoTypeDisplay.material = GreenMaterial;
            
        }
    }

    private void ChangeAmmo(Rigidbody shell)
    {
        m_currentShell = shell;
    }

    private void Fire()
    {
        // Instantiate and launch the shell.
        bool canFire =false;
        if (m_currentShell == m_BlueShell && PlayerStats.NbBlueAmmo > 0)
        {
            PlayerStats.NbBlueAmmo--;
            textBlueAmmo.text = PlayerStats.NbBlueAmmo.ToString();
            canFire = true;
        }
        else if(m_currentShell == m_RedShell && PlayerStats.NbRedAmmo > 0)
        {
            PlayerStats.NbRedAmmo--;
            textRedAmmo.text = PlayerStats.NbRedAmmo.ToString();
            canFire = true;
        }
        else if(m_currentShell == m_GreenShell && PlayerStats.NbGreenAmmo > 0)
        {
            PlayerStats.NbGreenAmmo--;
            textGreenAmmo.text = PlayerStats.NbGreenAmmo.ToString();
            canFire = true;
        }

        // If we have enough ammo, actually fire a shell
        if(canFire == true)
        {
            m_Fired = true;
            Rigidbody shellInstance = Instantiate(m_currentShell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
            shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;
            m_CurrentLaunchForce = m_MinLaunchForce;
        }
        
    }
}
