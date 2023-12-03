using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PuzzelGateHorizontalManager : MonoBehaviour
{
    [SerializeField]
    private PuzzelGateData puzzelGateData;
    [SerializeField]
    private Animator anim;
      [SerializeField]
    private PhotonView view;


    private void Start()
    {
        view = GetComponent<PhotonView>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        GateOpen();
    }

    private void GateOpen()
    {
         anim.SetBool("Open", puzzelGateData.isOpen);
        
    }
}
