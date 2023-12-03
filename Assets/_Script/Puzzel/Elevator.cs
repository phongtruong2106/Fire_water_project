using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Elevator : MonoBehaviourPunCallbacks, IPunObservable
{
    public Transform downPos;
    public Transform upperPos;
    public GameObject platform;
    public float speed;

    private bool isevelevatordown;
    [SerializeField]
    private PhotonView view;

    private void Update()
    {
        if (view.IsMine)
        {
            InputEvalutor();
        }
    }

    private void InputEvalutor()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (platform.transform.position.y <= downPos.position.y)
            {
                isevelevatordown = true;
                photonView.RPC("SetElevatorState", RpcTarget.All, isevelevatordown);
            }
            else if (platform.transform.position.y >= upperPos.position.y)
            {
                isevelevatordown = false;
                photonView.RPC("SetElevatorState", RpcTarget.All, isevelevatordown);
            }
        }

        if (isevelevatordown)
        {
            platform.transform.position = Vector2.MoveTowards(platform.transform.position, upperPos.position, speed * Time.deltaTime);
        }
        else
        {
            platform.transform.position = Vector2.MoveTowards(platform.transform.position, downPos.position, speed * Time.deltaTime);
        }
    }

    [PunRPC]
    private void SetElevatorState(bool state)
    {
        isevelevatordown = state;
        Debug.Log("Elevator State: " + isevelevatordown);
    }

    #region IPunObservable implementation

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(isevelevatordown);
        }
        else
        {
            isevelevatordown = (bool)stream.ReceiveNext();
        }
    }

    #endregion
}
