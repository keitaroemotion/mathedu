using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CylinderController : MonoBehaviour {

    private int   objectIndex;
    private float delta;

    private List<string> objects = new List<string>{"Cylinder", "Cube"};

    ObjectController GetObjectController(){
        return GameObject.Find("Object").GetComponent<ObjectController>();
    }

    void Start(){
        this.delta       = 0;
        this.objectIndex = 0;
    }

    void Update () {
        this.delta += Time.deltaTime;
        if(Input.GetKey(KeyCode.X) && delta > 0.25f){
            this.objectIndex += 1;                            

            if(this.objectIndex == objects.Count){
                this.objectIndex = 0;
            }

            this.delta = 0;
        }

        Debug.Log(string.Format("index: {0} cnt: {1} delta: {2}", this.objectIndex, objects.Count, this.delta));
        GetObjectController().Rotate(GameObject.Find(objects[this.objectIndex]));
    }
}
