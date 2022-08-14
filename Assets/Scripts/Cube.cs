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

    public Vector3 vec3_1 = new Vector3();
    public Vector3 vec3_2 = new Vector3();

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

        float leniency = 0f;
        vec3_1 = new Vector3(-leniency, -leniency, -leniency);
        vec3_2 = new Vector3(insideCubeLength + leniency, insideCubeLength + leniency, insideCubeLength + leniency);

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
    void OnDrawGizmos()
    {
        float centerL = (vec3_2.x - vec3_1.x) / 2;
        Vector3 vec3_3 = new Vector3(centerL, centerL, centerL);

        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(vec3_3 + vec3_1, vec3_2);
    }
}

