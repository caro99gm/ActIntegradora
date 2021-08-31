using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoxes : MonoBehaviour
{
    public GameObject box;

    public int NumBoxes = 15;
    List<GameObject> ArrBoxes;

    void Start()
    {
        ArrBoxes = new List<GameObject>();
        for(int i = 0; i < NumBoxes; i++){
            float x = Random.Range(-18 , -2);
            float y = 0.34f;
            float z = Random.Range(-12, 12);   

            Instantiate(box, new Vector3(x,y,z), Quaternion.Euler(0,0,0));   
        }
    }
}
