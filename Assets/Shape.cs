using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shape : MonoBehaviour {

    private int   objectIndex;
    private float delta;
    private float VELOCITY = 0.1f;
    private KeyCode SwapCommandL = KeyCode.LeftArrow;
    private KeyCode SwapCommandR = KeyCode.RightArrow;
    private ParticleSystem particle;

    private List<string> objects = new List<string>{"Cylinder", "Cube", "Rippo", "CylinderShort"};

    // Remained tasks: 
    //
    // 1. let object be more beautiful (might gotta be imported from Maya + Arnold)
    // 2. Android 
    // 3. Add effects when moving or selected
    // 4. zoom/not

    // Defined Positions of each object ... might need mathematical
    // calculation to make it in a good git
    private Vector3 POSITION_1 = new Vector3(0.52f, 0.79f, -7.7f);
    private Vector3 POSITION_2 = new Vector3(-1.4f, 0.0f, -5.7f);
    private Vector3 POSITION_3 = new Vector3(4.0f, 0.0f, -5.7f);
    private Vector3 POSITION_4 = new Vector3(6.0f, 0.0f, -5.7f);

    private List<Vector3> GetPositions(){
        return new List<Vector3>{POSITION_1, POSITION_2, POSITION_3, POSITION_4};
    }

    ObjectController GetObjectController(){
        return GameObject.Find("Object").GetComponent<ObjectController>();
    }

    void Start(){
        delta       = 0;
        objectIndex = 0;
        //particle = GameObject.Find("Ring").GetComponent<ParticleSystem>();
    }

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

            //particle.transform.position = POSITION_1;
            //particle.Play();
            FixRotations();
        }
    }    

    void IncreaseDelta(){
        delta += Time.deltaTime;
    }

    void SwitchObjects(){
        IncreaseDelta();
        Move(1 , objects.Count, 0,                 SwapCommandL);
        Move(-1, -1           , objects.Count - 1, SwapCommandR);
    }

    void ShowLog(){
        //Debug.Log(string.Format("index: {0} cnt: {1} delta: {2}", objectIndex, objects.Count, delta));
    }

    GameObject GetTargetObject(){
        return GetTargetObjectWithIndex(objectIndex);
    }

    List<GameObject> GetAllObjects(){
        return ToList(objects.Select(g => GameObject.Find(g)));
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

    List<GameObject> ToList(IEnumerable<GameObject> ienums){
        var list = new List<GameObject>();        
        foreach(var l in ienums){ list.Add(l); }
        return list;
    }

    void FixRotations(){
        GetAllObjects().ForEach( g => FixRotation(g) );
    }

    void FixRotation(GameObject obj){
	    Debug.Log("xxx");		
        obj.transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    void ResetPositions(){
        var positions = SetPositions(objectIndex, GetPositions());
        for(var i = 0; i < objects.Count; i++){
            var obj                = GetTargetObjectWithIndex(i);
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, positions[i], VELOCITY);
        }
    }

    void Update () {
        SwitchObjects();
        ShowLog();
        ResetPositions();
        GetObjectController().Rotate(GetTargetObject());
    }
}
