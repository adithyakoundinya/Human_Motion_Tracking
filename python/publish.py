from sys import exit
import time
from pynput import keyboard
from threading import Lock

from user_settings import *
from collections import defaultdict

waitForConnections = True


from xdpchandler import *
    

if __name__ == "__main__":
    xdpcHandler = XdpcHandler()

    if not xdpcHandler.initialize():
        xdpcHandler.cleanup()
        exit(-1)

    xdpcHandler.scanForDots()
    if len(xdpcHandler.detectedDots()) == 0:
        print("No Movella DOT device(s) found. Aborting.")
        xdpcHandler.cleanup()
        exit(-1)

    xdpcHandler.connectDots()

    if len(xdpcHandler.connectedDots()) == 0:
        print("Could not connect to any Movella DOT device(s). Aborting.")
        xdpcHandler.cleanup()
        exit(-1)

    for device in xdpcHandler.connectedDots():
        filterProfiles = device.getAvailableFilterProfiles()
        print("Available filter profiles:")
        for f in filterProfiles:
            print(f.label())

        print(f"Current profile: {device.onboardFilterProfile().label()}")
        if device.setOnboardFilterProfile("General"):
            print("Successfully set profile to General")
        else:
            print("Setting filter profile failed!")

        print("Setting quaternion CSV output")
        device.setLogOptions(movelladot_pc_sdk.XsLogOptions_Quaternion)

        logFileName = "logfile_" + device.bluetoothAddress().replace(':', '-') + ".csv"
        print(f"Enable logging to: {logFileName}")
        if not device.enableLogging(logFileName):
            print(f"Failed to enable logging. Reason: {device.lastResultText()}")

        print("Putting device into measurement mode.")
        if not device.startMeasurement(movelladot_pc_sdk.XsPayloadMode_ExtendedEuler):
            print(f"Could not put device into measurement mode. Reason: {device.lastResultText()}")
            continue

    print("\nMain loop. Recording data for 10 seconds.")
    print("-----------------------------------------")

    # First printing some headers so we see which data belongs to which device
    s = ""
    for device in xdpcHandler.connectedDots():
        s += f"{device.bluetoothAddress():42}"
    print("%s" % s, flush=True)

    orientationResetDone = False
    startTime = movelladot_pc_sdk.XsTimeStamp_nowMs()
    
    
    import paho.mqtt.publish as publish

    # MQTT broker (server) details
    broker_address = "localhost"  # Replace with your broker address
    broker_port = 1883  # Default MQTT port

    # Create a new MQTT client
    # client = mqtt.Client()

    # Connect to the MQTT broker
    # client.connect(broker_address, broker_port)

    # # Publish a message
    # client.publish("mytopic", "Hello, MQTT!")

    # # Disconnect from the MQTT broker
    # client.disconnect()
    # client.loop_forever()
    
    
    
    
    while movelladot_pc_sdk.XsTimeStamp_nowMs() - startTime <= 1000000:
        if xdpcHandler.packetsAvailable():
            s = ""
            # for device in xdpcHandler.connectedDots():
                # Retrieve a packetpacke
            # packetA = xdpcHandler.getNextPacket(xdpcHandler.connectedDots()[0].portInfo().bluetoothAddress())
            # print(packetA)
            # packetB = xdpcHandler.getNextPacket(xdpcHandler.connectedDots()[1].portInfo().bluetoothAddress())
            # print(packetB)
            # packetC = xdpcHandler.getNextPacket(xdpcHandler.connectedDots()[2].portInfo().bluetoothAddress())
            # print(packetC)
            # packetD = xdpcHandler.getNextPacket(xdpcHandler.connectedDots()[3].portInfo().bluetoothAddress())
            # print(packetD)
            # packetE = xdpcHandler.getNextPacket(xdpcHandler.connectedDots()[4].portInfo().bluetoothAddress())
            # print(packetE)
    
            for packet in xdpcHandler.connectedDots():

                if packet.portInfo().bluetoothAddress() == "D4:22:CD:00:39:40":
                    packet0 = xdpcHandler.getNextPacket(packet.portInfo().bluetoothAddress())
                if packet.portInfo().bluetoothAddress() == "D4:22:CD:00:39:41":
                    packet1 = xdpcHandler.getNextPacket(packet.portInfo().bluetoothAddress())
                if packet.portInfo().bluetoothAddress() == "D4:22:CD:00:39:51":
                    packet2 = xdpcHandler.getNextPacket(packet.portInfo().bluetoothAddress())
                if packet.portInfo().bluetoothAddress() == "D4:22:CD:00:39:65":
                    packet3 = xdpcHandler.getNextPacket(packet.portInfo().bluetoothAddress())
                if packet.portInfo().bluetoothAddress() == "D4:22:CD:00:39:4A":
                    packet4 = xdpcHandler.getNextPacket(packet.portInfo().bluetoothAddress())
            
                
            # # # packet0 = xdpcHandler.getNextPacket(xdpcHandler.connectedDots()[0].portInfo().bluetoothAddress())

            if packet0.containsOrientation():
                euler = packet0.orientationEuler()
                quaternion = packet0.orientationQuaternion()
                quat=f"{quaternion[0]:7.2f}, {quaternion[1]:7.2f}, {quaternion[2]:7.2f}, {quaternion[3]:7.2f} "
                s += quat
                # s += f"Roll:{euler.x():7.2f}, Pitch:{euler.y():7.2f}, Yaw:{euler.z():7.2f}| "
                    # s += f"W:{quaternion.w():7.2f}, X:{quaternion.x():7.2f}, Y:{quaternion.y():7.2f}, Z:{quaternion.z():7.2f}| "
                mytopic="topic/1"
                    # publish.single(mytopic, payload="hello", hostname="localhost", port=1883)
                publish.single(mytopic, quat, hostname=broker_address, port=1883)

                    # print("euler",euler.x())  
            # print("%s\r" % s, end="", flush=True)
            
            
            # packet1 = xdpcHandler.getNextPacket(xdpcHandler.connectedDots()[1].portInfo().bluetoothAddress())

            if packet1.containsOrientation():
                euler = packet1.orientationEuler()
                quaternion = packet1.orientationQuaternion()
                quat=f"{quaternion[0]:7.2f}, {quaternion[1]:7.2f}, {quaternion[2]:7.2f}, {quaternion[3]:7.2f} "
                s += quat
                # s += f"Roll:{euler.x():7.2f}, Pitch:{euler.y():7.2f}, Yaw:{euler.z():7.2f}| "
                    # s += f"W:{quaternion.w():7.2f}, X:{quaternion.x():7.2f}, Y:{quaternion.y():7.2f}, Z:{quaternion.z():7.2f}| "
                mytopic1="topic/2"
                    # publish.single(mytopic, payload="hello", hostname="localhost", port=1883)
                publish.single(mytopic1, quat, hostname=broker_address, port=1883)
                
            # print("%s\r" % s, end="", flush=True)
            
            # packet2= xdpcHandler.getNextPacket(xdpcHandler.connectedDots()[2].portInfo().bluetoothAddress())

            if packet2.containsOrientation():
                euler = packet2.orientationEuler()
                quaternion = packet2.orientationQuaternion()
                quat=f"{quaternion[0]:7.2f}, {quaternion[1]:7.2f}, {quaternion[2]:7.2f}, {quaternion[3]:7.2f} "
                s += quat
                # s += f"Roll:{euler.x():7.2f}, Pitch:{euler.y():7.2f}, Yaw:{euler.z():7.2f}| "
                    # s += f"W:{quaternion.w():7.2f}, X:{quaternion.x():7.2f}, Y:{quaternion.y():7.2f}, Z:{quaternion.z():7.2f}| "
                mytopic="topic/3"
                    # publish.single(mytopic, payload="hello", hostname="localhost", port=1883)
                publish.single(mytopic, quat, hostname=broker_address, port=1883)

                print("euler",euler.x())  
                print("%s\r" % s, end="", flush=True)
            
            # # packet3 = xdpcHandler.getNextPacket(xdpcHandler.connectedDots()[3].portInfo().bluetoothAddress())

            if packet3.containsOrientation():
                euler = packet3.orientationEuler()
                quaternion = packet3.orientationQuaternion()
                quat=f"{quaternion[0]:7.2f}, {quaternion[1]:7.2f}, {quaternion[2]:7.2f}, {quaternion[3]:7.2f} "
                s += quat
                # s += f"Roll:{euler.x():7.2f}, Pitch:{euler.y():7.2f}, Yaw:{euler.z():7.2f}| "
                    # s += f"W:{quaternion.w():7.2f}, X:{quaternion.x():7.2f}, Y:{quaternion.y():7.2f}, Z:{quaternion.z():7.2f}| "
                mytopic="topic/4"
                    # publish.single(mytopic, payload="hello", hostname="localhost", port=1883)
                publish.single(mytopic, quat, hostname=broker_address, port=1883)

                print("euler",euler.x())  
                print("%s\r" % s, end="", flush=True)
            
            # # packet4 = xdpcHandler.getNextPacket(xdpcHandler.connectedDots()[4].portInfo().bluetoothAddress())

            if packet4.containsOrientation():
                euler = packet4.orientationEuler()
                quaternion = packet4.orientationQuaternion()
                quat=f"{quaternion[0]:7.2f}, {quaternion[1]:7.2f}, {quaternion[2]:7.2f}, {quaternion[3]:7.2f} "
                s += quat
                # s += f"Roll:{euler.x():7.2f}, Pitch:{euler.y():7.2f}, Yaw:{euler.z():7.2f}| "
                    # s += f"W:{quaternion.w():7.2f}, X:{quaternion.x():7.2f}, Y:{quaternion.y():7.2f}, Z:{quaternion.z():7.2f}| "
                mytopic="topic/5"
                    # publish.single(mytopic, payload="hello", hostname="localhost", port=1883)
                publish.single(mytopic, quat, hostname=broker_address, port=1883)

                print("euler",euler.x())  
                print("%s\r" % s, end="", flush=True)
             
            if not orientationResetDone and movelladot_pc_sdk.XsTimeStamp_nowMs() - startTime > 5000:
                for device in xdpcHandler.connectedDots():
                    print(f"\nResetting heading for device {device.portInfo().bluetoothAddress()}: ", end="", flush=True)
                    if device.resetOrientation(movelladot_pc_sdk.XRM_Heading):
                        print("OK", end="", flush=True)
                    else:
                        print(f"NOK: {device.lastResultText()}", end="", flush=True)
                print("\n", end="", flush=True)
                orientationResetDone = True
    print("\n-----------------------------------------", end="", flush=True)

    for device in xdpcHandler.connectedDots():
        print(f"\nResetting heading to default for device {device.portInfo().bluetoothAddress()}: ", end="", flush=True)
        if device.resetOrientation(movelladot_pc_sdk.XRM_DefaultAlignment):
            print("OK", end="", flush=True)
        else:
            print(f"NOK: {device.lastResultText()}", end="", flush=True)
    print("\n", end="", flush=True)

    print("\nStopping measurement...")
    for device in xdpcHandler.connectedDots():
        if not device.stopMeasurement():
            print("Failed to stop measurement.")
        if not device.disableLogging():
            print("Failed to disable logging.")

    xdpcHandler.cleanup()
