using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Box"){
            Debug.Log("caja");
        }
        if(collision.gameObject.tag == "Rack"){
            print("rack");
        }
        if(collision.gameObject.tag == "Robot"){
            print("robot");
        }
    }
}
//poner script en el robot

//robot random

//robot


//cajas
    //agarrala -> child

//estantes
    //deja la caja


