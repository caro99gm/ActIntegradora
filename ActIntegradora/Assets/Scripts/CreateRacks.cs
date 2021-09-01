using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRacks : MonoBehaviour
{
    public GameObject Rack;

    public int NumRacks = 28;
    List<GameObject> ArrRacks;

    void Start()
    {
        ArrRacks = new List<GameObject>();
        for(int i = 0; i < NumRacks; i++){
            float y = 0.02392491f;
            float z = Random.Range(-12, 12);

            float x1 = Random.Range(-3 , -2);
            float x2 = Random.Range(-8 , -7);
            float x3 = Random.Range(-15 , -14);
            float x4 = Random.Range(-20 , -19);

            if(i < 7){
                Instantiate(Rack, new Vector3(x1,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 14){
                Instantiate(Rack, new Vector3(x2,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 21){
                Instantiate(Rack, new Vector3(x3,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 28){
                Instantiate(Rack, new Vector3(x4,y,z), Quaternion.Euler(0,0,0));
            }            
        }
    }
}
