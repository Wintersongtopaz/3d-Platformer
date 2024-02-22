using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public static int coins = 0;
    public float pullForce = 5f;
    public UnityEvent OnCollect = new UnityEvent();
    //called when two colliders begin touching
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        coins++;
        Debug.Log($"coins: {coins}");
        OnCollect.Invoke();
    }

    //called when two GameObjects collide / overlap
    void OnTriggerEnter(Collider other)
    {
        
    }
    //called on each fixed update while two colliders are overlapping
    void OnTriggerStay(Collider other)
    {
        
        if (!other.CompareTag("Player")) return;
        Vector3 direction = other.gameObject.transform.position - transform.position;
        if (gameObject.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.AddForce(direction * pullForce);
        }
    }

    //called when two GameObjects stop colliding / overlapping
    void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
