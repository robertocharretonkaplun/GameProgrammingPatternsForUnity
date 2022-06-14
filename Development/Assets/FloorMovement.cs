using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
  [Header("Rotation Attributes")]
  private float rotX = 0f;
  private float rotY = 0f;
  public float sensibility = 2.5f;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    CameraRotationWithMouse();
  }
  void CameraRotationWithMouse()
  {
    // Apply a rotation when right click is press
    if (Input.GetKey(KeyCode.Mouse1))
    {
      rotY += Input.GetAxis("Mouse X") * sensibility;
      //rotX += Input.GetAxis("Mouse Y") * -1 * sensibility;
      transform.localEulerAngles = new Vector3(rotX, rotY, 0);
    }
  }
}
