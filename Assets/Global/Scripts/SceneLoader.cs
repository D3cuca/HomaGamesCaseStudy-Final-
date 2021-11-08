using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    public void ChangeToInfiniteRun()
    {
        SceneManager.LoadScene("InfiniteRun");
    }
    public void ChangeToNormalRun()
    {
        SceneManager.LoadScene("NormalLevel");
    }
    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //We change the Time scale to 1 since we're calling this method from the pause menu
        Time.timeScale = 1;
    }

}
