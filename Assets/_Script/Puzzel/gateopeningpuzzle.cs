using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateopeningpuzzle : MonoBehaviour
{

    [SerializeField]
    private PuzzelGateData puzzelGateData_Horizontal;
    [SerializeField]
    private PuzzelGateData puzzelGateData_Vetical;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Item")
        {
            puzzelGateData_Vetical.isOpen = true;
            if(puzzelGateData_Horizontal != null)
            {
                puzzelGateData_Horizontal.isOpen = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Item")
        {
            puzzelGateData_Vetical.isOpen = false;
            if(puzzelGateData_Horizontal != null)
            {
                puzzelGateData_Horizontal.isOpen = false;
            }
        }
    }
}
