using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrading1 : MonoBehaviour
{
  public GameObject[] Traders;
  public Transform[] SpawnPoints;
  public GameObject TraderObj;
  // Start is called before the first frame update
  void Start()
  {
    // RoomObjs the array of point
    SpawnPoints = new Transform[transform.childCount];

    // Set all the child points
    for (int i = 0; i < SpawnPoints.Length; i++)
    {
      SpawnPoints[i] = transform.GetChild(i);
    }

    int RandomSpawnPoint = Random.Range(0, SpawnPoints.Length);

    Traders[0].GetComponent<NPC>().id = LevelManager.instance.GetGameManager().NPCCounter;
    TraderObj = Instantiate(Traders[0], new Vector3(SpawnPoints[RandomSpawnPoint].position.x, 0.46f, SpawnPoints[RandomSpawnPoint].position.z), SpawnPoints[RandomSpawnPoint].rotation);
    TraderObj.transform.parent = transform;
    LevelManager.instance.GetGameManager().NPCCounter++;
  }
}
