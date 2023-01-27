using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed=5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
