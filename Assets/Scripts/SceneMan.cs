using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class SceneMan : MonoBehaviour
{
   public void LoadToScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
   }
   public void ExitGame() {
        Application.Quit();
    }
}
