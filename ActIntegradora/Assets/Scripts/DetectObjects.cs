using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour{
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
        //Velocidad random
        speed = Random.Range(1, 5);
    }

    void OnCollisionEnter(Collision collision){
        //Checar las colisiones del robot
        if(collision.gameObject.tag == "Box" && !check){
            //Choca con una caja
            this.objeto = collision.gameObject; 
            objeto.transform.parent = transform; //La caja se convierte en child
            objeto.gameObject.GetComponent<Rigidbody>().useGravity = false;
            check = true;
            OneBox = false;
            objeto.gameObject.GetComponent<BoxCollider>().enabled = false; //Se quita el collider de la caja
        }

        if(check){ //Trae una caja
            float x = collision.gameObject.transform.position.x; //Obtiene la posicion X de donde choco
            float y = 0.02392491f;
            float z = collision.gameObject.transform.position.z; //Obtiene la posicion Y de donde choco

            GameObject RackQuitar = collision.gameObject; //Estante a sustituir
            if(collision.gameObject.tag == "Rack"){
                RackQuitar.SetActive(false);
                objeto.SetActive(false);
                Instantiate(Box1, new Vector3(x,y,z), Quaternion.Euler(0,0,0)); //Colocar estante con 1 caja
                check = false;
            }
            else if(collision.gameObject.tag == "Box1"){
                RackQuitar.SetActive(false);
                objeto.SetActive(false);
                Instantiate(Box2, new Vector3(x,y,z), Quaternion.Euler(0,0,0)); //Colocar estante con 2 cajas
                check = false;
            }
            else if(collision.gameObject.tag == "Box2"){
                RackQuitar.SetActive(false);
                objeto.SetActive(false);
                Instantiate(Box3, new Vector3(x,y,z), Quaternion.Euler(0,0,0)); //Colocar estante con 3 cajas
                check = false;
            }
            else if(collision.gameObject.tag == "Box3"){
                RackQuitar.SetActive(false);
                objeto.SetActive(false);
                Instantiate(Box4, new Vector3(x,y,z), Quaternion.Euler(0,0,0)); //Colocar estante con 4 cajas
                check = false;
            }
            else if(collision.gameObject.tag == "Box4"){
                RackQuitar.SetActive(false);
                objeto.SetActive(false);
                Instantiate(Box5, new Vector3(x,y,z), Quaternion.Euler(0,0,0)); //Colocar estante con 5 cajas
                check = false;
            }
        }
    }

    void Update(){
        //Hacer movimientos
        transform.LookAt(objective.transform.position); //Visualizar posicion
        transform.Translate(Vector3.forward * Time.deltaTime * speed); //Moverse para adelante
        
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
        //Camino para dejar la caja
        //El camino es todo a la izquierda, arriba y luego caminar a la derecha
        if(checkLeft){
            if(nextNodes.up){
                objective = nextNodes.up;
            }
            else{
                
                transform.Translate(Vector3.left); 
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
        //Elegir nuevo movimiento random de la lista
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