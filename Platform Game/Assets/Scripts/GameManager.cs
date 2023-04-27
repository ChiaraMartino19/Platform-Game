using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    private int hearth = 4;
    public Hud hud;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void LoseHearth()
    {
        hearth -= 1;
        hud.DesactivateHearth(hearth);
    }
}
