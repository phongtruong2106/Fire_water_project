using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzelGateHorizontalManager : MonoBehaviour
{
    [SerializeField]
    private PuzzelGateData puzzelGateData;
    [SerializeField]
    private Animator anim;

    private void Start()
    {
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
