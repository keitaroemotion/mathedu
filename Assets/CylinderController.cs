using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CylinderController : MonoBehaviour {

    private float DELTA_MINIMUM = 2;
    private float x;
    private float y;
   
    private Vector3 pos;

    void Start () {
        pos    = Input.mousePosition;
        this.x = pos.x;              
        this.y = pos.y;
    }
  
    void RotateX(float dx){
        if(System.Math.Abs(dx) > DELTA_MINIMUM){
            transform.Rotate(0, 0, dx);    
        }

        if (Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(0, 0, -1);    
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(0, 0, 1);    
        }
    }

    void RotateY(float dy){

        if(System.Math.Abs(dy) > DELTA_MINIMUM){
            transform.Rotate(dy, 0, 0);    
        }

        if (Input.GetKey(KeyCode.UpArrow)){
            transform.Rotate(1, 0, 0);    
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.Rotate(-1, 0, 0);    
        }
    }

    Vector3 GetDeltas(){
        pos     = Input.mousePosition;
        var dx  = this.x - pos.x;
        var dy  = this.y - pos.y;
        this.x  = pos.x;
        this.y  = pos.y;
        Debug.Log(string.Format("x: {0}, y: {1}, dx: {2}, dy: {3}", x, y, dx, dy));
        return new Vector3(dx, dy, 0);
    }

    void Update () {
        var delta = GetDeltas();

        RotateX(delta.x);        
        RotateY(delta.y);
    }
}
