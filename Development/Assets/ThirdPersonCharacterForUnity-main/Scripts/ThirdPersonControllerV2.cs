using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonControllerV2 : MonoBehaviour
{
  [Header("Camera Attributes")]
  [SerializeField]
  private Camera CameraFollow;
  [Header("Character Attributes")]
  public Animator animator;
  private CharacterController controller;
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

  public bool _groundedPlayer;
  public bool IsCrouch = false;
  private void Start()
  {
    controller = GetComponent<CharacterController>();
  }

  private void Update()
  {
    Movement();
    Crouch();
  }

  public void Crouch()
  {
    if (Input.GetKey(KeyCode.LeftControl))
    {
      IsCrouch = true;
      controller.height = 1f;
      controller.center = new Vector3(0, .5f, 0);
      animator.SetBool("IsCrouchIdle", true);
    }
    else
    {
      if (IsCrouch)
      {
        controller.height = 1.65f;
        controller.center = new Vector3(0, .9f, 0);
      }
      IsCrouch = false;
      animator.SetBool("IsCrouchIdle", false);
    }
  }

  void Movement()
  {
    _groundedPlayer = controller.isGrounded;
    if (_groundedPlayer && PlayerVelocity.y < 0)
    {
      PlayerVelocity.y = 0f;
    }

    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    Vector3 movementInput = Quaternion.Euler(0, CameraFollow.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
    Vector3 movementDirection = movementInput.normalized;

    controller.Move(movementDirection * PlayerSpeed * Time.deltaTime);

    if (movementDirection != Vector3.zero)
    {
      // Run Condition
      if (Input.GetKey(KeyCode.LeftShift))
      {
        PlayerSpeed = 4f;
        if (!IsCrouch)
        {
          animator.SetBool("IsRunning", true);
          animator.SetBool("IsWalking", false);
          animator.SetBool("IsCrouchWalking", false);

        }
      }
      else
      {
        PlayerSpeed = 2f;
        if (!IsCrouch)
        {
          animator.SetBool("IsRunning", false);
          animator.SetBool("IsWalking", true);
          animator.SetBool("IsCrouchWalking", false);
        }
        else
        {
          animator.SetBool("IsCrouchWalking", true);
        }
      }
      Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

      transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, RotationSpeed * Time.deltaTime);
    }
    else
    {
      animator.SetBool("IsWalking", false);
    }

    // Jump Condition
    if (Input.GetButtonDown("Jump"))
    {
      animator.SetBool("IsJumping", true);
      PlayerVelocity.y += Mathf.Sqrt(JumpHeight * -3.0f * _gravityValue);
    }
    else
    {
      animator.SetBool("IsJumping", false);
    }

    PlayerVelocity.y += _gravityValue * Time.deltaTime;
    controller.Move(PlayerVelocity * Time.deltaTime);
  }
}
