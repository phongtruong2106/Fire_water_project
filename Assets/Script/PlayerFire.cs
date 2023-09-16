using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    private BaseeDataPlayer baseeDataPlayer;
    [SerializeField]
    private BaseeDataSystem baseeDataSystem;
    [SerializeField]
    private GameObject obj_Player;
    [SerializeField]
    private GameObject respawnPoint;
    private void Start()
    {    
        respawnPoint = GameObject.Find("targetRepawnPoint");
    }
    private void Update()
    {
        Die();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Water")
       {
            baseeDataPlayer.isDie = true;
       }
       if(other.tag == "Fire")
       {
            baseeDataPlayer.isDie = false;
       }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Fire")
        {
            baseeDataPlayer.isDie = false;
        }
        if (other.tag == "Water")
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
        obj_Player.transform.position = respawnPoint.transform.position;

        // Reactivate the player object
        obj_Player.SetActive(true);

        baseeDataPlayer.isDie = false;
    }
}
