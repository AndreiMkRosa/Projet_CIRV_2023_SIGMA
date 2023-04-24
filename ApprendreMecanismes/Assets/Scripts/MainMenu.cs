using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void StartGame()
    {
        // That will permit us to pass to the next scene without the need to know the starting scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
