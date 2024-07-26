using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
        vcam = this.gameObject.GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        vcam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
        vcam.LookAt = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
