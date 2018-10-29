using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shape : MonoBehaviour {

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

    private KeyCode SwapCommandL = KeyCode.L;
    private KeyCode SwapCommandR = KeyCode.R;

    bool SwapEventTriggeredR(){
        if(Input.GetKey(KeyCode.R) && delta > 0.25f){
	    return true;
	}

	return false;
    }

    bool SwapEventTriggeredL(){
        if(Input.GetKey(KeyCode.L) && delta > 0.25f){
	    return true;
	}

	return false;
    }

    void Update () {
        delta += Time.deltaTime;
        if(SwapEventTriggeredL()){
            objectIndex += 1;                            

            if(objectIndex == objects.Count){
                objectIndex = 0;
            }

            delta = 0;
        }

        if(SwapEventTriggeredR()){
            objectIndex -= 1;                            

            if(objectIndex == -1){
                objectIndex = objects.Count-1;
            }

            delta = 0;
        }

        Debug.Log(string.Format("index: {0} cnt: {1} delta: {2}", objectIndex, objects.Count, delta));
        GetObjectController().Rotate(GameObject.Find(objects[objectIndex]));
    }
}
