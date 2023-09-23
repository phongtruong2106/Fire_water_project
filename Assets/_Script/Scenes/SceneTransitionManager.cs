using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SceneTransitionManager : MonoBehaviourPunCallbacks
{

    public string levelToLoad;

    private int playersAtPoint = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersAtPoint++;

            if (playersAtPoint == 2)
            {
                PhotonNetwork.LoadLevel(levelToLoad);
            }
        }
    }
    


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersAtPoint--;
        }
    }
  
}
