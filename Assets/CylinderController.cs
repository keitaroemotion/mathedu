using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CylinderController : MonoBehaviour {

    private int   objectIndex;
    private float delta;

    private List<string> objects = new List<string>{"Cylinder", "Cube", "Capsule"};

    ObjectController GetObjectController(){
        return GameObject.Find("Object").GetComponent<ObjectController>();
    }

    void Start(){
        delta       = 0;
        objectIndex = 0;
    }

    void Update () {
        delta += Time.deltaTime;
        if(Input.GetKey(KeyCode.X) && delta > 0.25f){
            objectIndex += 1;                            

            if(objectIndex == objects.Count){
                objectIndex = 0;
            }

            delta = 0;
        }

        Debug.Log(string.Format("index: {0} cnt: {1} delta: {2}", objectIndex, objects.Count, delta));
        GetObjectController().Rotate(GameObject.Find(objects[objectIndex]));
    }
}
