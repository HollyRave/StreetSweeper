using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class HeroMover : MonoBehaviour
{
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speed * Time.deltaTime, _rigidbody.velocity.y, _joystick.Vertical * _speed * Time.deltaTime);
        
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }
}
