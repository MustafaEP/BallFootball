using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StopMenu : MonoBehaviour
{
    
    public GameObject _menuObject;

    public bool _menuOpen;

    private float _checkStart;
    private float _time;

    void Start()
    {
        _menuOpen = false;
        _checkStart = -2;
    }

    void Update()
    {
        float inputCancel = Input.GetAxis("Cancel");
        _time = Time.time;
        

        if (inputCancel > 0 && (_menuOpen == true ? (_time - _checkStart) >= 0.005f : (_time - _checkStart) >= 0.6f))
        {   
            if(_menuOpen == true && (_time - _checkStart) >= 0.005f)
            {
                _menuOpen = !_menuOpen;
                _checkStart = Time.time;
            }
            else if(_menuOpen == false && (_time - _checkStart) >= 0.5f)
            {
                _menuOpen = !_menuOpen;
                _checkStart = Time.time;
            }
            
            
        } 
        
        if(_menuOpen == true)
        {
            _menuObject.SetActive(true);
            Time.timeScale = 0.01f;
        }
        else
        {
            _menuObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    
    public void OnClickReturnGame()
    {
        _menuOpen = false;
    }

    public void OnClickGoMainMenu()
    {
         SceneManager.LoadScene("MainMenu");
    }
}
