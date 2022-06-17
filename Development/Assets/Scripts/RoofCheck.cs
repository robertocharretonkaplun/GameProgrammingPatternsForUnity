using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofCheck : MonoBehaviour
{
  public Transform RoofDetectionPoint;
  public float viewDistance = 5f;
  public Vector3 direction;
  public ThirdPersonControllerV2 player;

  public float timer = 2.5f;
  public float timeOfInspection = 6.5f;
  Color rayColor = Color.red;
  public bool IsRoofAtTop = false;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Check();
  }

  public void Check()
  {
    RaycastHit hit;

    Vector3 toPosition = RoofDetectionPoint.position;
    Vector3 origin = transform.position;
    //Vector3 direction = Vector3.up;
    var cam = ThirdPersonCameraRotator.instance;
    Debug.DrawRay(origin, Vector3.up * viewDistance, rayColor);
    if (Physics.Raycast(origin, Vector3.up, out hit, viewDistance))
    {
      if (hit.transform.tag == "Roof")
      {
        IsRoofAtTop = true;
        cam._distanceFromTarget = Mathf.Lerp(cam._distanceFromTarget, 2.0f, 5 * Time.deltaTime);
      }
      else
      {
        // If there is no roof
        //ThirdPersonCameraRotator.instance._distanceFromTarget = ThirdPersonCameraRotator.instance.OldDistance;
      }

      if (player.IsAnalizing)
      {
        rayColor = Color.green;
        if (timer <= 0.0f)
        {
          if (hit.transform.tag == "Roof")
          {
            hit.transform.gameObject.SetActive(false);
            IsRoofAtTop = false;
          }
          timer = timeOfInspection;
        }
        timer -= Time.deltaTime;
      }
      else
      {
        rayColor = Color.red;
      }
    }


  }
}
