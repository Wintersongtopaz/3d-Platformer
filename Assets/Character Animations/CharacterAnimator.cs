using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Animator animator;
    public ICharacterMovement characterMovement;

    void Awake()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponentInParent<ICharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", characterMovement.speed);
        animator.SetBool("Grounded", characterMovement.grounded);
    }
}
