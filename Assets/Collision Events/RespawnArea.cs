using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnArea : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Player")) return;
        if (!collider.attachedRigidbody) return;
        Checkpoint.Respawn(collider.attachedRigidbody);
    }
}
