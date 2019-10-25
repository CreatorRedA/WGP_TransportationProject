using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodExample : MonoBehaviour
{
    bool[] flipsArr = new bool[5];

    bool FlipCoin()
    {
        if (Random.Range(0, 2) == 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            flipsArr[i] = FlipCoin();
            print(flipsArr[i]);

            if (flipsArr[i] == true)
            {
                print("You got heads! (0)");
            }

            else
            {
                print("You got tails! (1)");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}