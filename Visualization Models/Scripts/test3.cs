using JetBrains.Annotations;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;

using System.Collections;
using System.IO;
using UnityEngine;

public class ReadQuaternionCSV3 : MonoBehaviour
{
    public GameObject RightArm;
    public float timeInterval = 1.0f; // Time interval between position changes in seconds

    void Start()
    {
        StartCoroutine(ReadCSVFile());
    }

    IEnumerator ReadCSVFile()
    {
        using (StreamReader strReader = new StreamReader("D:\\CAVE_Lab_Internship\\python\\forearmdat.csv"))
        {
            bool endOfFile = false;

            while (!endOfFile)
            {
                string data_String = strReader.ReadLine();
                if (data_String == null)
                {
                    endOfFile = true;
                    break;
                }

                var data_values = data_String.Split(',');

                if (data_values.Length >= 4)
                {
                    var w = float.Parse(data_values[0]);
                    var x = float.Parse(data_values[1]);
                    var y = float.Parse(data_values[2]);
                    var z = float.Parse(data_values[3]);

                    Quaternion rotateQuat = new Quaternion(0.0f, 0.717f, 0.00f, 0.96f);
                    Quaternion rotateQuatX = new Quaternion(0f, 0f, 0.717f, 0.69f);
                    Quaternion myQuaternion = new Quaternion(y, x, -z, w);
                    myQuaternion = rotateQuatX * rotateQuat * myQuaternion;
                    /*myQuaternion = myQuaternion;*/

                    // Assign the rotation to your GameObject
                    RightArm.transform.rotation = myQuaternion;
                    Debug.Log(data_values[0] + " " + data_values[1] + " " + data_values[2] + " " + data_values[3]);
                }

                // Wait for the specified time interval before the next update
                yield return new WaitForSeconds(timeInterval);
            }
        }
    }
}
