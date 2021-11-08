using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    [Header("UI")]
    public GameObject TapPanel;
    public GameObject SpeedUI;
    public GameObject SwipePerWipePanel;
    public GameObject DiamondUI;
    public Text DiamondText;
    public GameObject RecordText;

    [Header("Other")]
    public GameObject Player;
    public GameObject PlayerModel;
    public GameObject particleSystem;
    public GameObject WorldManager;
    public GameObject RecordHolder;


    public void StartTapSequence()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<MoveObjectTowardsPlayer>().enabled = false;
        TapPanel.SetActive(true);
        SpeedUI.GetComponent<Animator>().SetBool("End", true);
        particleSystem.SetActive(false);
        StartCoroutine(EndTapPhase());
    }

    private IEnumerator EndTapPhase()
    {
        yield return new WaitForSeconds(5);
        RecordHolder = GameObject.Find("RecordHolder");
        float speed = WorldManager.GetComponentInChildren<SpeedController>().speed;
        float points = WorldManager.GetComponentInChildren<PointsManager>().points;
        DiamondText.text = ((int)(speed * points)).ToString();
        if(RecordHolder.GetComponent<RecordHolder>().normalRecord < speed * points)
        {
            RecordText.SetActive(true);
            RecordHolder.GetComponent<RecordHolder>().normalRecord = (int)(speed * points);
        }
        TapPanel.SetActive(false);
        Player.GetComponent<MovementController>().enabled = false;
        Player.GetComponent<InputControl>().enabled = false;
        SwipePerWipePanel.SetActive(false);
        DiamondUI.GetComponent<Animator>().SetTrigger("End");
        SpeedUI.GetComponent<Animator>().SetBool("End", false);
        PlayerModel.GetComponent<Animator>().SetTrigger("Dance");
    }
}
