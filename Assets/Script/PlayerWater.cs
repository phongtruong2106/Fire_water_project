﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWater : MonoBehaviour
{
    [SerializeField]
    private BaseeDataPlayer baseeDataPlayer;
    [SerializeField]
    private BaseeDataSystem baseeDataSystem;
    [SerializeField]
    private GameObject obj_Player;
    [SerializeField]
    private Transform respawnPoint;
     [SerializeField]
    private string targetRespawnPointName = "targetRespawnPoint"; 
    private void Start()
    {
        GameObject targetRespawnGameObject = GameObject.Find(targetRespawnPointName);

        if (targetRespawnGameObject != null)
        {
            respawnPoint = targetRespawnGameObject.transform;
        }
        else
        {
            Debug.LogError("Không tìm thấy GameObject có tên '" + targetRespawnPointName + "'");
        }
    }
    private void Update()
    {
        Die();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Fire")
       {
            baseeDataPlayer.isDie = true;
       }
       if(other.tag == "Water")
       {
            baseeDataPlayer.isDie = false;
       }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Water")
        {
            baseeDataPlayer.isDie = false;
        }
        if (other.tag == "Fire")
        {
            baseeDataPlayer.isDie = true;
        }
    }
    
    private void Die()
    {
        if(baseeDataPlayer.isDie)
        {
            // Deactivate the player object
            obj_Player.SetActive(false);

            Invoke(nameof(Live), 3);
        }
    }

    private void Live()
    {
        // Move the player to the respawn point
        obj_Player.transform.position = respawnPoint.position;

        // Reactivate the player object
        obj_Player.SetActive(true);

        baseeDataPlayer.isDie = false;
    }
}
