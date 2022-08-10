using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cube;

    public int cubeLenght = 3;
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

        float cubeOffset = cube.GetComponentInChildren<Renderer>().bounds.size.x + inBetweenOffSet;

        for (int i = 0; i < cubeLenght; i++)
        {
            for (int k = 0; k < cubeLenght; k++)
            {
                for (int l = 0; l < cubeLenght; l++)
                {
                    Vector3 position = new Vector3(i * cubeOffset, k * cubeOffset, l * cubeOffset);
                    GameObject newCube = Instantiate(cube, position, Quaternion.identity);
                    newCube.name = $"{i} {k} {l}";
                    newCube.transform.parent = rubicsCube.transform;
                }
            }
        }
    }
}
