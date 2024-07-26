using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenDome : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            actor.gameObject.GetComponent<Player>().isInside = true;
        }
    }

    private void OnTriggerStay2D(Collider2D actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            actor.gameObject.GetComponent<Player>().isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            actor.gameObject.GetComponent<Player>().isInside = false;
        }
    }
}
