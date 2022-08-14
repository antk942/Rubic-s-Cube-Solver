using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cube;

    public int rubicsSize = 3;
    public float inBetweenOffSet = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        CreateCubes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateCubes()
    {
        GameObject rubicsCube = new GameObject("Rubic's Cube");

        float planeLength = cube.GetComponentInChildren<Renderer>().bounds.size.x;
        float cubeOffset = planeLength + inBetweenOffSet;
        float rubicsLength = planeLength * rubicsSize + inBetweenOffSet * (rubicsSize - 1);

        for (int i = 0; i < rubicsSize; i++)
        {
            for (int k = 0; k < rubicsSize; k++)
            {
                for (int l = 0; l < rubicsSize; l++)
                {
                    Vector3 position = new Vector3(i * cubeOffset, k * cubeOffset, l * cubeOffset);
                    GameObject newCube = Instantiate(cube, position, Quaternion.identity);
                    newCube.name = $"{i} {k} {l}";
                    newCube.transform.parent = rubicsCube.transform;

                    List<GameObject> closestSides = newCube.GetComponent<Cube>().GetSidesInsideCube(rubicsLength - planeLength);
                    foreach (GameObject side in closestSides)
                    {
                        side.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                    }
                }
            }
        }
    }    
}
