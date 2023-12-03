using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PuzzelGateManager : MonoBehaviour
{
    [SerializeField]
    private PuzzelGateData puzzelGateData;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private PhotonView view;

    private void Start()
    {
        anim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
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
