using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NPC : Interaction
{
  [Header("NPC General Settings")]
  public string NPCName;
  public TMP_Text NPCNameText;
  public Animator animator;

  [Header("NPC Dialog Settings")]
  public string[] Dialogs;
  public TMP_Text NPCDialogText;
  public int dialogIndex = 0;
  public bool IsSpeaking;
  [Header("NPC Trading Settings")]
  public bool IsNPCATrader;
  public GameObject[] ObjectsToTrade;

  [Header("NPC AI Settings")]
  public bool IsNPCAnAgent;
  public int AgentID = 0;
  public float AgentViewDistance = 8f;
  public float AgentSpeed = 10.0f;
  public float AgentTurnSpeed = 25.0f;
  public bool CanSeek;
  public Transform target;
  public bool CanWonder;
  public Transform[] WonderPoints;
  public bool CanAvoidOtherAgents;
  public Transform[] ObjectsToAvoid;



  // Start is called before the first frame update
  void Start()
  {
    // Dialog system
    InitDialogSystem();
  }

  // Update is called once per frame
  void Update()
  {
    if (LevelManager.instance.GetGameManager().GetThirdPersonCharacter() != null)
    {
      CheckIfTargetIsClose(LevelManager.instance.GetGameManager().GetThirdPersonCharacter().transform.position);
      // Dialog system
      DialogSystem();
    }
  }

  void InitDialogSystem()
  {
    NPCNameText.text = NPCName + ":";
    NPCDialogText.text = Dialogs[dialogIndex];
  }
  void DialogSystem()
  {
    NPCDialogText.text = Dialogs[dialogIndex];
    if (Input.GetKeyDown(KeyCode.E))
    {
      IsSpeaking = true;
      NPCNameText.transform.gameObject.SetActive(true);
      NPCDialogText.transform.gameObject.SetActive(true);
    }
    if (!IsInteracting)
    {
      IsSpeaking = false;
    }
    NPCNameText.transform.gameObject.SetActive(IsSpeaking);
    NPCDialogText.transform.gameObject.SetActive(IsSpeaking);
  }
}
