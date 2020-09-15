using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{

    private CharacterController characterController;
    private Animator anim;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ButtonPressed();
    }

    void ButtonPressed(){
        if (Input.GetKeyDown("space"))
        {
            Vector3 move = new Vector3(0,0,-4);
            rb.velocity = move;
            anim.SetTrigger("Jump");
        }
    }
}
