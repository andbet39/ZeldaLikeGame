using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    private Vector3 change;
    public float speed=10;

    public VectorValue startingPosition;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        anim.SetFloat("moveX", 0);
        anim.SetFloat("moveY", -1);

        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        change  = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            anim.SetFloat("moveX", change.x);
            anim.SetFloat("moveY", change.y);
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }

    void MoveCharacter(){
        myRigidBody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }
}
