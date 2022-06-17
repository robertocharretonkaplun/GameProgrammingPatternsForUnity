using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
  public Animator animator;
  public float viewDistance = 10f;

  public Transform target;
  public Transform point;
  NavMeshAgent agent;
  public bool IsSeeking = false;
  // Start is called before the first frame update
  void Start()
  {
    target = FindObjectOfType<ThirdPersonControllerV2>().transform;
    agent = GetComponent<NavMeshAgent>();
  }

  // Update is called once per frame
  void Update()
  {
    float distance = Vector3.Distance(target.position, transform.position);

    if (distance <= viewDistance)
    {
      //transform.GetChild(0).rotation = new Quaternion(0, 270, 0, 0);
      animator.SetBool("IsWalking", true);
      IsSeeking = true;
      agent.SetDestination(target.position);
    }
    else
    {
      //if (IsSeeking)
      //{
      //  agent.SetDestination(point.position);
      //  agent.isStopped = true;
      //}
        IsSeeking = false;

      //animator.SetBool("IsWalking", false);
    }
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.cyan;
    Gizmos.DrawWireSphere(transform.position, viewDistance);
  }
}
