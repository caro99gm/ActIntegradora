using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Visualizar nodo y caminos trazados
public class display : MonoBehaviour{
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
