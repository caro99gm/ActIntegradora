using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRobots : MonoBehaviour
{
    public GameObject server;

    public int NumRobots = 5;
    List<GameObject> ArrRobot;


    GameObject closestNode(GameObject[,] nodos,float x, float z){
        GameObject result = nodos[0,0];
        float minDistance = 9999999999999;

        for(int i = 0; i < nodos.GetLength(0) ; i++){
            for (int j = 0; j < nodos.GetLength(1) ; j++){
                GameObject temp = nodos[i,j];
                float distance = (x - temp.transform.position.x)*(x - temp.transform.position.x) + (z - temp.transform.position.z)*(z - temp.transform.position.z);
                if(distance < minDistance){
                    minDistance = distance;
                    result = temp;
                }
            }
        }
        return result;
    }

    void Start()
    {
        GameObject[,] nodos = GetComponent<CreateNodes>().arrNodos;
        ArrRobot = new List<GameObject>();
        for(int i = 0; i < NumRobots; i++){
            float x = Random.Range(-18 , -2);
            float y = 0;
            float z = Random.Range(-12, 12);   

            GameObject robot =  Instantiate(server, new Vector3(x,y,z), Quaternion.Euler(0,0,0));
            robot.GetComponent<DetectObjects>().objective = closestNode(nodos,x,z);
        }
    }
}