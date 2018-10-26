using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CylinderController : MonoBehaviour {

    void Update () {
        var obj = GameObject.Find("Object").GetComponent<ObjectController>();
        var cylinder = GameObject.Find("Cylinder");
        obj.Rotate(cylinder);
    }
}
