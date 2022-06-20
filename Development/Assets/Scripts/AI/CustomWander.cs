using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
public class CustomWander : MonoBehaviour
{
  [Header("Agent Attributes")]
  public int agentID = 0;
  public float speed = 10.0f;
  public float EnemyTurnSpeed = 2.5f;
  public bool IsSeeking = false;
  public Transform player;
  private Transform target;
  public Animator animator;
  private int PointIndex = 0;

  [Header("Areas")]
  public float viewDistance = 8f;
  public float playerViewDistance = 8f;
  public float KillDistance = 1f;
  public float FogDistance = 1f;

  [Header("Agent Effects")]
  public GameObject crossfade;



  // Start is called before the first frame update
  void Start()
  {
    target = LevelManager.instance.GetDungeonGenerator().RoomObjs[0];
    player = FindObjectOfType<ThirdPersonControllerV2>().transform;

    agentID = LevelManager.instance.GetAIManager().NewAgent(GetComponent<NavMeshAgent>(), 2.5f);
  }

  // Update is called once per frame
  void Update()
  {

    float distance = Vector3.Distance(player.position, transform.position);

    if (distance <= playerViewDistance)
    {
      animator.SetBool("IsWalking", true);
      IsSeeking = true;

      LevelManager.instance.GetAIManager().FollowTarget(player, player.position);
      if (distance <= KillDistance)
      {
        SceneManager.LoadScene("MiniBackrooms");
      }
    }
    else
    {
      IsSeeking = false;

      Vector3 direction = target.position - transform.position;
      // Change the waypoint, if we reach the last point
      if (Vector3.Distance(transform.position, target.position) <= viewDistance)
      {
        ChangeToNextPoint();
      }

      // Look at next point
      LookAtNextPoit(direction: direction);
      LevelManager.instance.GetAIManager().FollowTarget(target, target.position);
      animator.SetBool("IsWalking", true);
    }


    PlayerNearToEnemy();
  }

  void ChangeToNextPoint()
  {
    // If the enemy reach the last point, its destroyed
    if (PointIndex >= LevelManager.instance.GetDungeonGenerator().RoomObjs.Length - 1)
    {
      //Destroy(gameObject);
      //Time.timeScale = 0;
      PointIndex = 0;
    }
    else
    {
      // Change point index
      PointIndex++;// Random.Range(0, waypoints.Waypoints.Length-1);
      target = LevelManager.instance.GetDungeonGenerator().RoomObjs[PointIndex];
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
    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere(transform.position, FogDistance);
  }

  public void PlayerNearToEnemy()
  {
    var alpha = crossfade.GetComponent<CanvasGroup>().alpha;
    if (Vector3.Distance(transform.position, player.position) <= FogDistance && alpha <= .8f)
    {
      crossfade.GetComponent<CanvasGroup>().alpha += .01f;
    }
    else
    {
      crossfade.GetComponent<CanvasGroup>().alpha -= .01f;

    }
  }
}
