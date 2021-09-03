using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour
{
    public bool check = false;
    private bool checkLeft = false;
    private bool topRow = false;
    public bool OneBox = true;
    public int speed = 0;
    public GameObject Box1;
    public GameObject Box2;
    public GameObject Box3;
    public GameObject Box4;
    public GameObject Box5;
    private GameObject objeto;

    public GameObject objective;

    void Start(){
        speed = Random.Range(1, 5);
    }

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
        transform.LookAt(objective.transform.position);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
        if(Vector3.Distance(transform.position,objective.transform.position) < 1.4f){
            //ver los nodos vecinos y elegir uno a random
            Neighbors nextNodes = objective.GetComponent<Neighbors>();
            if (check){
                chooseDeliverBox(nextNodes);
            }
            else{
                checkLeft = false;
                topRow = false;
                chooseRandom(nextNodes);
            }
            
            //si lleva caja elegir el left o el up o el right 
        }
    }

    void chooseDeliverBox(Neighbors nextNodes){
        
        if(checkLeft){
            if(nextNodes.up){
                objective = nextNodes.up;
            }
            else{
                
                transform.Translate(Vector3.left); 
                //topRow = true;
                objective = nextNodes.right;
            }
        }
        else{
            if(nextNodes.left){
                objective = nextNodes.left;
            }
            else{
                checkLeft = true;
                chooseDeliverBox(nextNodes);
            }
        }
    }

    void chooseRandom(Neighbors nextNodes){
        int choice = Random.Range(0,4);
        print(choice);
        bool picking = true;
        while(picking){
             switch (choice){
                case 0:
                    if(nextNodes.up != null){
                        objective = nextNodes.up;
                        picking = false;
                    }
                    break;
                case 1:
                    if(nextNodes.right != null){
                        objective = nextNodes.right;   
                        picking = false;
                    }
                    break;
                case 2:
                    if(nextNodes.down != null){
                        objective = nextNodes.down;
                        picking = false;
                    }
                    break;
                default:
                    if(nextNodes.left != null){
                        objective = nextNodes.left;
                        picking = false;
                    }
                    break;
            }
            choice = (choice + 1) % 4;
        }
           
    }
}