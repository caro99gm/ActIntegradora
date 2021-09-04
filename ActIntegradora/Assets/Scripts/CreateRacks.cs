using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Crear los estantes en la escena
public class CreateRacks : MonoBehaviour{
    public GameObject Rack;
    public GameObject FakeRack;
    int NumRacks = 9;
    int NumFakeRacks = 27;
    List<GameObject> ArrRacks;
    List<GameObject> ArrFakeRacks;

    void Start(){
        ArrFakeRacks = new List<GameObject>();
        for(int i = 0; i < NumFakeRacks; i++){
            float y = 0.02392491f;
            float z = -8.5f + 2.625f * (i % 9);

            float x2 = -8.94f;
            float x3 = -14.84f;
            float x4 = -20.8f;

            if(i < 9){
                Instantiate(FakeRack, new Vector3(x2,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 18){
                Instantiate(FakeRack, new Vector3(x3,y,z), Quaternion.Euler(0,0,0));
            }
            else if(i < 27){
                Instantiate(FakeRack, new Vector3(x4,y,z), Quaternion.Euler(0,0,0));
            }            
        }

        ArrRacks = new List<GameObject>();
        for(int i = 0; i < NumRacks; i++){
            float x1 = -3.04f;
            float y = 0.02392491f;
            float z = -8.5f + 2.625f * (i % 8);

            Instantiate(Rack, new Vector3(x1,y,z), Quaternion.Euler(0,0,0));
        }
    }
}
