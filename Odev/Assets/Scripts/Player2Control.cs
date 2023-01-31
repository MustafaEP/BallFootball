using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2Control : MonoBehaviour
{

    
    Rigidbody _rb;

    private float _speed = 20f;
    private float _maxSpeed = 5f;

    public Vector3 _player2Velocity;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal2");
        float verticalInput = Input.GetAxis("Vertical2");

        Vector3 force = new Vector3(horizontalInput, 0, verticalInput);

        _rb.AddForce(force * _speed);

        if(_rb.velocity.x >= _maxSpeed)
            _rb.velocity = new Vector3(_maxSpeed, 0, _rb.velocity.z);
        if(_rb.velocity.z >= _maxSpeed)
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _maxSpeed);    
        if(_rb.velocity.x <= -1f * _maxSpeed)
            _rb.velocity = new Vector3(-1f * _maxSpeed, 0, _rb.velocity.z);
        if(_rb.velocity.z <= -1f * _maxSpeed)
            _rb.velocity = new Vector3(_rb.velocity.x, 0, -1f * _maxSpeed);    

        _player2Velocity = _rb.velocity;
        

        if(_rb.position.y >= 2f)
        {
            _rb.position = new Vector3(_rb.position.x, 2f, _rb.position.z);
        }
    }
}
