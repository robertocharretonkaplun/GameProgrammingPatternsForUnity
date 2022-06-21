using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraRotator : MonoBehaviour
{

  public static ThirdPersonCameraRotator instance;
  [SerializeField]
  private float _mouseSensitivity = 3.0f;

  private float _rotationY;
  private float _rotationX;

  [SerializeField]
  public Transform _target;

  [SerializeField]
  public float OldDistance;
  public float _distanceFromTarget = 3.0f;

  private Vector3 _currentRotation;
  private Vector3 _smoothVelocity = Vector3.zero;

  [SerializeField]
  private float _smoothTime = 0.2f;

  [SerializeField]
  private Vector2 _rotationXMinMax = new Vector2(-40, 40);

  [Header("Cam properties")]
  public bool isCamLock = true;
  [Header("Move speed Attributes")]
  public float UpMovement = 2.5f;
  public float DownMovement = -2.5f;
  [Header("Rotation Attributes")]
  private float rotX = 0f;
  private float rotY = 0f;
  public float sensibility = 2.5f;
  public RoofCheck roofCheck;
  public bool IsTouchingAWall = false;

  private void Start()
  {
    if (instance != null)
    {
      return;
    }
    else
    {
      instance = this;
    }
    Cursor.lockState = CursorLockMode.Locked;
  }

  public void Init()
  {
    //roofCheck = LevelManager.instance.GetGameManager().GetRoofCheck();
    //_target = LevelManager.instance.GetGameManager().GetThirdPersonPlayer().transform.GetChild(3).transform;
  }
  void Update()
  {
    // Enable the camera movement
    if (Input.GetKeyDown(KeyCode.C))
    {
      if (isCamLock)
      {
        isCamLock = false;
      }
      else
      {
        isCamLock = true;
      }
    }

    if (isCamLock)
    {
      CameraRotation();
      CheckForWalls();
      //_distanceFromTarget = Mathf.Lerp(_distanceFromTarget, 3.0f, 5 * Time.deltaTime);
      if (!roofCheck.IsRoofAtTop)
      {

        OldDistance = _distanceFromTarget;
        _distanceFromTarget += Input.mouseScrollDelta.y * 50 * Time.deltaTime;


      }
    }
    else
    {
      CameraMovement();
    }
  }

  void CameraRotationWithMouse()
  {
    // Apply a rotation when right click is press
    if (Input.GetKey(KeyCode.Mouse1))
    {
      rotY += Input.GetAxis("Mouse X") * sensibility;
      rotX += Input.GetAxis("Mouse Y") * -1 * sensibility;
      transform.localEulerAngles = new Vector3(rotX, rotY, 0);
    }

  }

  void CameraMovement()
  {
    // Move the camera
    if (!isCamLock)
    {
      // Mouse Cam Rotation
      CameraRotationWithMouse();
      // Camera Zoom
      Zoom();


    }
  }

  public void Zoom()
  {
    transform.Translate(0, 0, Input.mouseScrollDelta.y * 50 * Time.deltaTime);


  }

  void CameraRotation()
  {
    float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
    float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

    _rotationY += mouseX;
    _rotationX += mouseY;

    // Apply clamping for x rotation 
    _rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

    Vector3 nextRotation = new Vector3(_rotationX, _rotationY);

    // Apply damping between rotation changes
    _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
    transform.localEulerAngles = _currentRotation;

    // Substract forward vector of the GameObject to point its forward vector to the target
    transform.position = _target.position - transform.forward * _distanceFromTarget;
  }


  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.blue;
    Gizmos.DrawLine(transform.position, Vector3.forward * 10);
  }
  void CheckForWalls()
  {
    Vector3 DesiredCamPos = transform.TransformPoint(transform.localPosition.normalized * 1f);
    RaycastHit hit;

    if (Physics.Linecast(transform.position, DesiredCamPos, out hit))
    {
      if (hit.transform.tag == "Wall")
      {

        StartCoroutine(ZoomIn(hit.distance));
      }
      //_distanceFromTarget = Mathf.Clamp(hit.distance, 1f, 1f);
      //_distanceFromTarget = Mathf.Lerp(hit.distance, 1.0f, 5 * Time.deltaTime);
    }
    else
    {
      
      // _distanceFromTarget = Mathf.Lerp(_distanceFromTarget, 3.0f, 5 * Time.deltaTime);
      //_distanceFromTarget = OldDistance;
    }

    //transform.localPosition = transform.localPosition.normalized * _distanceFromTarget;
  }

  IEnumerator ZoomIn(float distance)
  {
    //_distanceFromTarget = Mathf.Lerp(distance, 1.0f, 5 * Time.deltaTime);
    //_distanceFromTarget = 1f;
    _distanceFromTarget = Mathf.Lerp(_distanceFromTarget, 1.0f, 5 * Time.deltaTime);
    yield return new WaitForSeconds(3f);
    if (_distanceFromTarget <= 2)
    {
      _distanceFromTarget = Mathf.Lerp(_distanceFromTarget, 3.0f, 5 * Time.deltaTime);
    }
    //_distanceFromTarget = Mathf.Lerp(_distanceFromTarget, 3.0f, 5 * Time.deltaTime);
    //_distanceFromTarget = 3f;
    //_distanceFromTarget = Mathf.Lerp(distance,OldDistance, 5 * Time.deltaTime);
  }
}
