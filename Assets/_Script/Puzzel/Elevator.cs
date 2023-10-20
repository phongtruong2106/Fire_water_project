using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Photon.Pun;

public class Elevator : MonoBehaviour
{

    public GameObject player;
    public Transform evavatorSwitch;
    public Transform downpos;
    public Transform upperpos;
    public SpriteRenderer elevator;
    public float speed;
    public bool isevelevatordown;
    private PhotonView photonView;
     private string elevatorColor;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
        photonView = GetComponent<PhotonView>();
    }
    private void Update() {
        StartElevator();
        DisplayColor();
    }
    private void StartElevator()
    {
        if (photonView.IsMine)
        {
            if(Vector2.Distance(player.transform.position, evavatorSwitch.position) < 0.5f && Input.GetKey(KeyCode.E))
            {
                if(transform.position.y <= downpos.position.y)
                {
                    isevelevatordown = true;
                }
                else if(transform.position.y >=  upperpos.position.y)
                {
                    isevelevatordown = false;
                }
            }

            if (isevelevatordown)
            {
                photonView.RPC("MoveElevator", RpcTarget.All, upperpos.position);
            }
            else
            {
                photonView.RPC("MoveElevator", RpcTarget.All, downpos.position);
            }
        }
    }


    
private void DisplayColor()
{
    string colorString;
    if (transform.position.y <= downpos.position.y || transform.position.y >= upperpos.position.y)
    {
        colorString = "green"; // Đại diện cho màu xanh lá cây
    }
    else
    {
        colorString = "red"; // Đại diện cho màu đỏ
    }

    photonView.RPC("SetElevatorColor", RpcTarget.All, colorString);
}
    [PunRPC] // Đánh dấu phương thức này để đồng bộ hóa
    private void MoveElevator(Vector3 targetPosition)
    {
        // Di chuyển thang máy đến vị trí được chỉ định
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    [PunRPC]
    private void SetElevatorColor(string colorString)
    {
        Color color;
        if (colorString == "green")
        {
            color = Color.green;
        }
        else
        {
            color = Color.red;
        }

        elevator.color = color;
    }
}
