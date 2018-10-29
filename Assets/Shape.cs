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

    bool SwapEventTriggered(KeyCode keycode){
        if(Input.GetKey(keycode) && delta > 0.25f){
	    return true;
	}

	return false;
    }

    void Move(int increment, int comparisonTarget, int assignmentTarget, KeyCode keycode){
       if(SwapEventTriggered(keycode)){
            objectIndex += increment;                            

            if(objectIndex == comparisonTarget){
                objectIndex = assignmentTarget;
            }

            delta = 0;
        }
    }    

    void IncreaseDelta(){
        delta += Time.deltaTime;
    }

    void Update () {
	IncreaseDelta();
	Move(1 , objects.Count, 0,                 KeyCode.L);
	Move(-1, -1           , objects.Count - 1, KeyCode.R);

        Debug.Log(string.Format("index: {0} cnt: {1} delta: {2}", objectIndex, objects.Count, delta));
        GetObjectController().Rotate(GameObject.Find(objects[objectIndex]));
    }
}
