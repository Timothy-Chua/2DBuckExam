using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            Collect();
            this.gameObject.SetActive(false);
        }
    }

    protected virtual void Collect()
    {

    }
}
