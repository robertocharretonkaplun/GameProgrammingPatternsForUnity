using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flee : MonoBehaviour
{
  public Animator animator;
  public float viewDistance = 10f;
  public float speed = 3f;
  public Transform target;
  public bool IsSeeking = false;
  // Start is called before the first frame update
  void Start()
  {
    //target = FindObjectOfType<ThirdPersonControllerV2>().transform;
    //agent = GetComponent<NavMeshAgent>();
  }

  // Update is called once per frame
  void Update()
  {
    float distance = Vector3.Distance(target.position, transform.position);

    if (distance <= viewDistance)
    {
      //transform.GetChild(0).rotation = new Quaternion(0, 270, 0, 0);
      animator.SetBool("IsRunning", true);
      IsSeeking = true;
      Vector3 dirToEnemy = transform.position - target.position;
      Vector3 newPos = transform.position + dirToEnemy;
      transform.Translate(newPos.normalized * (speed) * Time.deltaTime, Space.World);
    }
    else
    {
      IsSeeking = false;

      animator.SetBool("IsRunning", false);
    }
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.cyan;
    Gizmos.DrawWireSphere(transform.position, viewDistance);
  }
}
