using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    [Header("Texts components")]
    public Text DiamondText;

    [Header("Points Variables")]
    public float points = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePointsText();
    }

    public void IncreaseDiamond()
    {
        points++;
        UpdatePointsText();
    }

    public void UpdatePointsText()
    {
        DiamondText.text = points.ToString();
    }

}
