using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  [Header("Cameras")]
  //public ThirdPersonCameraRotator camera;

  public Cinemachine.Cinemachine3rdPersonFollow follow;
  [Header("Characters")]
  public GameObject ThirdPersonCharacter;
  private GameObject ThirdPersonCharacterRef;

  [Header("Enemies")]
  public GameObject EnemyLevel1;
  [Header("Game Attributes & Rules")]
  public int levers = 0;
  public int leversMax = 3;
  public WorldDetector worldDetector;
  public GameObject Crossfade;
  private void Awake()
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

  void Start()
  {

  }

  public void Init()
  {
    // Camera Init
    //GetComponent<Camera>().Init();
    // Player Generation
    //GenerateThirdPersonCharacter();
    //worldDetector.Init();
    // Enemy Generation
    int randomPoint = Random.Range(0, DungeonGenerator.instance.WayPoints.childCount);
    GenerateEnemyLevel0(new Vector2(DungeonGenerator.instance.RoomObjs[randomPoint].position.x, DungeonGenerator.instance.RoomObjs[randomPoint].position.y));
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void GenerateThirdPersonCharacter()
  {
    Vector3 position = new Vector3(0, 1, 0);
    var player = Instantiate(ThirdPersonCharacter, position, Quaternion.identity);
    var ThirdPersonPlayer = player.transform.GetChild(0);
    var target = ThirdPersonPlayer.transform.GetChild(3).transform;
    //GetComponent<Camera>().roofCheck = ThirdPersonPlayer.transform.GetChild(3).GetComponent<RoofCheck>();
    //GetComponent<Camera>()._target = target;
    //follow. = player.transform.GetChild(0); 
    ThirdPersonCharacterRef = player;
  }

  public void GenerateEnemyLevel0(Vector2 Position)
  {
    if (ThirdPersonCharacter != null)
    {
      Vector3 position = new Vector3(Position.x, 0, Position.y);
      var Enemy = Instantiate(EnemyLevel1, position, Quaternion.identity);
      //Enemy.GetComponent<CustomWander>().player = GetThirdPersonPlayerObj().transform;
      Enemy.GetComponent<CustomWander>().crossfade = Crossfade;
    }
  }

  public ThirdPersonControllerV2 GetThirdPersonPlayer()
  {
    var ThirdPersonPlayer = ThirdPersonCharacter.transform.GetChild(0).GetComponent<ThirdPersonControllerV2>();
    return ThirdPersonPlayer;
  }

  public GameObject GetThirdPersonPlayerObj()
  {
    var ThirdPersonPlayer = ThirdPersonCharacter.transform.GetChild(0).gameObject;
    return ThirdPersonPlayer;
  }

  public GameObject GetThirdPersonCharacter()
  {
    return ThirdPersonCharacter;
  }

  public RoofCheck GetRoofCheck()
  {
    var ThirdPersonPlayer = ThirdPersonCharacterRef.transform.GetChild(0);
    var target = ThirdPersonPlayer.transform.GetChild(3).GetComponent<RoofCheck>();
    return target;
  }
  
  public HandLamp GetLamp()
  {
    var ThirdPersonPlayer = ThirdPersonCharacter.transform.GetChild(0);
    var target = ThirdPersonPlayer.transform.GetChild(5).GetComponent<HandLamp>();
    return target;
  }
}
