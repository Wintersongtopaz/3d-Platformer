using UnityEngine;

public interface ICharacterMovement
{
     Vector3 moveDirection{get; set;} //Desired Move direction
     float speed{ get;} //how fast our character is moving - read only
     bool grounded { get; } //whether character is on ground - read only
     void Jump(); //called to jump if we are on the ground
}
