using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeColor : MonoBehaviour
{
    /*
        
        
        
    */
    public int selectedCube = -1;
    private int dayOfTheWeek;
	private int numOfCubes;
	//private int j = 0;

    // Use this for initialization
    private void Start() {
		if(Application.loadedLevelName=="Scene1")
		{
			numOfCubes=5;
		}
		if(Application.loadedLevelName=="Scene2")
		{
			numOfCubes=4;
		}
		if(Application.loadedLevelName=="Scene3")
		{
			numOfCubes=5;
		}
		
    }

    // Update is called once per frame
    private void Update()
    {
        ColorData cols = new ColorData();

		for (int i = 0; i < numOfCubes; i++) {
			GameObject cubeCol = GameObject.Find ("Cube" + i);


			if(Application.loadedLevelName=="Scene3")
			{
				GameObject cubeRow0 = GameObject.Find ("Cubes0");
				GameObject cubeRow1 = GameObject.Find("Cubes1");
				Renderer[] rowZeroColor = cubeRow0.GetComponentsInChildren<Renderer>();
				Renderer[] rowOneColor = cubeRow1.GetComponentsInChildren<Renderer>();	
				rowZeroColor[i].material.color=cols.GetAColorToUse(i);
				rowOneColor[i].material.color=cols.GetAColorToUse(i);
				rowOneColor[i].gameObject.transform.localScale=new Vector3(1, 2, 1);
			}
			else
				cubeCol.GetComponent<Renderer> ().material.color = cols.GetAColorToUse (i);
		}

		if (Input.GetButtonDown ("Jump"))
			set_scale_of_cubes ();

    }

    private void set_scale_of_cubes()
    {
        GameObject curCube;
		bool curGroup = true;
		if(Application.loadedLevelName=="Scene3")
		{
			GameObject cubeRow0 = GameObject.Find ("Cubes0");
			GameObject cubeRow1 = GameObject.Find("Cubes1");
			Renderer[] rowZeroSize = cubeRow0.GetComponentsInChildren<Renderer>();
			Renderer[] rowOneSize = cubeRow1.GetComponentsInChildren<Renderer>();	

			if (selectedCube <= numOfCubes-1)
			{
				selectedCube++;
			}
			if (selectedCube >= numOfCubes) {
				selectedCube=0;
				curGroup=!curGroup;
			}
			if(curGroup==true)
			{
				curCube=rowOneSize[selectedCube].gameObject;
			}
			else
				curCube=rowZeroSize[selectedCube].gameObject;


		}
		else{

       	 if (selectedCube > -1)
        		{
           			 curCube = GameObject.Find("Cube" + selectedCube);
            		curCube.transform.localScale = new Vector3(1, 1, 1);
					curCube.GetComponent<Renderer>().material.color= new Color(1,1,1);

       			 }
		if (selectedCube <= numOfCubes-1)
			{
				selectedCube++;
			}
		if (selectedCube >= numOfCubes) {
				selectedCube=0;
			}
		
        curCube  = GameObject.Find("Cube" + selectedCube);
	}
        curCube.transform.localScale = new Vector3(1, 2, 1);
    }

    public float yOfCube(int cubeNumber)
    {
        GameObject ob = GameObject.Find("Cube" + selectedCube);
        return ob.transform.localScale.y;
    }
}

public class ColorData
{
    public Color GetAColorToUse(int indexOfTheColorToGet) {
        List<Color> color_list = new List<Color>();
        color_list.Add(new Color(1, 0, 0));
        color_list.Add(new Color(.7f, .7f, 0));
        color_list.Add(new Color(0, 1, 0));
        color_list.Add(new Color(0, .3f, 1));
        color_list.Add(new Color(0, 1, 1));
		color_list.Add(new Color(0, .1f, 1));
        return color_list[indexOfTheColorToGet];
    }
}

public class CubeData
{
    // When we find a cube, we should put its data in here for tidier access
}
