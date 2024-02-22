using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehavior : MonoBehaviour
{
    AIController aIController;
    public GameObject followTarget;
    public float range;
    public string tag;

    void Awake() => aIController = GetComponent<AIController>();
    void Update()
    {
       // followTarget = FindTarget.FindNearestTargetInRange(transform.position, range, tag);
        if (followTarget) aIController.targetPosition = followTarget.transform.position;
        else aIController.targetPosition = transform.position;

    }
}
