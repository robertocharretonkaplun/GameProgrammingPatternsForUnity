using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIManager : MonoBehaviour
{
  public static AIManager instance;
  public List<NavMeshAgent> agents;
  private NavMeshSurface navMeshSurface;
  // Start is called before the first frame update
  void Awake()
  {
    if (instance != null)
    {
      return;
    }
    else
    {
      instance = this;
    }

  }


  public void Init()
  {
    // Init NavMeshSurface
    navMeshSurface = GetComponent<NavMeshSurface>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public int NewAgent(NavMeshAgent agent, float speed)
  {
    agent.speed = speed;

    agents.Add(agent);

    return agents.Count - 1;
  }

  public void FollowTarget(Transform target, Vector3 targetPos)
  {
    foreach (NavMeshAgent agent in agents)
    {
      if (target != null)
      {
        agent.SetDestination(targetPos);
      }
    }
  }

  public void BuildNavMesh()
  {
    navMeshSurface.BuildNavMesh();
  }
}
