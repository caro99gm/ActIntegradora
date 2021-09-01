using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Box"){
            print("caja");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
//poner script en el robot

//robot random

//robot


//cajas
    //agarrala -> child

//estantes
    //deja la caja


