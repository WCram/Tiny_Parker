using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGeneratorScript : MonoBehaviour
{

    public int width;
    public int height;
    
    [SerializeField] private GameObject environment;

    [SerializeField] private GameObject road;

    private GameObject[,] cityArray;
    
    
    // Start is called before the first frame update
    void Start()
    {
        cityArray = new GameObject[height, width];
     GenerateCityBoundry();
     BuildFromArray();
    } // Start()

    void GenerateCityBoundry()
    {
        BoxCollider rt = road.GetComponent<BoxCollider>();
        float rHeight = rt.size.z;
        float rWidth = rt.size.x;
        int count = 0;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i.Equals(0) || i.Equals(height - 1) ||
                    j.Equals(0) || j.Equals(width - 1))
                {
                    cityArray[i, j] = Instantiate(road, environment.transform);
                }
            }
        }
        
        Debug.Log(count.ToString());
    } // GenerateCityBoundry()

    void GenerateFullGround()
    {
        BoxCollider rt = road.GetComponent<BoxCollider>();
        float rHeight = rt.size.z;
        float rWidth = rt.size.x;
        int count = 0;
        Debug.Log($"Width: {width.ToString()} - Height: {height.ToString()}");
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Instantiate(road,
                    new Vector3(j*rWidth,0, i*rHeight),
                    Quaternion.identity,
                    environment.transform);
                count++;
            }
        }
        Debug.Log(count.ToString());
    }

    void BuildFromArray()
    {
        BoxCollider rt = road.GetComponent<BoxCollider>();
        float rHeight = rt.size.z;
        float rWidth = rt.size.x;
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (!cityArray[i, j].Equals(null))
                {
                    GameObject grid = cityArray[i, j];
                    grid.transform.position = new Vector3(
                        rWidth * i,
                        0,
                        rHeight * j
                        );
                }
            }
        }
    } // BuildFromArray()
    
} // class
