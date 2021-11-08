using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndLevelInfinite : MonoBehaviour
{
    [Header("UI")]
    public GameObject SpeedUI;
    public GameObject SwipePerWipePanel;
    public GameObject RecordText;

    [Header("Other")]
    public GameObject Player;
    public GameObject PlayerModel;
    public GameObject particleSystem;
    public GameObject WorldManager;
    public GameObject RecordHolder;
    public GameObject objectSpawner;


    public void StartEndSequence()
    {
        Debug.Log("End starting");
        PlayerModel.GetComponent<Animator>().SetTrigger("Dead");
        objectSpawner.SetActive(false);
        SpeedUI.GetComponent<Animator>().SetBool("End", true);
        particleSystem.SetActive(false);
        StartCoroutine(EndTapPhase());
    }

    private IEnumerator EndTapPhase()
    {
        yield return new WaitForSeconds(1);
        RecordHolder = GameObject.Find("RecordHolder");
        float speed = WorldManager.GetComponentInChildren<SpeedController>().speed;
        if (RecordHolder.GetComponent<RecordHolder>().infiniteRecord < speed)
        {
            RecordText.SetActive(true);
            RecordHolder.GetComponent<RecordHolder>().infiniteRecord = (int)(speed);
        }
        Player.GetComponent<MovementController>().enabled = false;
        Player.GetComponent<InputControl>().enabled = false;
        SwipePerWipePanel.SetActive(false);
        SpeedUI.GetComponent<Animator>().SetBool("End", false);

    }
}
