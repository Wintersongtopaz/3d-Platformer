using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ICharacterMovement characterMovement;

    void Awake() => characterMovement = GetComponent<ICharacterMovement>();


    // Update is called once per frame
    void Update()
    {
        Vector3 forward = Camera.main.transform.forward * Input.GetAxisRaw("Vertical");
        Vector3 right = Camera.main.transform.right * Input.GetAxisRaw("Horizontal");
        Vector3 moveDirection = forward + right;
        characterMovement.moveDirection = moveDirection;

        if (Input.GetButtonDown("Jump")) characterMovement.Jump();
    }
}
