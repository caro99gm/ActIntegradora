using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{
    public int check = 0;
    public GameObject Box1;
    public GameObject Box2;
    public GameObject Box3;
    public GameObject Box4;
    public GameObject Box5;

    void OnCollisionEnter(Collision collision){
        GameObject objeto = collision.gameObject;

        if(collision.gameObject.tag == "Box"){
            transform.parent = objeto.transform;
            check = 1;
            while(collision.gameObject.tag == "LeftWall"){
                transform.Translate(Vector3.left*Time.deltaTime*10);
            }
            while(collision.gameObject.tag == "TopWall" && collision.gameObject.tag == "Rack"){
                transform.Translate(Vector3.up*Time.deltaTime*10);
                if(collision.gameObject.tag == "TopWall"){
                    while(collision.gameObject.tag != "Rack"){
                        transform.Translate(Vector3.right*Time.deltaTime*10);
                    }
                }
                if(collision.gameObject.tag == "Rack"){
                    float x = Random.Range(-3 , -2);
                    float y = 0.02392491f;
                    float z = Random.Range(-10, 0);

                    if(collision.gameObject.tag == "Rack"){
                        Instantiate(Box1, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
                    }
                    else if(collision.gameObject.tag == "Box1"){
                        Instantiate(Box2, new Vector3(x,y,z), Quaternion.Euler(0,0,0));

                    }
                    else if(collision.gameObject.tag == "Box2"){
                        Instantiate(Box3, new Vector3(x,y,z), Quaternion.Euler(0,0,0));

                    }
                    else if(collision.gameObject.tag == "Box3"){
                        Instantiate(Box4, new Vector3(x,y,z), Quaternion.Euler(0,0,0));

                    }
                    else if(collision.gameObject.tag == "Box4"){
                        Instantiate(Box5, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
                    }
                    else{
                        print("nada");
                    }
                }
            }
        }

        

        if(collision.gameObject.tag == "Robot"){
            
            print("robot");
        }
    }
}


//Faltanes:
//Mover robot
//Chocar entre robots
//Obtener posicion en Z para poner el nuevo rack
//Quitar el rack anterior
