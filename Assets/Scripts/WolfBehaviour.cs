using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBehaviour : MonoBehaviour{

	float maxMovementSpeed = 1f;
	Rigidbody2D rigidBody;
    Animator animator;
    bool towardsRight = true;

    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    void FixedUpdate(){
        float movementSpeed = Input.GetAxis("Horizontal")*maxMovementSpeed;
        Vector2 v = new Vector2(movementSpeed, rigidBody.velocity.y);
        rigidBody.velocity = v;

        animator.SetFloat("movementSpeed", Mathf.Abs(movementSpeed));
        if((towardsRight && movementSpeed < 0)|| (!towardsRight && movementSpeed > 0)){
            turnAround();
            towardsRight = !towardsRight;
        }
        Debug.Log(movementSpeed);
        if(movementSpeed > -0.1 && movementSpeed < 0.1){
            animator.SetTrigger("Stop");
        }
    }

    void turnAround(){
        var t = transform.localScale;
        t.x *= -1;
        transform.localScale = t;
    }

    void OnTriggerEnter2D(Collider2D col){
        turnAround();
        //Debug.Log(col.gameObject.name + " po : " + gameObject.name + " : " + Time.time);
    }

    void currentState(){

    }

    void changeState(){

    }

}
