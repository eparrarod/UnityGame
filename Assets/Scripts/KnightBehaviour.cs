﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightBehaviour : MonoBehaviour{

    float maxMovementSpeed = 1f;
    Rigidbody2D rigidBody;
    Animator animator;
    bool towardsRight = true;
    public Slider slider;
    //public Text txt;
    public float health=100;
    float speed;
    bool attacking = false;
    FlagController ctrFlag;

    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        speed = 0.6f;
        transform.localEulerAngles = new Vector3(0,180,0);
    }

    // Update is called once per frame
    void Update(){
        slider.value = health;
        attack();
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
        if(Mathf.Abs(movementSpeed) < 0.01){
            animator.SetTrigger("stop");
        }
    }

    void turnAround(){
        var t = transform.localScale;
        t.x *= -1;
        transform.localScale = t;
    }

    void OnTriggerEnter2D(Collider2D col){
        //turnAround();
        //Debug.Log(col.gameObject.name + " po : " + gameObject.name + " : " + Time.time);
    }

    void attack(){
        if (Input.GetButton("Fire1")){
            Debug.Log("Fire pressed");
        }

        if(Mathf.Abs(Input.GetAxis("Fire1")) > 0.01f){
            Debug.Log("fire1 pressed");
            if(attacking == false){
                attacking = true;
                animator.SetTrigger("attack");
                if(ctrFlag != null){
                    ctrFlag.hit();
                }
            }
        }else{
                attacking = false;
        } 
    }

    public void setFlagController(FlagController control){
        ctrFlag = control;
    }

}
