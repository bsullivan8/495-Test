using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveCube : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            int current_Cube = gameObject.GetComponent<CubeColor>().selectedCube;
            GameObject cube = GameObject.Find("Cube" + current_Cube);
            cube.transform.Translate(new Vector3(0, 1, 0));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            int current_Cube = gameObject.GetComponent<CubeColor>().selectedCube;
            GameObject cube = GameObject.Find("Cube" + current_Cube);
            cube.transform.Translate(new Vector3(0, -1, 0));
        }
    }
}