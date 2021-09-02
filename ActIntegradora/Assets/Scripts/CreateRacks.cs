using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRacks : MonoBehaviour
{
    public GameObject Rack;
    public GameObject FakeRack;

    public int NumRacks = 8;
    public int NumFakeRacks = 24;
    List<GameObject> ArrRacks;
    List<GameObject> ArrFakeRacks;

    void Start()
    {
        ArrFakeRacks = new List<GameObject>();
        for(int i = 0; i < NumFakeRacks; i++){
            float y = 0.02392491f;
            float z = Random.Range(-10, 11);

            float x2 = -8.94f;
            float x3 = -14.84f;
            float x4 = -20.8f;

            if(i < 8){
                Instantiate(FakeRack, new Vector3(x2,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 16){
                Instantiate(FakeRack, new Vector3(x3,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 24){
                Instantiate(FakeRack, new Vector3(x4,y,z), Quaternion.Euler(0,0,0));
            }            
        }

        ArrRacks = new List<GameObject>();
        for(int i = 0; i < NumRacks; i++){
            float x1 = -3.04f;
            float y = 0.02392491f;
            float z = Random.Range(-10, 11);

            Instantiate(Rack, new Vector3(x1,y,z), Quaternion.Euler(0,0,0));
        }
    }
}
