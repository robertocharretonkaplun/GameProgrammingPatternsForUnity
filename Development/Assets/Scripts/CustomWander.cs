using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class CustomWander : MonoBehaviour
{
  public float speed = 10.0f;
  private int PointIndex = 0;
  private Transform target;
  public float EnemyTurnSpeed = 2.5f;

  public float viewDistance = 8f;
  public float playerViewDistance = 8f;
  public float KillDistance = 1f;


  public Animator animator;

  public Transform player;
  public Transform point;
  NavMeshAgent agent;
  public bool IsSeeking = false;
  // Start is called before the first frame update
  void Start()
  {
    target = waypoints.Waypoints[0];
    player = FindObjectOfType<ThirdPersonControllerV2>().transform;
    agent = GetComponent<NavMeshAgent>();
  }

  // Update is called once per frame
  void Update()
  {

    float distance = Vector3.Distance(player.position, transform.position);

    if (distance <= playerViewDistance)
    {
      //transform.GetChild(0).rotation = new Quaternion(0, 270, 0, 0);
      animator.SetBool("IsWalking", true);
      IsSeeking = true;
      agent.SetDestination(player.position);
      if (distance <= KillDistance)
      {
        SceneManager.LoadScene("MiniBackrooms");
      }
    }
    else
    {
      //if (IsSeeking)
      //{
      //  agent.SetDestination(point.position);
      //  agent.isStopped = true;
      //}
      IsSeeking = false;

      Vector3 direction = target.position - transform.position;
      // Change the waypoint, if we reach the last point
      if (Vector3.Distance(transform.position, target.position) <= viewDistance)
      {
        ChangeToNextPoint();
      }

      // Look at next point
      LookAtNextPoit(direction: direction);
      agent.SetDestination(target.position);
      animator.SetBool("IsWalking", true);


      //Check();
      //animator.SetBool("IsWalking", false);
    }

  }

  void ChangeToNextPoint()
  {
    // If the enemy reach the last point, its destroyed
    if (PointIndex >= waypoints.Waypoints.Length - 1)
    {
      //Destroy(gameObject);
      //Time.timeScale = 0;
      PointIndex = 0;
    }
    else
    {
      // Change point index
      //PointIndex = Random.Range(0, waypoints.Waypoints.Length-1);
      PointIndex++;// Random.Range(0, waypoints.Waypoints.Length-1);
      target = waypoints.Waypoints[PointIndex];
    }
  }

  void LookAtNextPoit(Vector3 direction)
  {
    Quaternion lookRotation = Quaternion.LookRotation(direction);

    Vector3 realRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * EnemyTurnSpeed).eulerAngles;

    transform.rotation = Quaternion.Euler(0.0f, realRotation.y, 0.0f);
  }


  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, viewDistance);
    Gizmos.color = Color.cyan;
    Gizmos.DrawWireSphere(transform.position, playerViewDistance);
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, KillDistance);
  }

  public void Check()
  {
    Vector3 sensor;
    RaycastHit hit;
    float avoidDetection;


    sensor = transform.position + (transform.forward * viewDistance);
    if (Physics.Raycast(sensor, transform.forward, out hit, viewDistance))
    {
      Debug.DrawLine(transform.position, hit.point, Color.green);
      float distance = Vector3.Distance(transform.position, hit.point);
      Debug.Log("Distance: " + distance);
      if (distance >= viewDistance && hit.transform.gameObject.tag == "Enemy")
      {
        Vector3 dirToEnemy = transform.position - hit.point;
        Vector3 newPos = transform.position + dirToEnemy;
        transform.Translate(newPos.normalized * (speed) * Time.deltaTime, Space.World);
      }
    }

  }
}
