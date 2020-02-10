using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int depth = 20;
    public float scale = 20f;

    public int width = 256;
    public int height = 256;

    public float offsetX = 100f;
    public float offsetY = 100f;

    void Start()
    {
        offsetX = Random.Range(0f, 99999f);
        offsetY = Random.Range(0f, 99999f);
    }
    void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = generateTerrain(terrain.terrainData);
        //offsetX += Time.deltaTime * 5f;
    }

    TerrainData generateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, generateHeights());
        return terrainData;
    }

    float[,] generateHeights()
    {
        float[,] heights = new float[width, height];

        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                heights[x, y] = generateHeight(x, y);
            }
        }

        return heights;
    }

    float generateHeight(int x, int y)
    {
        float xPerlinCord = (float) x / width * scale + offsetX;
        float yPerlinCord = (float) y / height * scale + offsetY;

        return Mathf.PerlinNoise(xPerlinCord, yPerlinCord);
    }
}
