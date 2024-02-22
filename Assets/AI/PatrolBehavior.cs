using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrolBehavior : MonoBehaviour
{
    public PatrolArea patrolArea;
    Vector3 targetPosition;
    AIController aIController;
    bool destinationReached = false;
    public float waitTime = 1f;
    public float timeout = 5f; //happens when a process has not been completed before a timer expires

    void Awake()
    {
        aIController = GetComponent<AIController>();
        aIController.onDestinationReached.AddListener(OnDestinationReached);
    }

    void OnDestinationReached() => destinationReached = true;
    void OnEnable()
    {
        StartCoroutine(NextDestination());
    }

    IEnumerator NextDestination()
    {
        float timeoutTimer = 0f;
        while (true)
        {
            if (destinationReached)
            {
                yield return new WaitForSeconds(waitTime);
                if(TryGetTargetPosition(out targetPosition))
                {
                    aIController.targetPosition = targetPosition;
                    destinationReached = false;
                    timeoutTimer = 0f;
                }
            }
            yield return null;
            timeoutTimer += Time.deltaTime;
            if(timeoutTimer >= timeout)
            {
                destinationReached = true;
            }
        }
    }

    public bool TryGetTargetPosition(out Vector3 targetPosition)
    {
        targetPosition = Vector3.zero;
        for(int i = 0; i < 25; i++)
        {
            Vector3 position = patrolArea.GetTargetPosition();
            position.y = transform.position.y;
            if (ValidateTargetPosition(position))
            {
                targetPosition = position;
                return true;
            }
        }
        return false;
    }

    bool ValidateTargetPosition(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        float maxDistance = direction.magnitude;

        if(Physics.Raycast(transform.position, direction, maxDistance))
        {
            Debug.DrawLine(transform.position, position, Color.red);
            return false;
        }
        else
        {
            Debug.DrawLine(transform.position, position, Color.green);
            return true;
        }
    }

   
}
