using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
  public static SceneManagment instance;
  public Animator TransitionCrossfade;
  public Animator TitleCrossfade;
  public float transitionTime = 1f;

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

  private void Update()
  {
    if (Input.GetKey(KeyCode.Alpha1))
    {
      LoadLevel_0();
    }
    if (Input.GetKey(KeyCode.Alpha2))
    {
      StartCoroutine(LevelTitle());
    }
  }

  public void ChangeToRandomScene()
  {
    int SceneIndex = Random.Range(0, SceneManager.sceneCount);

    SceneManager.LoadScene(SceneIndex);
    StartCoroutine(LoadLevel(SceneIndex));
  }

  public void LoadMainMenu()
  {
    StartCoroutine(LoadLevel(0));
  }

  public void LoadLevel_0()
  {
    StartCoroutine(LoadLevel(1));
    //StartCoroutine(LevelTitle());
  }

  IEnumerator LoadLevel(int LevelIndex)
  {
    TransitionCrossfade.SetTrigger("Start");

    yield return new WaitForSeconds(transitionTime);
    SceneManager.LoadScene(LevelIndex);
  }
  
  public void SetLevelTitle()
  {
    StartCoroutine(LevelTitle());
  }

  IEnumerator LevelTitle()
  {
    //TitleCrossfade.Play("TitleCrossfade");

    //TitleCrossfade.SetBool("Start", true);
    yield return new WaitForSeconds(10);
    //TitleCrossfade.SetBool("Start", false);
    //TitleCrossfade.SetTrigger("End");
  }

  public void ExitGame()
  {
    Application.Quit();
  }
}
