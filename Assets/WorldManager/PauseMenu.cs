using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    public List<GameObject> listToAffect;
    public GameObject pausePanel;

    public void PauseGame()
    {
        Time.timeScale = 0;
        foreach(GameObject g in listToAffect)
        {
            g.SetActive(false);
        }

        pausePanel.SetActive(true);
    }

    public void UnpauseGame()
    {
        pausePanel.SetActive(false);
        foreach (GameObject g in listToAffect)
        {
            g.SetActive(true);
        }
        Time.timeScale = 1;
    }
}
