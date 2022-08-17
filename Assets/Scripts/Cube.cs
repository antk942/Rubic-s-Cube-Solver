using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject frontSide;
    public GameObject backSide;
    public GameObject downSide;
    public GameObject upSide;
    public GameObject leftSide;
    public GameObject rightSide;

    // Start is called before the first frame update
    void Awake()
    {
        frontSide.GetComponent<Renderer>().material.color = Color.white;
        backSide.GetComponent<Renderer>().material.color = Color.yellow;
        downSide.GetComponent<Renderer>().material.color = Color.red;
        upSide.GetComponent<Renderer>().material.color = Color.magenta;
        leftSide.GetComponent<Renderer>().material.color = Color.green;
        rightSide.GetComponent<Renderer>().material.color = Color.blue;
    }
    public List<GameObject> GetSidesInsideCube(float insideCubeLength)
    {
        List<GameObject> sides = GetSides();
        List<GameObject> insideSides = new List<GameObject>();

        float leniency = 0.5f;

        foreach (var side in sides)
        {            
            if(side.transform.position.x >= -leniency && side.transform.position.x <= insideCubeLength + leniency &&
               side.transform.position.y >= -leniency && side.transform.position.y <= insideCubeLength + leniency &&
               side.transform.position.z >= -leniency && side.transform.position.z <= insideCubeLength + leniency)
            {
                insideSides.Add(side);
            }
        }
        return insideSides;
    }
    private List<GameObject> GetSides()
    {
        return new List<GameObject>() { frontSide, backSide, downSide, upSide, leftSide, rightSide };
    }
}

