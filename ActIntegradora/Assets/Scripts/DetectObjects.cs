using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{
    public bool check = false;
    public bool OneBox = true;
    public GameObject Box1;
    public GameObject Box2;
    public GameObject Box3;
    public GameObject Box4;
    public GameObject Box5;
    private GameObject objeto;

    void OnCollisionEnter(Collision collision){
        

        if(collision.gameObject.tag == "Box" && !check){
            this.objeto = collision.gameObject;
            objeto.transform.parent = transform;
            objeto.gameObject.GetComponent<Rigidbody>().useGravity = false;
            check = true;
            OneBox = false;
            objeto.gameObject.GetComponent<BoxCollider>().enabled = false;
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

    void Update(){
//while(collision.gameObject.tag == "LeftWall"){
                //transform.Translate(Vector3.left*Time.deltaTime*10);
            //}
            //while(collision.gameObject.tag == "Rack"){
                //while(collision.gameObject.tag != "Rack"){
                        //transform.Translate(Vector3.right*Time.deltaTime*10);
                    //}}

    }
}

//1. Ir buscando cajas
//2. Tengo una caja, ir hasta arriba a la izquierda a dejarla
//3. El rack no empieza desde la esquina de la izquierda
//4. Moverte hasta la derecha hasta encontrar el rack
//5. Si el rack tiene menor a 5 cajas, dejarla
//6. Si tiene mas de 5, dejarla en el siguiente rack que se encuentre mas adelante
//7. Robot choca