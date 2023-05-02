using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hud : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI points;

    
    void Update()
    {
        points.text = gameManager.TotalPoints.ToString();

    }
}
