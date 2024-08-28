using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mqttController : MonoBehaviour
{
    public string nameController = "Controller 1";
    public string tagOfTheMQTTReceiver="";
    //public string nameController1 = "Controller 2";
    //public string tagOfTheMQTTReceiver1 = "";
    public Mqttreceiver _eventSender;
    //public Mqttreceiver _eventSender1;

  void Start()
  {
      _eventSender=GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent<Mqttreceiver>();
      _eventSender.OnMessageArrived += OnMessageArrivedHandler;
      //_eventSender1 = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[1].gameObject.GetComponent<Mqttreceiver>();
      //_eventSender1.OnMessageArrived += OnMessageArrivedHandler;

    }

  private void OnMessageArrivedHandler(string newMsg)
  {
    Debug.Log("Event Fired. The message, from Object " +nameController+" is = " + newMsg);
  }
}