using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            GameManager.instance.Win();
        }
    }
}
