using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
  [Header("Camera Attributes")]
  [SerializeField]
  public Camera CameraFollow;
  [Header("Character Attributes")]
  //public Animator animator;
  //private CharacterController controller;
  [Header("Player Attributes")]
  [SerializeField]
  private float PlayerSpeed = 2f;

  [SerializeField]
  private float RotationSpeed = 10f;


  private Vector3 PlayerVelocity;
  [SerializeField]
  private float JumpHeight = 1.0f;
  [SerializeField]
  private float _gravityValue = -9.81f;

  //public bool _groundedPlayer;
  public bool IsCrouch = false;
  public bool IsAnalizing = false;
  public ThirdPersonCharacter character;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Movement();
  }

  void Movement()
  {
    //_groundedPlayer = controller.isGrounded;
    if (PlayerVelocity.y < 0)
    {
      PlayerVelocity.y = 0f;
    }

    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    Vector3 movementInput = Quaternion.Euler(0, CameraFollow.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
    Vector3 movementDirection = movementInput.normalized;

    //controller.Move(movementDirection * PlayerSpeed * Time.deltaTime);
    character.Move(movementDirection * PlayerSpeed * Time.deltaTime, false, false);
    if (movementDirection != Vector3.zero)
    {
      // Run Condition
      if (Input.GetKey(KeyCode.LeftShift))
      {
        PlayerSpeed = 4f;
        if (!IsCrouch)
        {
          //animator.SetBool("IsRunning", true);
          //animator.SetBool("IsWalking", false);
          //animator.SetBool("IsCrouchWalking", false);

        }
      }
      else
      {
        PlayerSpeed = 2f;
        if (!IsCrouch)
        {
          //animator.SetBool("IsRunning", false);
          //animator.SetBool("IsWalking", true);
          //animator.SetBool("IsCrouchWalking", false);
        }
        else
        {
          //animator.SetBool("IsCrouchWalking", true);
        }
      }
      Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

      transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, RotationSpeed * Time.deltaTime);
    }
    else
    {
      //animator.SetBool("IsWalking", false);
    }

    // Jump Condition
    if (Input.GetButtonDown("Jump"))
    {
      //animator.SetBool("IsJumping", true);
      PlayerVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * _gravityValue);
    }
    else
    {
      //animator.SetBool("IsJumping", false);
    }

    PlayerVelocity.y += _gravityValue * Time.deltaTime;
    //controller.Move(PlayerVelocity * Time.deltaTime);
    //character.Move(PlayerVelocity * Time.deltaTime, false, false);
  }
}
