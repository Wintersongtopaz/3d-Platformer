using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCollider : MonoBehaviour
{
    public Vector3 bounceDirection = Vector3.up;
    public float bounceStrength = 5f;
    public List<string> acceptTags = new List<string>();
    public Collider bounceCollider;

    void OnCollisionEnter(Collision collision)
    {
        if (!acceptTags.Contains(collision.collider.tag)) return;
        if (!collision.collider.attachedRigidbody) return;
        bool bounceColliderHit = false;
        for(int i = 0; i < collision.contactCount; i++)
        {
            if(collision.GetContact(i).thisCollider == bounceCollider)
            {
                bounceColliderHit = true;
                break;
            }
        }
        if (bounceColliderHit) collision.collider.attachedRigidbody.AddForce(bounceDirection * bounceStrength, ForceMode.Impulse);
    }
}
