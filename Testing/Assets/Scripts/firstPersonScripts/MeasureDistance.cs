using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasureDistance : MonoBehaviour {

    public static bool checkDistance(double maxDistance, GameObject object1, GameObject object2)
    {
        float distance = Vector3.Distance(object1.transform.position, object2.transform.position);
        
        if (distance > maxDistance)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
