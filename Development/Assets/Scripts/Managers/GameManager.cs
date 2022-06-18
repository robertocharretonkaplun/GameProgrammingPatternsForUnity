using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  [Header("Cameras")]
  public ThirdPersonCameraRotator camera;
  [Header("Characters")]
  public GameObject ThirdPersonCharacter;
  private GameObject ThirdPersonCharacterRef;

  [Header("Game Attributes & Rules")]
  public int levers = 0;
  public int leversMax = 3;
  public WorldDetector worldDetector;
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
    camera.Init();
    //worldDetector.Init();
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
    camera._target = target;
    ThirdPersonCharacterRef = player;
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
    return ThirdPersonCharacterRef;
  }

  public RoofCheck GetRoofCheck()
  {
    var ThirdPersonPlayer = ThirdPersonCharacterRef.transform.GetChild(0);
    var target = ThirdPersonPlayer.transform.GetChild(3).GetComponent<RoofCheck>();
    return target;
  }
}
