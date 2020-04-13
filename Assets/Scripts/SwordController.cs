using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour{

    FlagController flagController;
    KnightBehaviour knightController;
    // Start is called before the first frame update
    void Start(){
        knightController = GameObject.Find("knight").GetComponent<KnightBehaviour>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnTriggerEnter2D(Collider2D target){
        if (target.gameObject.name.Equals("flag")){
            knightController.setFlagController(target.gameObject.GetComponent<FlagController>());
            Debug.Log(target.gameObject.name + " po : " + gameObject.name + " : " + Time.time);
        }
    }

    void OnTriggerExit2D(Collider2D target){
        if (target.gameObject.name.Equals("flag")){
            //Debug.Log(target.gameObject.name + " po : " + gameObject.name + " : " + Time.time);
            knightController.setFlagController(null);
        }
        
    }
}
