using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
  public void PlayScene(string SceneName)
  {
    SceneManager.LoadScene(SceneName);
  }

  public void EndGame()
  {
     Application.Quit();
  }
}
