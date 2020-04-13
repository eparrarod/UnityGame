using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour{
	private int drops;
	Animator animator;
    // Start is called before the first frame update
    void Start(){
    	animator = GetComponent<Animator>();
        drops = 3;
    }

    // Update is called once per frame
    void Update(){
        
    }

    public bool hit(){
    	bool response = false;
    	if(drops > 0){
    		response = true;
    		drops--;
    	}
    	return response;
    }
}
