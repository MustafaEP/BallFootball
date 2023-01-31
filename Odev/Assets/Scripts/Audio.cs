using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private static Audio _instance ;

 
    void Awake()
    {
        if(!_instance)
            _instance = this ;
        else
            Destroy(this.gameObject) ;

        DontDestroyOnLoad(this.gameObject) ;
    }

    

    

}
