using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Obtener los nodos cercanos del nodo referenciado
public class Neighbors : MonoBehaviour{
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);
        if (this.up) Gizmos.DrawLine(transform.position, up.transform.position);
        if (this.down) Gizmos.DrawLine(transform.position, down.transform.position);
        if (this.left) Gizmos.DrawLine(transform.position, left.transform.position);
        if (this.right) Gizmos.DrawLine(transform.position, right.transform.position);
    }
}
