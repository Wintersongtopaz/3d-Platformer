using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Checkpoint lastCheckpoint;

    public static void Respawn(Rigidbody rigidbody)
    {
        if (lastCheckpoint == null) return;
        rigidbody.transform.position = lastCheckpoint.transform.position;
        rigidbody.velocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;
        lastCheckpoint = this;
        Debug.Log(lastCheckpoint.name);
    }

}
