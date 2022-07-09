using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueSystem : MonoBehaviour
{
  public static DialogueSystem instance;

  public TMP_Text NameText;
  public TMP_Text DialogueText;
  public Animator animator;
  Queue<string> Sentences;

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


  private void Start()
  {
    Sentences = new Queue<string>();
  }
  public void StartDialog(Dialogue dialogue )
  {

    animator.SetBool("IsOpen", true);
    NameText.text = dialogue.name + ":";
    Sentences.Clear();

    foreach (string sentence in dialogue.Sentences)
    {
      Sentences.Enqueue(sentence);
    }
    DisplayNextSentence();
  }

  public void DisplayNextSentence()
  {
    if (Sentences.Count == 0)
    {
      EndDialogue();
      return;
    }

    string sentence = Sentences.Dequeue();
    DialogueText.text = sentence;
  }

  void EndDialogue()
  {
    animator.SetBool("IsOpen", false);
    Debug.Log("End of conversation");
  }
}
