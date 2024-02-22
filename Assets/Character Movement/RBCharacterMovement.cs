using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
//RB Character Movement: Implement character-based movement using the physics-driven Rigidbody component
public class RBCharacterMovement : MonoBehaviour, ICharacterMovement
{
    Rigidbody rigidbody;
    CapsuleCollider capsule;

    #region Character Movement Interface
    public Vector3 moveDirection { get; set; } //Desired Move direction
    public float speed => groundVelocity.magnitude / moveSpeed;//how fast our character is moving - read only
    public bool grounded => Physics.SphereCast(transform.position, capsule.radius, Vector3.down, out var hit, capsule.height * 0.5f);//whether character is on ground - read only
    public void Jump()
    {
        if (grounded) rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    } //called to jump if we are on the ground
    #endregion

    #region Parameters
    [SerializeField] float moveSpeed; //Desired max speed
    [SerializeField] float acceleration; //move speed rate of change
    [SerializeField] float jumpForce; //how much force to add when jumping
    [SerializeField] float airControlModifier; //how much control we have when in the air
    [SerializeField] float rotationRate; //how many degrees we rotate in a single second
    #endregion

    #region Properties
    Vector3 groundMoveDirection => Vector3.ProjectOnPlane(moveDirection, Vector3.up).normalized;
    Vector3 groundVelocity => new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);
    #endregion

    #region MonoBehavior
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        if (grounded) GroundMovement(Time.fixedDeltaTime);
        else AirMovement(Time.fixedDeltaTime);

        RotateCharacter(Time.fixedDeltaTime);
        ClampVelocity();
    }
    #endregion

    #region Movement and Rotation
    void ClampVelocity()
    {
        Vector3 velocity = groundVelocity;
        float magnitude = velocity.magnitude;
        magnitude = Mathf.Clamp(magnitude, 0f, moveSpeed);
        velocity = velocity.normalized * magnitude;
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }

    void GroundMovement(float deltaTime) // How does our character move when on the ground?
    {
        Vector3 moveForce = groundMoveDirection * moveSpeed * acceleration;
        rigidbody.AddForce(moveForce);
    }

    void AirMovement(float deltaTime) //How does our character move when in the air?
    {
        Vector3 moveForce = groundMoveDirection * moveSpeed * acceleration *airControlModifier;
        rigidbody.AddForce(moveForce);
    }

    void RotateCharacter(float deltaTime) //Rotate our character in the direction they're moving
    {
        if (groundVelocity.magnitude <= 0.1f) return;
        Quaternion targetRotation = Quaternion.LookRotation(groundVelocity, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationRate * deltaTime);
    }
    #endregion
}
