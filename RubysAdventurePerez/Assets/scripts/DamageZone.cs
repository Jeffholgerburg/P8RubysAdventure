using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
     void OnTriggerStay2D(Collider2D other)
    {
        rubycontoler controller = other.GetComponent<rubycontoler>();
        
        if (controller != null) 
        {
            controller.ChangeHealth(-1);
        }

    }
}
