using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 500;
    public int height = 500;
    public int depth = 50;
    public int scale = 10;

    Terrain terrain;
    // Start is called before the first frame update
    void Start()
    {
        terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    TerrainData GenerateTerrain(TerrainData terrainData){
        terrainData.size = new Vector3(width, depth, height);
        terrainData.heightmapResolution = width + 1;
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights(){
        float[,] heights = new float[width, height];
        for (int i = 0; i < width; i++){
            for (int j = 0; j < height; j++){
                heights[i, j] = CalculateHeight(i, j);
            }
        }
        return heights;
    }

    float CalculateHeight(int i, int j){
        float xCoord = (float)i / width * scale;
        float yCoord = (float)j / height * scale;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
