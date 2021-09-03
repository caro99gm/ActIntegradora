using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNodes : MonoBehaviour
{
    public GameObject Nodo;

    int NumNodos = 90;
    List<GameObject> ArrNodos;

//-12.14 15.8
    void Start()
    {
        ArrNodos = new List<GameObject>();
        for(int i = 0; i < NumNodos; i++){
            float y = 0.02392491f;
            float z = -12.14f + 3.5f* (i % 9);

            float x1 = -19.5f;
            float x2 = -18f;
            float x3 = -16.3f;

            float x4 = -13.5f;
            float x5 = -11.9f;
            float x6 = -10.38f;

            float x7 = -7.75f;
            float x8 = -6.21f;
            float x9 = -4.57f;

            if(i < 9){
                Instantiate(Nodo, new Vector3(x1,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 18){
                Instantiate(Nodo, new Vector3(x2,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 27){
                Instantiate(Nodo, new Vector3(x3,y,z), Quaternion.Euler(0,0,0));
            }  
            else if(i < 36){
                Instantiate(Nodo, new Vector3(x4,y,z), Quaternion.Euler(0,0,0));
            } 
            else if(i < 45){
                Instantiate(Nodo, new Vector3(x5,y,z), Quaternion.Euler(0,0,0));
            }  
            else if(i < 54){
                Instantiate(Nodo, new Vector3(x6,y,z), Quaternion.Euler(0,0,0));
            }   
            else if(i < 63){
                Instantiate(Nodo, new Vector3(x7,y,z), Quaternion.Euler(0,0,0));
            }  
            else if(i < 72){
                Instantiate(Nodo, new Vector3(x8,y,z), Quaternion.Euler(0,0,0));
            }   
             else if(i < 81){
                Instantiate(Nodo, new Vector3(x9,y,z), Quaternion.Euler(0,0,0));
            }                     
        }
    }
}
