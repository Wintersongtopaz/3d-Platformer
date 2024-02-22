using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//A static class which provides methods to find a target GameObject based on specific parameters.
public static class FindTarget  
{
    public static GameObject FindNearestTargetInRange(Vector3 center, float range, string tag)
    {
        GameObject target = null;
        float minDistance = range;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach(GameObject gameObject in gameObjects)
        {
            float distance = (gameObject.transform.position - center).magnitude;
            if (distance <= minDistance)
            {
                minDistance = distance;
                target = gameObject;
            }
        }
        return target;
    }
}
