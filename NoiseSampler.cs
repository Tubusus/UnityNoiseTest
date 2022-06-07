using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NoiseSampler : MonoBehaviour
{
    public int outputSize = 1000;
    Vector2[] offsets;
    float[] noise;
    string output = "";

    // Start is called before the first frame update
    void Start()
    {
        
        // Start logging:
        output = "Unity Perlin Noise Output Log\n\n";

        // Confirm baseline (modus) value (theoretical: 0.5, measured: 0.4652731, offset: -0.0347269) by sampling from integer coordinates
        output += "Establishing baseline value:\n";
        for (int i = 0; i < 10; i++)
        {
            output += Mathf.PerlinNoise(i, 0f).ToString() + ";\n";
        }
        // Write output into file
        File.WriteAllText("noiseData.txt", output + "\n");
        Debug.Log("Noise baseline data written to noiseData.txt created at " + Directory.GetCurrentDirectory());

        // Sample noise from int+0.5 coordinates to get sets of repeating values
        output = "Sampling from int+0.5 coordinates:\n";
        for (int i = 0; i < outputSize; i++)
        {
            int x = Random.Range(-10000, 10000);
            int y = Random.Range(-10000, 10000);
            output += Mathf.PerlinNoise(x + 0.5f, y + 0.5f).ToString() + ";\n";
        }
        // Add output into the file
        File.AppendAllText("noiseData.txt", output + "\n");
        Debug.Log("Noise int+0.5 data added to noiseData.txt at " + Directory.GetCurrentDirectory());

        // Sample random noise from float coordinates
        output = "Sampling from random float coordinates:\n";
        for (int i = 0; i < outputSize; i++)
        {
            float x = Random.value * 10000f;
            float y = Random.value * 10000f;
            output += Mathf.PerlinNoise(x + 0.5f, y + 0.5f).ToString() + ";\n";
        }
        // Add output into the file
        File.AppendAllText("noiseData.txt", output + "\n");
        Debug.Log("Random noise data added to noiseData.txt at " + Directory.GetCurrentDirectory());
        Debug.Log("Sampling noise successfuly finished.");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
