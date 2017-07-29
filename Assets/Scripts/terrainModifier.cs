using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

[ExecuteInEditMode]

public class terrainModifier : MonoBehaviour
{
    Terrain mainterrain;
    public Camera maincam;
    
    public GameObject playerprefab;
    public GameObject panel1;
    public GameObject panel2;
    
    int zaehler = 0;
    int plantzaehler = 0;
    int steinzaehler = 0;
    List<string> heightmaps = new List<string>();
    List<GameObject> foliage = new List<GameObject>();
    List<GameObject> steinchen = new List<GameObject>();
    int plantscount =0;
    int rockscount = 0;
    public GameObject plantprefab1;
    public GameObject plantprefab2;
    public GameObject plantprefab3;
    public GameObject plantprefab4;

    public GameObject rockprefab1;
    public GameObject rockprefab2;
    public GameObject rockprefab3;
    public GameObject rockprefab4;
    public GameObject rockprefab5;
    public GameObject rockprefab6;

    Vector3 terrainsize;
    int number;

    void Start()
    {
        panel1 = GameObject.Find("Panel");
        panel2 = GameObject.Find("Panel2");
        maincam = GameObject.Find("Main Camera").GetComponent<Camera>();
        maincam.enabled = true;
        
        mainterrain = GetComponent<Terrain>();
        zaehler = GameObject.Find("CanvasManager").GetComponent<canvasManager>().counter;
        plantzaehler = GameObject.Find("CanvasManager").GetComponent<canvasManager>().pflanzenzaehler;
        steinzaehler = GameObject.Find("CanvasManager").GetComponent<canvasManager>().rockzaehler;
        heightmaps.Add("heightmap1.r16");
        heightmaps.Add("heightmap2.r16");
        heightmaps.Add("heightmap3.r16");
        heightmaps.Add("heightmap5.r16");
        heightmaps.Add("heightmap6.r16");
        foliage.Add(plantprefab1);
        foliage.Add(plantprefab2);
        foliage.Add(plantprefab3);
        foliage.Add(plantprefab4);
        steinchen.Add(rockprefab1);
        steinchen.Add(rockprefab2);
        steinchen.Add(rockprefab3);
        steinchen.Add(rockprefab4);
        steinchen.Add(rockprefab5);
        steinchen.Add(rockprefab6);

        //Parsing Number of Objects for the Terrain 
        if (int.TryParse((GameObject.Find("plantinput").GetComponent<Text>().text),out number))
        {
            plantscount = number;
        }
        else
        {
                plantscount =0;
  
        }
        if (int.TryParse((GameObject.Find("rockinput").GetComponent<Text>().text), out number))
        {
            rockscount = number;
        }
        else
        {
            rockscount = 0;

        }

        terrainsize = mainterrain.terrainData.size;
    }

    public void LoadTerrain()
    {

        int h = mainterrain.terrainData.heightmapHeight;
        int w = mainterrain.terrainData.heightmapWidth;
        float[,] data = new float[h, w];
        using (var file = File.OpenRead(heightmaps[zaehler]))
        using (var reader = new BinaryReader(file))
        {
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    float v = (float)reader.ReadUInt16() / 0xFFFF;
                    data[y, x] = v;
                }
            }
        }
        mainterrain.terrainData.SetHeights(0, 0, data);
    }

    public void GenerateTextures()
    {
        float[,,] map = new float[mainterrain.terrainData.alphamapWidth, mainterrain.terrainData.alphamapHeight, 3];
        for (int y = 0; y < mainterrain.terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < mainterrain.terrainData.alphamapWidth; x++)
            {
                var normX = x * 1.0f / (mainterrain.terrainData.alphamapWidth - 1);
                var normY = y * 1.0f / (mainterrain.terrainData.alphamapHeight - 1);

                var angle = mainterrain.terrainData.GetSteepness(normY, normX);
                var frac = angle / 90.0f;

                map[x, y, 0] = frac;
                map[x, y, 1] = map[x, y, 2]- map[x, y, 0];
                map[x, y, 2] = 1 - frac;
                
            }

        }

        mainterrain.terrainData.SetAlphamaps(0, 0, map);
    }

    public void Reset()
    {
        int h = mainterrain.terrainData.heightmapHeight;
        int w = mainterrain.terrainData.heightmapWidth;
        float[,] data = new float[h, w];
        using (var file = File.OpenRead(heightmaps[4]))
        using (var reader = new BinaryReader(file))
        {
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    float v = (float)reader.ReadUInt16() / 0xFFFF;
                    data[y, x] = v;
                }
            }
        }
        mainterrain.terrainData.SetHeights(0, 0, data);
        GenerateTextures();
    }

    public void AddPlants()
    {
        if (int.TryParse((GameObject.Find("plantinput").GetComponent<Text>().text), out number))
        {
            plantscount = number;
        }
        else
        {
            plantscount = 0;

        }
        for (int i=0;i<plantscount;i++)
        {
            float rot = Random.Range(0, 360);
            int xValue = Random.Range(0, 100);
            int yValue = Random.Range(0, 100);
            float zValue = mainterrain.SampleHeight(new Vector3(xValue, 0, yValue));
            Vector3 position = new Vector3(xValue,zValue , yValue);
            GameObject.Instantiate(foliage[plantzaehler], position, Quaternion.Euler(0,rot,0));
            
        }
    } 

    public void AddRocks()
    {
        if (int.TryParse((GameObject.Find("rockinput").GetComponent<Text>().text), out number))
        {
            rockscount = number;
        }
        else
        {
            rockscount = 0;

        }
        for (int i = 0; i < rockscount; i++)
        {
            float rot = Random.Range(0, 360);
            int xValue = Random.Range(0, 100);
            int yValue = Random.Range(0, 100);
            float zValue = mainterrain.SampleHeight(new Vector3(xValue, 0, yValue));
            Vector3 position = new Vector3(xValue, zValue, yValue);
            GameObject.Instantiate(steinchen[steinzaehler], position, Quaternion.Euler(0,rot,0));

        }
    }

    public void PlayTerrain()
    {
        float zValue = mainterrain.SampleHeight(new Vector3(50, 0, 50));
        Vector3 position = new Vector3(50, zValue, 50);
        maincam.enabled = false;
        panel1.SetActive(false);
        panel2.SetActive(true);
        maincam.GetComponent<camScript>().enabled = false;
        GameObject.Instantiate(playerprefab, position, Quaternion.identity);
        




    }

    public void QuitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        zaehler = (GameObject.Find("CanvasManager").GetComponent<canvasManager>().counter)%4;
        plantzaehler = (GameObject.Find("CanvasManager").GetComponent<canvasManager>().pflanzenzaehler) % 4;
        steinzaehler = (GameObject.Find("CanvasManager").GetComponent<canvasManager>().rockzaehler) % 6;
        print(zaehler);
    }
}
    

