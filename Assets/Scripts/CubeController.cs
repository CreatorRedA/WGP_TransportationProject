using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public int myX, myY; //Present in each individual cube instantiated

    //No instructions
    void Start()
    {

    }

    //No instructions
    void Update()
    {

    }

    //Check for player interaction with cubes (click or hover). 
    private void OnMouseDown() //Built-in Unity functions
    {
       GameController.ProcessClick(gameObject, myX, myY); //gameObject is self referential to whatever object holds this script (each instantiated cube)
    }

    private void OnMouseOver()
    {
        GetComponent<Transform>().localScale = new Vector3(1.5f, 1.5f, 1.5f); //f denotes float
    }

    private void OnMouseExit()
    {
        GetComponent<Transform>().localScale = new Vector3(1, 1, 1); //Return cubes to normal size
    }
}
