using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public GameObject[] hearts;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void DesactivateHearth(int indice)
    {
        hearts[indice].SetActive(false);
    }
    public void ActivateHearth(int indice)
    {
        hearts[(indice)].SetActive(true);
    }
    
}
