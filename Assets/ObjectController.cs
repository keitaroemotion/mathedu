using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectController : MonoBehaviour {

    private float DELTA_MINIMUM = 2;
    private float x;
    private float y;
   
    private Vector3 pos;

    void Start () {
        pos    = Input.mousePosition;
        this.x = pos.x;              
        this.y = pos.y;
    }
  
    public void RotateX(GameObject g, float dx){
        if(System.Math.Abs(dx) > DELTA_MINIMUM && Input.GetMouseButton(0)){
            g.transform.Rotate(0, 0, dx);    
        }

        //if (Input.GetKey(KeyCode.RightArrow)){
        //    g.transform.Rotate(0, 0, -1);    
        //}
        //if (Input.GetKey(KeyCode.LeftArrow)){
        //    g.transform.Rotate(0, 0, 1);    
        //}
    }

    public void RotateY(GameObject g, float dy){
        if(System.Math.Abs(dy) > DELTA_MINIMUM && Input.GetMouseButton(0)){
            g.transform.Rotate(dy, 0, 0);    
        }

        if (Input.GetKey(KeyCode.UpArrow)){
            g.transform.Rotate(1, 0, 0);    
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            g.transform.Rotate(-1, 0, 0);    
        }
    }

    public Vector3 GetDeltas(){
        pos     = Input.mousePosition;
        var dx  = this.x - pos.x;
        var dy  = this.y - pos.y;
        this.x  = pos.x;
        this.y  = pos.y;
        // Debug.Log(string.Format("x: {0}, y: {1}, dx: {2}, dy: {3}", x, y, dx, dy));
        return new Vector3(dx, dy, 0);
    }

    public void Rotate (GameObject g) {
        var delta = GetDeltas();

        RotateX(g, delta.x);        
        RotateY(g, delta.y);
    }
}
