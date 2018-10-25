using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour {

    void Start () {
              
    }
    
    void RotateX(){
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(0, 0, -1);    
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(0, 0, 1);    
        }
    }

    void RotateY(){
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.Rotate(1, 0, 0);    
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.Rotate(-1, 0, 0);    
        }
    }

    void Update () {
        RotateX();        
        RotateY();
    }
}
