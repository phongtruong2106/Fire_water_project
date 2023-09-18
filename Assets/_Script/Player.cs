using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrouned;

    [SerializeField]
    private PhotonView view;

    [SerializeField]
    private BaseeDataPlayer data_Player;


    private void Start() {
        view = GetComponent<PhotonView>();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        
    }

    private void Update()
    {
        if(view.IsMine)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector3(horizontalInput * data_Player.SpeedMove, rb.velocity.y);
            //flip player when moving left right
            if (horizontalInput > 0.1f)
                transform.localScale = Vector3.one;
            else if (horizontalInput < -0.1f)
                transform.localScale = new Vector3(-1, 1, 1);
            if (Input.GetKey(KeyCode.Space) && isGrouned)
                Jump();
        }
       
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, data_Player.Jump_fouce);
       /* anim.SetTrigger("jump");*/
        isGrouned = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrouned = true;
            
        }
        if(collision.gameObject.tag == "elevator")
        {
            transform.parent = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "elevator")
        {
            transform.parent = null;
        }
    }

}
