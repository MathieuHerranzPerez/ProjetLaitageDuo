using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;
    public float m_TiltSpeed = 180f;

    private string m_TiltAxisName;
    private string m_TurnAxisName;
    private string m_MoveAxisName;
    private Rigidbody m_Rigidbody;
    private float m_TiltInputValue;
    private float m_TurnInputValue;
    private float m_MoveInputValue;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_TiltInputValue = 0f;
        m_TurnInputValue = 0f;
        m_MoveInputValue = 0f;
    }


    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }

    private void Start()
    {
        m_TiltAxisName = "Tilt";
        m_TurnAxisName = "Rotation";
        m_MoveAxisName = "Move";

    }


    private void Update()
    {
        // Store the player's input and make sure the audio for the engine is playing.
        m_TiltInputValue = Input.GetAxis(m_TiltAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
        m_MoveInputValue = Input.GetAxisRaw(m_MoveAxisName);

        Vector3 _mov = transform.right * m_MoveInputValue;
        Vector3 _velocity = (_mov).normalized * m_Speed;
    }

    private void FixedUpdate()
    {
        // Move and turn the tank.
        Move();
        Turn();
        Tilt();
    }


    private void Move()
    {
        // Adjust the position of the tank based on the player's input.
        Vector3 movement = transform.forward * m_MoveInputValue * m_Speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }


    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
    private void Tilt()
    {
        // Adjust the tilt of the tank based on the player's input.
        float tilt = m_TiltInputValue * m_TiltSpeed * Time.deltaTime;
        Quaternion tiltRotation = Quaternion.Euler(tilt, 0f, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * tiltRotation);
    }
}
