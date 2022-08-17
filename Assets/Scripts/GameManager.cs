using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RubicsCubeNS;
using MoveNS;

public class GameManager : MonoBehaviour
{
    public GameObject cube;

    public GameObject sticker;

    public int rubicsSize = 3;
    public float inBetweenOffSet = 0.5f;

    private List<GameObject> cubes; 

    // Start is called before the first frame update
    void Start()
    {
        cubes = new List<GameObject>();

        CreateCubes();

        int centerCubePos = rubicsSize / 2;

        GameObject centerCube = cubes.Find(e => e.name == $"{centerCubePos} {centerCubePos} {0}");
        AttachStickerToSide(centerCube);
    }

    // Update is called once per frame
    void Update()
    {
        Move move = new Move(Vector2Int.left, 1, RubicsCube.Sides.frontSide);
        MakeMove(move);

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

                    cubes.Add(newCube);
                }
            }
        }
    }    

    private void AttachStickerToSide(GameObject centerCube)
    {
        Transform sideTransform = centerCube.GetComponent<Cube>().frontSide.transform;

        GameObject newSticker = Instantiate(sticker, sideTransform.position, sideTransform.localRotation);

        newSticker.transform.parent = sideTransform;

        Color sideColor = sideTransform.GetComponent<Renderer>().material.color;
        Color invColor = new Color(1.0f - sideColor.r, 1.0f - sideColor.g, 1.0f - sideColor.b);
        newSticker.GetComponent<Renderer>().material.color = invColor;
    }

    private void MakeMove(Move move)
    {
        List<GameObject> middleLinecubes = new List<GameObject>();
        List<float> posiions = new List<float> { 0f, 10.5f, 21f, 31.5f, 42f};
        foreach (float pos in posiions)
        {
            foreach (GameObject c in cubes)
            {
                if (Mathf.Approximately(c.transform.position.y, pos))
                {
                    middleLinecubes.Add(c);
                }
            }

            var bound = new Bounds(middleLinecubes[0].transform.position, Vector3.zero);
            for (int i = 1; i < middleLinecubes.Count; i++)
            {
                bound.Encapsulate(middleLinecubes[i].transform.position);
            }

            foreach (GameObject gameObject in middleLinecubes)
            {
                gameObject.transform.RotateAround(bound.center, Vector3.up, 2f * (pos + 1) * Time.deltaTime);
            }
        }
    }
}
