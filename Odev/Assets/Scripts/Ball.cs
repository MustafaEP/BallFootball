using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody _rb;

    [SerializeField]
    public GameObject player1;
    
    [SerializeField]
    public GameObject player2;

    public bool _ballControlZ;
    public bool _ballControlX;

    public int _player1Skor;
    public int _player2Skor;
    
    
    Vector3 _inComingVelocity1;
    
    Vector3 _inComingVelocity2;
    



    float _ballForce = 50f;

    
    int doubleHit;
    

    float _angle;
    float _angle2;

    public AudioSource goalVoice;

    GUIStyle _style = new GUIStyle();

    

    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player1")
        {
            
            _angle = Vector3.Angle(_rb.transform.position - player1.transform.position, Vector3.forward);
            _angle2 = Vector3.Angle(_rb.transform.position - player1.transform.position, Vector3.right);
        
            float sin = Mathf.Sin((_angle/180) * Mathf.PI);
            float cos = Mathf.Cos((_angle/180) * Mathf.PI);
            float sin2 = Mathf.Sin((_angle2/180) * Mathf.PI);
            float cos2 = Mathf.Cos((_angle2/180) * Mathf.PI);
            
            
            if(doubleHit == 2)
            {
                _rb.velocity = -2f * _rb.velocity;
                doubleHit++;
            }
            else{
                doubleHit++;

                if((player1.transform.position.x < _rb.position.x) && (_inComingVelocity1.x < 0) && (_rb.velocity.x < 0))
                {   
                    _rb.velocity = new Vector3(0, 0, 0);
                    _rb.AddForce(new Vector3(5f, 2f, 0));
                }
                else if((player1.transform.position.x > _rb.position.x) && (_inComingVelocity1.x > 0) && (_rb.velocity.x > 0))
                {   
                    _rb.velocity = new Vector3(0, 0, 0);
                    _rb.AddForce(new Vector3(-5f, 2f, 0));
                }



                if(_inComingVelocity1.x < 0){
                    _rb.AddForce(new Vector3(
                        _inComingVelocity1.x * sin
                        , 0, 
                        -1f *_inComingVelocity1.x * cos 
                        ) * 
                        _ballForce
                    );                    
                }
                else{
                    _rb.AddForce(new Vector3(
                        _inComingVelocity1.x * sin 
                        , 0, 
                        _inComingVelocity1.x * cos 
                        ) * 
                        _ballForce
                );                    
                }
                if(_inComingVelocity1.z < 0){
                    _rb.AddForce(new Vector3(
                        -1f * _inComingVelocity1.z * cos2
                        , 0, 
                        _inComingVelocity1.z * sin2 
                        ) * 
                        _ballForce
                );                    
                }
                else{
                    _rb.AddForce(new Vector3(
                        _inComingVelocity1.z * cos2 
                        , 0, 
                        _inComingVelocity1.z * sin2
                        ) * 
                        _ballForce
                    );                    
                }
            }
            
            Debug.Log(_rb.velocity);

        }
        if(collision.collider.tag == "Player2")
        {
            
            
            _angle = Vector3.Angle(_rb.transform.position - player2.transform.position, Vector3.forward);
            _angle2 = Vector3.Angle(_rb.transform.position - player2.transform.position, Vector3.right);
        
            float sin = Mathf.Sin((_angle/180) * Mathf.PI);
            float cos = Mathf.Cos((_angle/180) * Mathf.PI);
            float sin2 = Mathf.Sin((_angle2/180) * Mathf.PI);
            float cos2 = Mathf.Cos((_angle2/180) * Mathf.PI);
            
            
            if(doubleHit == 2)
            {

                _rb.velocity = -2f * _rb.velocity;
                
                doubleHit++;
            }
            else{
                doubleHit ++;

                if((player2.transform.position.x < _rb.position.x) && (_inComingVelocity2.x < 0) && (_rb.velocity.x < 0))
                {   
                    _rb.velocity = new Vector3(0, 0, 0);
                    _rb.AddForce(new Vector3(5f, 2f, 0));
                }
                else if((player2.transform.position.x > _rb.position.x) && (_inComingVelocity2.x > 0) && (_rb.velocity.x > 0))
                {   
                    _rb.velocity = new Vector3(0, 0, 0);
                    _rb.AddForce(new Vector3(-5f, 2f, 0));
                }



                if(_inComingVelocity2.x < 0){
                    _rb.AddForce(new Vector3(
                        _inComingVelocity2.x * sin
                        , 0, 
                        -1f *_inComingVelocity2.x * cos 
                        ) * 
                        _ballForce
                    );                    
                }
                else{
                    _rb.AddForce(new Vector3(
                        _inComingVelocity2.x * sin 
                        , 0, 
                        _inComingVelocity2.x * cos 
                        ) * 
                        _ballForce
                );                    
                }
                if(_inComingVelocity2.z < 0){
                    _rb.AddForce(new Vector3(
                        -1f * _inComingVelocity2.z * cos2
                        , 0, 
                        _inComingVelocity2.z * sin2 
                        ) * 
                        _ballForce
                );                    
                }
                else{
                    _rb.AddForce(new Vector3(
                        _inComingVelocity2.z * cos2 
                        , 0, 
                        _inComingVelocity2.z * sin2
                        ) * 
                        _ballForce
                    );                    
                }
            }
            
           
        Debug.Log(_rb.velocity);
        }

        
        
    }

    

    // Start is called before the first frame update
    void Start()
    {
        _ballControlZ = true;
        _ballControlX = true;
        transform.position = new Vector3(0f, 0.75f, 0f);
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = new Vector3(0f, 0f, 0f);
        
        goalVoice = GetComponent<AudioSource>();

        _style.alignment = TextAnchor.MiddleCenter;
        _style.fontSize = 36;
        _style.fontStyle = FontStyle.Italic;
        
        doubleHit = 1;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Z Ekseni
        if(_ballControlZ == true)
        {
            if (transform.position.z >= 3.75f)
            {
                _rb.velocity = new Vector3(_rb.velocity.x, 0 , -1f *_rb.velocity.z);
                _ballControlZ = false;
            }
            else if (transform.position.z <= -4.10f)
            {
                _rb.velocity = new Vector3(_rb.velocity.x, 0, -1f *_rb.velocity.z);        
                _ballControlZ = false;
            }
        }
        if((transform.position.z < 3.75f) && (transform.position.z > -3.75f))
        {
            _ballControlZ = true;
        }
        //X Ekseni
        if(_ballControlX == true)
        {
            if (transform.position.x >= 6.4f)
            {
                _rb.velocity = new Vector3(-1f * _rb.velocity.x, 0 , _rb.velocity.z);
                _ballControlX = false;
            }
            else if (transform.position.x <= -6.4f)
            {
                _rb.velocity = new Vector3(-1f * _rb.velocity.x, 0, _rb.velocity.z);        
                _ballControlX = false;
            }
        }
        if((transform.position.x < 6.40f) && (transform.position.x > -6.40f))
        {
            _ballControlX = true;
            if((transform.position.z <= 0.781f) && (transform.position.z >= -0.97f))
                _ballControlX = false;
        }

        if(transform.position.x < -7.1)
        {
            goalVoice.Play();
            _player2Skor++;
            Start();
        }
            
        if(transform.position.x > 7.1)
        {
            goalVoice.Play();
            _player1Skor++;
            Start();
        }
        _inComingVelocity1 = player1.GetComponent<Player1Control>()._player1Velocity;
        _inComingVelocity2 = player2.GetComponent<Player2Control>()._player2Velocity;   
    }

     private void OnGUI()
    {
        string scoreText1 = "Player1 : " + _player1Skor;
        
        GUI.Box(new Rect(40,40,200,100), scoreText1, _style);

        string scoreText2 = "Player2 : " + _player2Skor;

        GUI.Box(new Rect(Screen.currentResolution.width - 240, 40, 200, 100), scoreText2, _style);
  
    }

}
