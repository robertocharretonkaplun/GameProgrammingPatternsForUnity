using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomFlee : MonoBehaviour
{
  private NavMeshAgent agent;
  public Transform Enemy;
  public float viewDistance = 2f;
  // Start is called before the first frame update
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
  }

  // Update is called once per frame
  void Update()
  {
    float distance = Vector3.Distance(transform.position, Enemy.position);

    if (distance < viewDistance)
    {
      Vector3 dirToInvestigator = transform.position - Enemy.position;
      Vector3 newPos = transform.position + dirToInvestigator;

      agent.SetDestination(newPos);
      GetComponent<Animator>().SetBool("IsRunning", true);
    }
    else
    {
      GetComponent<Animator>().SetBool("IsRunning", false);

    }
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawLine(transform.position, Enemy.position);
    Gizmos.color = Color.cyan;
    Gizmos.DrawWireSphere(transform.position, viewDistance);
  }
}
