using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
  public void WinCondition()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
  
  
}
