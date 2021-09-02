using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{
    public bool check = false;
    public GameObject Box1;
    public GameObject Box2;
    public GameObject Box3;
    public GameObject Box4;
    public GameObject Box5;

    void OnCollisionEnter(Collision collision){
        GameObject objeto = collision.gameObject;

        if(collision.gameObject.tag == "Box"){
            objeto.transform.parent = transform;
            check = true;
            //while(collision.gameObject.tag == "LeftWall"){
                //transform.Translate(Vector3.left*Time.deltaTime*10);
            //}
            //while(collision.gameObject.tag == "Rack"){
                transform.Translate(Vector3.up*Time.deltaTime*10);
                if(collision.gameObject.tag == "TopWall"){
                    //while(collision.gameObject.tag != "Rack"){
                        //transform.Translate(Vector3.right*Time.deltaTime*10);
                    //}
                }
            //}
        }

        if(check){
            float x = collision.gameObject.transform.position.x;
            float y = 0.02392491f;
            float z = collision.gameObject.transform.position.z;

            GameObject RackQuitar = collision.gameObject;
            if(collision.gameObject.tag == "Rack"){
                RackQuitar.SetActive(false);
                objeto.SetActive(false);
                Instantiate(Box1, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
                check = false;
            }
            else if(collision.gameObject.tag == "Box1"){
                RackQuitar.SetActive(false);
                objeto.SetActive(false);
                Instantiate(Box2, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
                check = false;
            }
            else if(collision.gameObject.tag == "Box2"){
                RackQuitar.SetActive(false);
                objeto.SetActive(false);
                Instantiate(Box3, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
                check = false;
            }
            else if(collision.gameObject.tag == "Box3"){
                RackQuitar.SetActive(false);
                objeto.SetActive(false);
                Instantiate(Box4, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
                check = false;
            }
            else if(collision.gameObject.tag == "Box4"){
                RackQuitar.SetActive(false);
                objeto.SetActive(false);
                Instantiate(Box5, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
                check = false;
            }
            else{
                print("nada");
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
