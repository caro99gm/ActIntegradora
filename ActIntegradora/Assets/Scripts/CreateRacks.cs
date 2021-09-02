using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRacks : MonoBehaviour
{
    public GameObject Rack;

    public int NumRacks = 32;
    List<GameObject> ArrRacks;

    void Start()
    {
        ArrRacks = new List<GameObject>();
        for(int i = 0; i < NumRacks; i++){
            float y = 0.02392491f;
            float z = Random.Range(-10, 11);

            float x1 = Random.Range(-3 , -2);
            float x2 = Random.Range(-8 , -7);
            float x3 = Random.Range(-15 , -14);
            float x4 = Random.Range(-20 , -19);

            if(i < 8){
                Instantiate(Rack, new Vector3(x1,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 16){
                Instantiate(Rack, new Vector3(x2,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 24){
                Instantiate(Rack, new Vector3(x3,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 32){
                Instantiate(Rack, new Vector3(x4,y,z), Quaternion.Euler(0,0,0));
            }            
        }
    }
}
