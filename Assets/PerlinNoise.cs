using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public float offsetX = 100f;
    public float offsetY = 100f;

    public float scale = 20f;
    void Start()
    {
        offsetX = Random.Range(0f, 99999f);
        offsetY = Random.Range(0f, 99999f);
    }

    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = generateTexture();
    }

    Texture2D generateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                Color color = calculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();

        return texture;

    }

    Color calculateColor(int x, int y)
    {
        float xPerlinCoord = (float) x / width * scale + offsetX;
        float yPerlinCoord = (float) y / height * scale + offsetY;

        float sample = Mathf.PerlinNoise(xPerlinCoord, yPerlinCoord);
        return new Color(sample, sample, sample);
    }

}
