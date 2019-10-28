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
        GameObject[,] cubeGridArr = new GameObject[cubeColumns, cubeRows];

        //Spawn cubes in rows
        for (int i = 0; i < cubeColumns; i++)
        {

            for (int k = 0; k < cubeRows; k++)
            {
                //SpawnCube();
                cubeGridArr[i, k] = Instantiate(cubePrefab, new Vector3(xPos, yPos, 0), Quaternion.identity); //Does this place the cubePrefab in the array or does it use the specific cube I just spawned?
                cubeGridArr[i, k].GetComponent<CubeController>().myX = i;
                cubeGridArr[i, k].GetComponent<CubeController>().myY = k;
                xPos += 2;
                //print("GameObject at position " + i + ", " + k + " in cubeGridArr is " + cubeGridArr[i, k]);
            }

            //Move to lower row
            yPos -= 2;
            xPos = -16;

        }

        //cubeGridArr[0,0] = activeCube; causes error because activeCube is not set at Start (null)
        activeCube = cubeGridArr[0, 0];
        activeCube.GetComponent<Renderer>().material.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ProcessClick(GameObject clickedCube)
    {
        //if there is an activeCube and the cube clicked was white (not active)
        if (clickedCube.GetComponent<Renderer>().material.color == Color.white && activeCube != null)
        {
            //set the old activeCube to white + set new activeCube to the clickedCube + make the new activeCube red
            activeCube.GetComponent<Renderer>().material.color = Color.white;
            activeCube = clickedCube;
            activeCube.GetComponent<Renderer>().material.color = Color.red;
        }

        //if you click the activeCube, disable it
        else
        {
            activeCube = null;
            clickedCube.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}