using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform target;

    private void OnCollisionEnter2D(Collision2D actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            actor.gameObject.transform.position = target.position;
        }
    }
}
