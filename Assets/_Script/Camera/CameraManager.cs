using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera cameraObj;
    public Vector3 cameraInitialPositition;
    public static CameraManager Instance { get; private set; }
    public float timerShake;
    private CinemachineBasicMultiChannelPerlin _cbmcp;
    private GameObject playerTarget;

     private void Awake()
    {
         Instance = this;
         cameraObj = GetComponent<CinemachineVirtualCamera>();
    }

    public void SetPlayerTarget(GameObject player)
    {
        playerTarget = player;
        cameraObj.Follow = playerTarget.transform;
    }
}
