using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivation : MonoBehaviour
{
  public Transform target;
  public GameObject Light;
  public float viewDistance = .5f;

  private void Start()
  {
    target = FindObjectOfType<ThirdPersonControllerV2>().transform;
  }

  private void Update()
  {
    float distance = Vector3.Distance(target.position, transform.position);

    if (distance <= viewDistance)
    {
      if (Input.GetKey(KeyCode.E))
      {
        Light.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
      }
    }
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.cyan;
    Gizmos.DrawWireSphere(transform.position, viewDistance);
  }
}
