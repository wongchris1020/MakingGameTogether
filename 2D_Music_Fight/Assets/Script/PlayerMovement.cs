using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    private bool isJumping = false;
    private Rigidbody2D rb;
    private bool jumpCounter=false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        normalMove();
        

        if(jumpCounter==false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                //Debug.Log("Space pressed 1");
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpCounter=true;
               StartCoroutine(Delay(0.1f));
         
             }
        }
        else if(jumpCounter==true)
        {
             if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                //Debug.Log("Space pressed 2");
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping=true;          
             }  
        }

    }

    void normalMove()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(moveSpeed*Time.deltaTime,0,0);
        }
        else if(Input.GetKey(KeyCode.A))
        {
         transform.Translate(-moveSpeed*Time.deltaTime,0,0);
 
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
             jumpCounter=false; 
        }
    }

     IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Delay finished");
    }
}
