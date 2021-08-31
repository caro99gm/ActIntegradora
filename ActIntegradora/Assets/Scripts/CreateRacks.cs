using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRacks : MonoBehaviour
{
    public GameObject Rack;

    public int NumRacks = 30;
    List<GameObject> ArrRacks;

    void Start()
    {
        ArrRacks = new List<GameObject>();
        for(int i = 0; i < NumRacks; i++){
            float x = Random.Range(-18 , -2);
            float y = 0;
            float z = Random.Range(-12, 12);

            if(i < NumRacks/9){
                Instantiate(Rack, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < NumRacks/6){
                Instantiate(Rack, new Vector3(x,y,z), Quaternion.Euler(0,90,0));
            } 
            else if(i < NumRacks/3){
                Instantiate(Rack, new Vector3(x,y,z), Quaternion.Euler(0,270,0));
            }  
            else{
                Instantiate(Rack, new Vector3(x,y,z), Quaternion.Euler(0,180,0));
            }           
        }
    }
}
