using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _inputHorizontal;
    private float _inputVertical;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveJoystick();
       
        if (Input.GetMouseButton(0))
        {
            LookJoystick();
        }
    }

    private void MoveJoystick()
    {
        _inputHorizontal = SimpleInput.GetAxis("Horizontal");
        _inputVertical = SimpleInput.GetAxis("Vertical");

        Vector3 movement = new Vector3(_inputHorizontal * _moveSpeed, 0, _inputVertical * _moveSpeed);
        _rigidbody.MovePosition(transform.position + movement * Time.deltaTime);
    }

    private void LookJoystick()
    {
        Vector3 direction = new Vector3(_inputHorizontal, 0, _inputVertical).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }
    
}
