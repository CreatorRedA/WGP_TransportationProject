using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject cubePrefab;
    public static GameObject activeCube;
    int xPos = -16;
    int yPos = 10;

    int cubeRows = 16;
    int cubeColumns = 9;
    int[,] cubeGridArr;


    void SpawnCube()
    {
        Instantiate(cubePrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
        xPos += 2;
    }


    // Start is called before the first frame update
    void Start()
    {
        GameObject[,] cubeGridArr = new GameObject[cubeRows, cubeColumns];

        //Spawn cubes in rows
        for (int i = 0; i < cubeRows; i++)
        {
            for (int k = 0; k < cubeColumns; k++)
            {
                SpawnCube();
                cubeGridArr[i, k] = cubePrefab;
                print("GameObject at position " + k + " in cubeGridArr is " + cubeGridArr[i, k]);
            }



        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ProcessClick(GameObject clickedCube)
    {
        //if there is an active cube (cube with a value assigned). If there is a red cube, make it white instead. Skips during initial run.
        if (activeCube != null) //null meaning has no value
        {
            activeCube.GetComponent<Renderer>().material.color = Color.white;
        }

        //Make the current game object the active cube
        activeCube = clickedCube; //gameObject is self referential to whatever object holds this script (each instantiated cube). Sets the activeCube variable to be THIS game object.
        clickedCube.GetComponent<Renderer>().material.color = Color.red;
    }
}