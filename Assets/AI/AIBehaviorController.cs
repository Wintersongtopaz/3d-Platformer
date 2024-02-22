using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Determine which behavior to run by enabling/ disabling behaviors
public class AIBehaviorController : MonoBehaviour
{
    public PatrolBehavior patrolBehavior; //enable when no valid target is in range
    public FollowBehavior followBehavior;
    public float range;
    public string tag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //follow target: enable when a valid target is in range
        GameObject followTarget = FindTarget.FindNearestTargetInRange(transform.position, range, tag); 
        if (followTarget)
        {
            followBehavior.followTarget = followTarget;
            followBehavior.enabled = true;
            patrolBehavior.enabled = false;
        }
        else
        {
            followBehavior.enabled = false;
            patrolBehavior.enabled = true;
        }
    }
}
