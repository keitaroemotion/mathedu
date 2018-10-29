using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shape : MonoBehaviour {

    private int   objectIndex;
    private float delta;
    private float VELOCITY = 0.1f;

    private List<string> objects = new List<string>{"Cylinder", "Cube", "Capsule"};

    private Vector3 POSITION_2   = new Vector3(-1.4f, 0.0f, -5.7f);
    private Vector3 POSITION_1   = new Vector3(0.52f, 0.79f, -7.7f);
    private Vector3 POSITION_3   = new Vector3(4.0f, 0.0f, -5.7f);

    private List<Vector3> GetPositions(){
        return new List<Vector3>{POSITION_1, POSITION_2, POSITION_3};
    }

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

    void SwitchObjects(){
	IncreaseDelta();
    	Move(1 , objects.Count, 0,                 KeyCode.L);
	Move(-1, -1           , objects.Count - 1, KeyCode.R);
    }

    void ShowLog(){
        Debug.Log(string.Format("index: {0} cnt: {1} delta: {2}", objectIndex, objects.Count, delta));
    }

    GameObject GetTargetObject(){
        return GetTargetObjectWithIndex(objectIndex);
    }

    GameObject GetTargetObjectWithIndex(int i){
        return GameObject.Find(objects[i]);
    }

    List<Vector3> SubList(List<Vector3> v, int start, int end){
	var newList = new List<Vector3>();    
        for(int i = start; i <= end;  i++)  {
           newList.Add(v[i]);	
	}
	return newList;
    }
     
    List<Vector3> SetPositions(int i, List<Vector3> v){
	var N      = v.Count;    
	var former = SubList(v, 0,     N - (i + 1));
	var latter = SubList(v, N - i, N - 1);
	latter.AddRange(former);
	return latter;
    }

    void Update () {

	SwitchObjects();
        ShowLog();
        var targetObject = GetTargetObject();

	var positions = SetPositions(objectIndex, GetPositions());

	// targetObject.transform.position = GetPositions()[objectIndex];
	for(var i = 0; i < objects.Count; i++){
            var obj = GetTargetObjectWithIndex(i);
	    //obj.transform.position = positions[i];
	    obj.transform.position = Vector3.MoveTowards(obj.transform.position, positions[i], VELOCITY);
	}

        GetObjectController().Rotate(targetObject);
	//targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position, targetPosition, VELOCITY);
    }
}
