using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using M2MqttUnity;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class Mqttreceiver : M2MqttUnityClient
{
    public GameObject xsense;
    [Header("MQTT topics")]
    [Tooltip("Set the topic to subscribe. !!!ATTENTION!!! multi-level wildcard # subscribes to all topics")]
    public string topicSubscribe = "#"; // topic to subscribe. !!! The multi-level wildcard # is used to subscribe to all the topics. Attention i if #, subscribe to all topics. Attention if MQTT is on data plan
    [Tooltip("Set the topic to publish (optional)")]
    public string topicPublish = ""; // topic to publish
    public string messagePublish = ""; // message to publish

    [Tooltip("Set this to true to perform a testing cycle automatically on startup")]
    public bool autoTest = false;

    //using C# Property GET/SET and event listener to reduce Update overhead in the controlled objects
    private string m_msg;

    public string msg
    {
        get
        {
            return m_msg;
        }
        set
        {
            if (m_msg == value) return;
            m_msg = value;
            if (OnMessageArrived != null)
            {
                OnMessageArrived(m_msg);
            }
        }
    }

    public event OnMessageArrivedDelegate OnMessageArrived;
    public delegate void OnMessageArrivedDelegate(string newMsg);

    //using C# Property GET/SET and event listener to expose the connection status
    private bool m_isConnected;

    public bool isConnected
    {
        get
        {
            return m_isConnected;
        }
        set
        {
            if (m_isConnected == value) return;
            m_isConnected = value;
            if (OnConnectionSucceeded != null)
            {
                OnConnectionSucceeded(isConnected);
            }
        }
    }
    public event OnConnectionSucceededDelegate OnConnectionSucceeded;
    public delegate void OnConnectionSucceededDelegate(bool isConnected);

    // a list to store the messages
    private List<string> eventMessages = new List<string>();

    public void Publish()
    {
        client.Publish(topicPublish, System.Text.Encoding.UTF8.GetBytes(messagePublish), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        Debug.Log("Test message published");
    }
    public void SetEncrypted(bool isEncrypted)
    {
        this.isEncrypted = isEncrypted;
    }

    protected override void OnConnecting()
    {
        base.OnConnecting();
    }

    protected override void OnConnected()
    {
        base.OnConnected();
        isConnected = true;

        if (autoTest)
        {
            Publish();
        }
    }

    protected override void OnConnectionFailed(string errorMessage)
    {
        Debug.Log("CONNECTION FAILED! " + errorMessage);
    }

    protected override void OnDisconnected()
    {
        Debug.Log("Disconnected.");
        isConnected = false;
    }

    protected override void OnConnectionLost()
    {
        Debug.Log("CONNECTION LOST!");
    }

    protected override void SubscribeTopics()
    {
        client.Subscribe(new string[] { topicSubscribe }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
    }

    protected override void UnsubscribeTopics()
    {
        client.Unsubscribe(new string[] { topicSubscribe });
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void DecodeMessage(string topic, byte[] message)
    {
        //The message is decoded
        msg = System.Text.Encoding.UTF8.GetString(message);

        Debug.Log("Received: " + msg);
        Debug.Log("from topic: " + m_msg);

        //if (m_msg == "kids / yolo")
        //{
        //    string[] components = msg.Trim('(', ')').Split(',');
        //    float x, y, z, w;
        //    if (components.Length == 4 &&
        //        float.TryParse(components[0], out w) &&
        //        float.TryParse(components[1], out x) &&
        //        float.TryParse(components[2], out y) &&
        //        float.TryParse(components[3], out z))
        //    {
        //        // Create a Quaternion


        //        Quaternion rotateQuat = new Quaternion(0f, -0.17f, 0f, 0.71f);
        //        Quaternion myQuaternion = new Quaternion(x, z, y, -w);
        //        myQuaternion = rotateQuat * myQuaternion;
        //        // Assign the rotation to your GameObject
        //        xsense.transform.rotation = myQuaternion;
        //    }
        //}
        //else if(m_msg == "manoj / yono")
        //{
        //    string[] components1 = msg.Trim('(', ')').Split(',');
        //    float x1, y1, z1, w1;
        //    if (components1.Length == 4 &&
        //        float.TryParse(components1[0], out w1) &&
        //        float.TryParse(components1[1], out x1) &&
        //        float.TryParse(components1[2], out y1) &&
        //        float.TryParse(components1[3], out z1))
        //    {
        //        // Create a Quaternion


        //        Quaternion rotateQuat1 = new Quaternion(0f, 0f, 0f, 0.71f);
        //        Quaternion myQuaternion1 = new Quaternion(x1, z1, y1, -w1);
        //        myQuaternion1 = rotateQuat1 * myQuaternion1;
        //        // Assign the rotation to your GameObject
        //        xsense.transform.rotation = myQuaternion1;
        //    }
        //}
        string[] components = msg.Trim('(', ')').Split(',');
        float x, y, z, w;
        if (components.Length == 4 &&
        float.TryParse(components[0], out w) &&
        float.TryParse(components[1], out x) &&
        float.TryParse(components[2], out y) &&
        float.TryParse(components[3], out z))
        {
        //        // Create a Quaternion


            Quaternion rotateQuat = new Quaternion(0f, -0.17f, 0f, 0.71f);
            Quaternion myQuaternion = new Quaternion(x, z, y, -w);
            myQuaternion = rotateQuat * myQuaternion;
            //        // Assign the rotation to your GameObject
            xsense.transform.rotation = myQuaternion;
        }
        else
        {
            Debug.LogError("Invalid quaternion string format.");
        }

        //string[] components = msg.Trim('(', ')').Split(',');
        //float x = float.Parse(components[0]);
        //float y = float.Parse(components[1]);
        //float z = float.Parse(components[2]);
        //float w = float.Parse(components[3]);

        //// Create a Quaternion
        //Quaternion myQuaternion = new Quaternion(x, y, z, w);


        StoreMessage(msg);
        if (topic == topicSubscribe)
        {
            if (autoTest)
            {
                autoTest = false;
                Disconnect();
            }
        }
    }

    private void StoreMessage(string eventMsg)
    {
        if (eventMessages.Count > 50)
        {
            eventMessages.Clear();
        }
        eventMessages.Add(eventMsg);
    }

    protected override void Update()
    {
        base.Update(); // call ProcessMqttEvents()

    }

    private void OnDestroy()
    {
        Disconnect();
    }

    private void OnValidate()
    {
        if (autoTest)
        {
            autoConnect = true;
        }
    }
}
