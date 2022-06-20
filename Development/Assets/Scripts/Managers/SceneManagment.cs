using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
  public static SceneManagment instance;
  public Animator TransitionCrossfade;
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

  public void ChangeToRandomScene()
  {
    int SceneIndex = Random.Range(0, SceneManager.sceneCount);

    SceneManager.LoadScene(SceneIndex);
    StartCoroutine(LoadLevel(SceneIndex));
  }

  public void LoadLevel_0()
  {
    StartCoroutine(LoadLevel(0));
  }

  IEnumerator LoadLevel(int LevelIndex)
  {
    TransitionCrossfade.SetTrigger("Start");

    yield return new WaitForSeconds(transitionTime);
    SceneManager.LoadScene(LevelIndex);
  }
}
