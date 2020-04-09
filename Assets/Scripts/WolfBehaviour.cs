using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WolfBehaviour : MonoBehaviour{

    Rigidbody2D rigidBody;
    public Animator animator;
    private float speed;

    // Start is called before the first frame update
    void Start(){
        rigidBody = GetComponent<Rigidbody2D>();
        speed = 0.6f;
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("walk", true);
    }

    // Update is called once per frame
    void Update(){
        
    }

    void FixedUpdate(){
        Vector2 v = new Vector2(speed, 0);
        rigidBody.velocity = v;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk") && Random.value < 1/(60f*3f)){
            Debug.Log("walking to Howl");
            animator.SetTrigger("Howl");
        }
        // }else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Howl")){
        //     if(Random.value < 1f/3f){
        //         Debug.Log("howling to Bite");
        //         //speed = 0;
        //         animator.SetTrigger("Bite");
        //     }else{
        //         Debug.Log("howling to walk");
        //         speed = 0.4f;
        //         animator.SetTrigger("Walk");
        //     }
        // }

    }

    public void setSpeed(float s){
        speed = s;
    }

    public float getSpeed(){
        return speed;
    }

    void turnAround(){
        speed *= -1;
        var t = transform.localScale;
        t.x *= -1;
        transform.localScale = t;
    }

    void OnTriggerEnter2D(Collider2D col){
        turnAround();
    }
}
