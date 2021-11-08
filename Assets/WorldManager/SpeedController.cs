using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedController : MonoBehaviour
{
    [Header("Texts components")]
    public Text speedText;
    public Text speedPerSwipeText;

    [Header("Speed Variables")]
    public float speed = 1;
    private float speedPerSwipe = 0;
    public float decreaseAmount;

    [Header("Particle Controller")]
    public ParticleSystem PS;
    private ParticleSystem.EmissionModule PSEmission;
    private ParticleSystem.MainModule PSMain;

    private void Start()
    {
        UpdateSpeedText();
        IncreaseSpeedPerSwipe();
        PSEmission = PS.emission;
        PSMain = PS.main;
        IncreasePSEffect();

    }

    public void IncreaseSpeed()
    {
        speed += speedPerSwipe;
        UpdateSpeedText();
        IncreasePSEffect();
    }

    public void IncreaseSpeedPerSwipe()
    {
        speedPerSwipe++;
        speedPerSwipeText.text = speedPerSwipe.ToString();
    }

    public void DecreaseSpeed()
    {
        speed -= speed/decreaseAmount;
        Debug.Log("Decreasing");
        UpdateSpeedText();
    }

    private void UpdateSpeedText()
    {
        speedText.text = "Speed: " + ((int)speed);
    }

    private void IncreasePSEffect()
    {
        //We increase the emission rate and the start speed to feel like we're going faster
        if (speed < 200)
        {
            PSEmission.rateOverTime = speed;
            // the number 30 comes from multiple tests I did to find which start speed would be correct
            //If the rate over time was at it's maximim (200)
            PSMain.startSpeed = speed / 30;
        }
    }
}
