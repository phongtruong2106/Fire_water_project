using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Photon.Pun;

public class Elevator : MonoBehaviour
{
    public Transform downPos;
    public Transform upperPos;
    public GameObject platform;
    public float speed;
    public bool isevelevatordown;
    [SerializeField]
    private bool isEleter = false;

    private void Update() {
        InputEvalutor();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        isEleter = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isEleter = false;
    }

    private void InputEvalutor()
    {
        if(isEleter && Input.GetKey(KeyCode.E))
        {
            Debug.Log("ad");
            if(platform.transform.position.y <= downPos.position.y)
            {
                isevelevatordown = true;    
                Debug.Log(isevelevatordown);
            }
            else if(platform.transform.position.y >=  upperPos.position.y)
            {
                isevelevatordown = false;
                 Debug.Log(isevelevatordown);
            } 
        }
        if(isevelevatordown)
        {
            platform.transform.position = Vector2.MoveTowards(platform.transform.position, upperPos.position, speed * Time.deltaTime);
        }
        else
        {
            platform.transform.position = Vector2.MoveTowards(platform.transform.position, downPos.position, speed * Time.deltaTime);
        }
    }

}
