using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateopeningpuzzle : MonoBehaviour
{

    [SerializeField]
    private PuzzelGateData puzzelGateData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Item")
        {
            puzzelGateData.isOpen = true;
            Debug.Log(puzzelGateData.isOpen);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Item")
        {
            puzzelGateData.isOpen = false;
            Debug.Log(puzzelGateData.isOpen);
        }
    }
}
