using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNodes : MonoBehaviour{
    public GameObject Nodo;
    int NumNodos = 81;
    public GameObject[,] arrNodos;

    void Awake(){ //Hablarle siempre primero que lo demas aunque este deshabilitado
        arrNodos = new GameObject[9,9];
        //Colocar filas de los nodos necesarios
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
                arrNodos[0,i % 9] = Instantiate(Nodo, new Vector3(x1,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 18){
                arrNodos[1,i % 9] = Instantiate(Nodo, new Vector3(x2,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 27){
                arrNodos[2,i % 9] = Instantiate(Nodo, new Vector3(x3,y,z), Quaternion.Euler(0,0,0));
            }  
            else if(i < 36){
                arrNodos[3,i % 9] = Instantiate(Nodo, new Vector3(x4,y,z), Quaternion.Euler(0,0,0));
            } 
            else if(i < 45){
                arrNodos[4,i % 9] = Instantiate(Nodo, new Vector3(x5,y,z), Quaternion.Euler(0,0,0));
            }  
            else if(i < 54){
                arrNodos[5,i % 9] = Instantiate(Nodo, new Vector3(x6,y,z), Quaternion.Euler(0,0,0));
            }   
            else if(i < 63){
                arrNodos[6,i % 9] = Instantiate(Nodo, new Vector3(x7,y,z), Quaternion.Euler(0,0,0));
            }  
            else if(i < 72){
                arrNodos[7,i % 9] = Instantiate(Nodo, new Vector3(x8,y,z), Quaternion.Euler(0,0,0));
            }   
             else if(i < 81){
                arrNodos[8,i % 9] = Instantiate(Nodo, new Vector3(x9,y,z), Quaternion.Euler(0,0,0));
            }                     
        }

        //Conectar los nodos entre ellos
        int decide = 0;
        for (int i = 0; i < 9; i++ ){ //Iterar la matriz
            for (int j = 0; j < 9; j++){
                Neighbors current = arrNodos[i,j].GetComponent<Neighbors>();
                if(j == 0 || j == 8){
                    if(i+1 < 9) current.up = arrNodos[i+1,j];
                    if(i-1 >= 0) current.down = arrNodos[i-1,j];
                }
                else if(decide == 0){
                    current.up = arrNodos[i+1,j];
                }
                else if (decide == -1){
                    current.down = arrNodos[i-1,j];
                }
                else{
                    current.up = arrNodos[i+1,j];
                    current.down = arrNodos[i-1,j];
                }
                if(j-1 >= 0) current.right = arrNodos[i,j-1];
                if(j+1 < 9) current.left = arrNodos[i,j+1];
            }
            decide ++;
            if(decide > 1) decide = -1;
        }
    }
}
