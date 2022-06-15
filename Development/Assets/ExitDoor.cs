using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitDoor : MonoBehaviour
{
  public Transform target;
  public GameObject DoorLight;
  public float viewDistance = 1.5f;
  // Start is called before the first frame update
  void Start()
  {
    target = FindObjectOfType<ThirdPersonControllerV2>().transform;
  }

  // Update is called once per frame
  void Update()
  {
    if (GameManager.instance.levers == GameManager.instance.leversMax)
    {
      DoorLight.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

      float distance = Vector3.Distance(target.position, transform.position);

      if (distance <= viewDistance)
      {
        if (Input.GetKeyDown(KeyCode.E))
        {
          SceneManager.LoadScene("MiniBackrooms");
        }
      }
    }
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, viewDistance);
  }
}
