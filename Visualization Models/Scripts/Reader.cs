using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Reader: MonoBehaviour
{
    // variable which contains Path to the CSV file
    public string filepath;


    public float rotationSpeed = 10f;

    private List<Quaternion> quaternionList;
    private int currentIndex = 0;

    private void Start()
    {
        // Read quaternion values from the CSV file
        quaternionList = ReadQuaternionsFromCSV(filepath);

        // Rotate the game object based on the quaternion values
        StartCoroutine(RotateGameObject());
    }

    private List<Quaternion> ReadQuaternionsFromCSV(string filePath)
    {
        List<Quaternion> quaternions = new List<Quaternion>();

        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                // Skip the first two lines (assuming they are header lines)
                sr.ReadLine();
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');

                    // Assuming the CSV format: x,y,z,w
                    float x = float.Parse(values[1]);
                    float y = float.Parse(values[2]);
                    float z = float.Parse(values[3]);
                    float w = float.Parse(values[4]);

                    //Quaternion rotateQuat = new Quaternion(0.0f, 0.717f, 0.00f, 0.717f);
                    //Quaternion rotateQuatX = new Quaternion(0f, 0f, 0.717f, 0.717f);
                    Quaternion quaternion = new Quaternion(x, y,z, w);
                   // quaternion = rotateQuat * quaternion;
                    quaternions.Add(quaternion);
                }
            }
        }
        catch (IOException e)
        {
            Debug.LogError("Error reading CSV file: " + e.Message);
        }

        return quaternions;
    }

    private IEnumerator RotateGameObject()
    {
        while (currentIndex < quaternionList.Count)
        {
            Quaternion targetRotation = quaternionList[currentIndex];
            float step = rotationSpeed * Time.deltaTime;

            // Interpolate smoothly towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);

            // Wait for the next frame
            yield return null;

            // Move to the next quaternion
            currentIndex++;
        }
    }
}