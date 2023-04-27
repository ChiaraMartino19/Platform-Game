using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
  
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<MovementPlayer>().SendMessage("Reset");
    }
}
