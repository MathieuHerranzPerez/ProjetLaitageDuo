using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ShooterMotor))]
public class ShooterController : MonoBehaviour
{

    [SerializeField] private float Speed = 5f;
    [SerializeField] private float LookSensitivity = 3f;

    private ShooterMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<ShooterMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _motorHorizontal = transform.right * _xMov;
        Vector3 _motorVetical = transform.forward * _zMov;

        Vector3 _velocity = (_motorHorizontal + _motorVetical).normalized * Speed;

        motor.Move(_velocity);

        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * LookSensitivity;

        motor.Rotate(_rotation);
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * LookSensitivity;

        motor.RotateCamera(_cameraRotation);
    }
}
