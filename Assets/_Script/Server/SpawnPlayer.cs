using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    public  Transform[] spawnPoints;
    public CameraManager cameraManager;

    private void Start() {
        int randomNumber = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNumber];
        PhotonNetwork.Instantiate(player.name,spawnPoint.position, Quaternion.identity);
        cameraManager.SetPlayerTarget(player);
    }
}
