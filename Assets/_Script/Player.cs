
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrouned;
    [SerializeField]
    private float forceAmount;
    private float timeElapsed;
    private bool isMoving = false;

    [SerializeField]
    private PhotonView view;

    [SerializeField]
    private BaseeDataPlayer data_Player;


    private void Start() {
        view = GetComponent<PhotonView>();
        rb.velocity = Vector3.down * forceAmount;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if(view.IsMine)
        {
            timeElapsed += Time.deltaTime;
            float horizontalInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector3(horizontalInput * data_Player.SpeedMove, rb.velocity.y);
            float xScale = Mathf.Abs(transform.localScale.x);
            if (horizontalInput > 0.1f)
            {
                transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
            }        
            else
            {
                transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
            }  

            Jump();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrouned)
        {
            rb.velocity = new Vector2(rb.velocity.x, data_Player.Jump_fouce);
            isGrouned = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    
            if (collision.gameObject.tag == "Ground")
            {
                isGrouned = true;  
            }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

}
