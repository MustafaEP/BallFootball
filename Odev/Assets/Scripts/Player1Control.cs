using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Control : MonoBehaviour
{

    public Rigidbody _rb;

    private float _speed = 20f;
    private float _maxSpeed = 5f;

    public Vector3 _player1Velocity;
    
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

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

        _player1Velocity = _rb.velocity;
       

        if(_rb.position.y >= 2f)
        {
            _rb.position = new Vector3(_rb.position.x, 2f, _rb.position.z);
        }
        

    }
}
