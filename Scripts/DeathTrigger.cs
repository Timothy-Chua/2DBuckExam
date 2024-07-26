using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            actor.gameObject.GetComponent<Player>().Death();
        }
    }
}
