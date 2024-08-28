using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mqttController : MonoBehaviour
{
    public string nameController = "Controller 1";
    public string tagOfTheMQTTReceiver = "";
    public Mqttreceiver _eventSender;
    //public Mqttreceiver1 _eventSender;
    //public Mqttreceiver2 _eventSender;

    void Start()
    {
        _eventSender = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent<Mqttreceiver>();
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;
        //_eventSender = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[1].gameObject.GetComponent<Mqttreceiver1>();
        //_eventSender.OnMessageArrived += OnMessageArrivedHandler;
        //_eventSender = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[2].gameObject.GetComponent<Mqttreceiver2>();
        //_eventSender.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(string newMsg)
    {
        Debug.Log("Event Fired. The message, from Object " + nameController + " is = " + newMsg);
    }
}