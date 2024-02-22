using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//Control AI character movement using the ICharacterMovement interface.
public class AIController : MonoBehaviour
{
    ICharacterMovement characterMovement;
    //Where do we want the AI to go?
    public Vector3 targetPosition;
    //Distance from target position to register destination reached
    public float stopRange = 1f;
    //A unity event invoked only upon entering the stop range of target position
    public UnityEvent onDestinationReached = new UnityEvent();

    bool destinationReached;
    bool DestinationReached
    {
        get => destinationReached;
        set
        {
            if (!destinationReached && value) onDestinationReached.Invoke();
            destinationReached = value;
        }
    }

    void Awake() => characterMovement = GetComponent<ICharacterMovement>();

   

    // Update is called once per frame
    void Update()
    {
        float distance = (transform.position - targetPosition).magnitude;

        if (distance <= stopRange)
        {
            characterMovement.moveDirection = Vector3.zero;
            DestinationReached = true;
        }
        else
        {
            DestinationReached = false;
            characterMovement.moveDirection = targetPosition - transform.position;
        }
    }
}
