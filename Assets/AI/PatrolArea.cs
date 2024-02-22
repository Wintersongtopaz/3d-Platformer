using UnityEngine;
//A stand-alone component that provides random points in a given area
public class PatrolArea : MonoBehaviour
{
    public float radius = 5f;
   
    //Random position in radius
    public Vector3 GetTargetPosition()
    {
      //Random.insideUnitSphere: Returns a random point inside or an a sphere with radius 1.0 (Read Only)
        Vector3 direction = Random.insideUnitSphere;
        direction.y = 0f;
        direction.Normalize();
    //Random.Range(): Returns a random numeric value between minimum and maximum
        float range = Random.Range(0f, radius);
        return transform.position + direction * range;
    }
    //Display scene view information while testing new features
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
