using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRobots : MonoBehaviour
{
    public GameObject server;

    public int NumRobots = 5;
    List<GameObject> ArrRobot;

    void Start()
    {
        ArrRobot = new List<GameObject>();
        for(int i = 0; i < NumRobots; i++){
            float x = Random.Range(-18 , -2);
            float y = 0;
            float z = Random.Range(-12, 12);   

            Instantiate(server, new Vector3(x,y,z), Quaternion.Euler(0,0,0));   
        }
    }
}