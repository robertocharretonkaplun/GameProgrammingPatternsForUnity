using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
public class NPC : Interaction
{
  [Header("NPC General Settings")]
  public int id;
  public string NPCName;
  public TMP_Text NameText;
  public Animator animator;

  [Header("NPC General Stats")]
  public float CurrentHealth;
  public const float MaxHealth = 500.0f;
  public static float stamina = 250.0f;

  [Header("NPC Dialog Settings")]
  public string[] Dialogs;
  public GameObject DialogPref;
  public int dialogIndex = 0;
  public bool IsSpeaking;
  private GameObject DialogRef;

  [Header("NPC Trading Settings")]
  public bool IsNPCATrader;
  public string[] TradeDialogs;
  public GameObject[] ObjectsToTrade;
  public GameObject TradeUI;
  public bool IsTrading;

  [Header("NPC AI Settings")]
  public Transform AIStartPos;
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
    //EventSystem.instance.OnDialogEnable += OnDialogEnable;
    //EventSystem.instance.OnDialogDesable += OnDialogDesable;


    // Trade System
    //TradeUI = LevelManager.instance.GetGameManager().GetTradeWindow();
    // AI
    AgentID = AIManager.instance.NewAgent(GetComponent<NavMeshAgent>(), AgentSpeed);
  }

  // Update is called once per frame
  void Update()
  {
    if (LevelManager.instance.GetGameManager().GetThirdPersonCharacter() != null)
    {
      CheckIfTargetIsClose(LevelManager.instance.GetGameManager().GetThirdPersonCharacter().transform.position);
      // Dialog system
      DialogSystemM();
      // Trade System
      TradeSystem();
      // AI
      AI();
    }
  }

  void InitDialogSystem()
  {
    NameText.text = NPCName;
  }
  void DialogSystemM()
  {
    if (IsInteracting)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        if (!IsSpeaking)
        {
          GetComponent<DialogTrigger>().TriggerDialoge();
          IsSpeaking = true;
        }
        else
        {

          DialogueSystem.instance.DisplayNextSentence();
        }
      }

    }
    else
    {
      // EventSystem.instance.OnDialogInteractionExit();
      IsSpeaking = false;
    }
  }

  void TradeSystem()
  {
    if (IsNPCATrader)
    {
      if (Input.GetKeyDown(KeyCode.F))
      {
        if (!IsTrading)
        {
          TradeUI.SetActive(true);
          IsTrading = true;
        }
        else
        {
          TradeUI.SetActive(false);
          IsTrading = false;
        }
      }
    }

    if (!IsInteracting)
    {
      IsTrading = false;
      TradeUI.SetActive(false);
    }
  }

  public void AI()
  {
    if (IsNPCAnAgent)
    {
      AIManager.instance.FollowTarget(target, target.position);
    }
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.cyan;
    Gizmos.DrawWireSphere(InteractionPoint.position, InteractionDistance);
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(AIStartPos.position, AgentViewDistance);

  }



}
