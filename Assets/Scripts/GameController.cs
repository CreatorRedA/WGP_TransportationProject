using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //CHALLNEGES: Add materials + Rotate Airplane + Make delivery point change + Show delivered cargo + Show text on screen and fade
    public GameObject cubePrefab;
    public static GameObject airplaneCube;
    public static GameObject deliveryCube;
    public Text cargoText;
    public Text scoreText;

    int xPos = -16;
    int yPos = 10;

    int cubeColumns = 9;
    int cubeRows = 16;
    static GameObject[,] cubeGridArr;

    public float turnTimer = 1.5f;
    float turnLength = 1.5f;

    static int currentCargo = 0;
    static int cargoCap = 90;
    static int deliveredCargo;

    //At start: Create sky cubes and set the airplane. Set the delivery point.
    void Start()
    {
        cubeGridArr = new GameObject[cubeColumns, cubeRows];

        //Spawn cubes in rows
        for (int i = 0; i < cubeColumns; i++)
        {

            for (int k = 0; k < cubeRows; k++)
            {
                //Place an instance of the cubePrefab inside this position of the array
                cubeGridArr[i, k] = Instantiate(cubePrefab, new Vector3(xPos, yPos, 0), Quaternion.identity); 

                //Store the position at which each cube was spawned in a publically accessible variable on that cube
                cubeGridArr[i, k].GetComponent<CubeController>().myX = i;
                cubeGridArr[i, k].GetComponent<CubeController>().myY = k;
                xPos += 2;
            }

            //Move to lower row
            yPos -= 2;
            xPos = -16;
        }

        //Set airplaneCube
        airplaneCube = cubeGridArr[0, 0];
        SetColor(airplaneCube,Color.red);

        //Set deliveryCube
        deliveryCube = cubeGridArr[8, 15];
        SetColor(deliveryCube,Color.black);

    }

    //Every frame, check to gather cargo. Display Cargo. Check if cargo is delviered.
    void Update()
    {
        //Print cargo to screen
        cargoText.text = "Cargo: " + currentCargo;
        scoreText.text = "Score " + deliveredCargo;

        //Every X seconds, if in starting position, gain cargo
        if (Time.time >= turnTimer && cubeGridArr[0,0] == airplaneCube)
        {
            //increase cargo
            if(currentCargo < cargoCap)
            {
               currentCargo += 10;
            }

            //Reset the timer for gathering cargo
            turnTimer = Time.time + turnLength;
        }
  
    }

    //Wait to be called by individual CubeController.cs. Change airplane and add cargo.
    public static void ProcessClick(GameObject clickedCube)
    {
        //if there is an airplaneCube and the cube clicked was white (not the airplane or delivery point)
        if (clickedCube.GetComponent<Renderer>().material.color == Color.white && airplaneCube != null)
        {
            //set the old airplaneCube to white + set new airplaneCube to the clickedCube + make the new airplaneCube red
            SetColor(airplaneCube,Color.white);
            airplaneCube = clickedCube;
            SetColor(airplaneCube,Color.red);

            //Reset deliveryCube
            deliveryCube = cubeGridArr[8,15];
            SetColor(deliveryCube,Color.black);

            //Console
            print("YOU JUST CHANGED THE AIRPLANE CUBE AT: " + (Time.time));
        }

        //if you click the deliveryCube, empty cargo (airplane remains active)
        else if(deliveryCube == clickedCube)
        {
            //Deliver cargo
            deliveredCargo += currentCargo;
            currentCargo = 0;

            //Visual feedback
            SetColor(airplaneCube,Color.white);
            airplaneCube = clickedCube;
            SetColor(airplaneCube, Color.red);

            //Console
            if(currentCargo != 0)
            {
               print("You just delivered Cargo!");
            }
        }

        //if you click the airplaneCube, disable it
        else
        {
            SetColor(airplaneCube,Color.white);
            airplaneCube = null;

            //Console
            print("GAME DEACTIVATED");
        }

    }

    static void SetColor(GameObject objPlugin, Color colorPlugin)
    {
       objPlugin.GetComponent<Renderer>().material.color = colorPlugin;
    }
}