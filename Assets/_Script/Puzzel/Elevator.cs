using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public GameObject player;
    public Transform evavatorSwitch;
    public Transform downpos;
    public Transform upperpos;
    public SpriteRenderer elevator;

    public float speed;

    public bool isevelevatordown;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update() {
        StartElevator();
        DisplayColor();
    }
    private void StartElevator()
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

        if( isevelevatordown)
        {
            transform.position = Vector2.MoveTowards(transform.position,  upperpos.position,  speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,  downpos.position,  speed * Time.deltaTime);
        }
    }

    private void DisplayColor()
    {
        if(transform.position.y <= downpos.position.y || transform.position.y >= upperpos.position.y)
        {
            elevator.color = Color.green;
        }
        else
        {
            elevator.color  = Color.red;
        }
    }
}
