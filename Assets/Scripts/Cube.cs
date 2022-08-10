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
    void Start()
    {
        frontSide.GetComponent<Renderer>().material.color = Color.white;
        backSide.GetComponent<Renderer>().material.color = Color.yellow;
        downSide.GetComponent<Renderer>().material.color = Color.red;
        upSide.GetComponent<Renderer>().material.color = Color.magenta;
        leftSide.GetComponent<Renderer>().material.color = Color.green;
        rightSide.GetComponent<Renderer>().material.color = Color.blue;
    }
}
