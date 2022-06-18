using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitDoor : MonoBehaviour
{
  public Transform target;
  public GameObject DoorLight;
  public float viewDistance = 1.5f;
  public bool IsDoorEnable;
  // Start is called before the first frame update
  void Start()
  {
    target = FindObjectOfType<ThirdPersonControllerV2>().transform;
  }

  // Update is called once per frame
  void Update()
  {
    if (Helpers.PlayerHasAllLevers())
    {
      IsDoorEnable = true;
      float distance = Vector3.Distance(target.position, transform.position);

      if (distance <= viewDistance)
      {
        if (Input.GetKeyDown(KeyCode.E))
        {
          SceneManagment.instance.LoadLevel_0(); // Must be Random scene
        }
      }
    }
    if (!IsDoorEnable)
    {
      DoorLight.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
    else
    {
      DoorLight.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, viewDistance);
  }
}
