using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  [Header("UI")]
  public GameObject TradeWindow;
  public TMP_Text DialogName;
  public TMP_Text Dialog;

  public Animator MenuAnimator;
  public GameObject Menu;
  public bool IsMenuActive;
  [Header("Cameras")]
  //public ThirdPersonCameraRotator camera;

  public Cinemachine.Cinemachine3rdPersonFollow follow;
  [Header("Characters")]
  public GameObject ThirdPersonCharacter;
  private GameObject ThirdPersonCharacterRef;

  [Header("Enemies")]
  public bool LevelHasEnemies = false;
  public GameObject EnemyLevel1;
  [Header("Game Attributes & Rules")]
  public int levers = 0;
  public int leversMax = 3;
  public int NPCCounter = 0;
  public int WallType = 3;
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
    if (LevelHasEnemies)
    {
      int randomPoint = Random.Range(0, DungeonGenerator.instance.WayPoints.childCount);
      GenerateEnemyLevel0(new Vector2(DungeonGenerator.instance.RoomObjs[randomPoint].position.x, DungeonGenerator.instance.RoomObjs[randomPoint].position.y));
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      ActivateMenu();
    }
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

  public void ActivateMenu()
  {
    if (!IsMenuActive)
    {
      Menu.SetActive(true);
      MenuAnimator.SetBool("IsOpen", false);
      IsMenuActive = true;
      if (!MenuAnimator.enabled)
      {

        Time.timeScale = 0;
      }
      Cursor.lockState = CursorLockMode.None;
    }
    else
    {
      //MenuAnimator.SetBool("IsOpen", true);

      Menu.SetActive(false);
      IsMenuActive = false;
      Time.timeScale = 1;
      Cursor.lockState = CursorLockMode.Locked;
    }
  }

  public void DeactivateMenu()
  {
    if (IsMenuActive)
    {
      Menu.SetActive(false);
      IsMenuActive = false;
      Time.timeScale = 1;
      Cursor.lockState = CursorLockMode.Locked;
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

  public GameObject GetTradeWindow()
  {
    return TradeWindow;
  }

  public TMP_Text GetNameText()
  {
    return DialogName;
  }

  public TMP_Text GetDialogText()
  {
    return Dialog;
  }


  public int GetWallType()
  {
    return WallType;
  }
}
