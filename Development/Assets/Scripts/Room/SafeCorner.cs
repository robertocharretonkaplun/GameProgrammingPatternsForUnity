using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeCorner : MonoBehaviour
{
  public bool IsSafeRoom = false;
  public float teleportArea = 2.0f;
  public Transform TPPoint;
  private Transform target;
  public float distance;
  // Start is called before the first frame update
  void Start()
  {
    target = FindObjectOfType<ThirdPersonControllerV2>().transform;
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.yellow;

    Gizmos.DrawWireSphere(TPPoint.position, teleportArea);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      if (!IsSafeRoom)
      {
        SceneManagment.instance.LoadLevel_0();
      }
    }
  }
}
