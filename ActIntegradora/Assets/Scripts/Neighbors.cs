using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbors : MonoBehaviour
{

    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.5f);
        if (this.up) Gizmos.DrawLine(transform.position, up.transform.position);
        if (this.down) Gizmos.DrawLine(transform.position, down.transform.position);
        if (this.left) Gizmos.DrawLine(transform.position, left.transform.position);
        if (this.right) Gizmos.DrawLine(transform.position, right.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
