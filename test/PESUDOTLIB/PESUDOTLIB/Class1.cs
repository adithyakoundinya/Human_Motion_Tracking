using System;
using MovellaDotPcSdk;
using Movella;
//using UnityEngine;

namespace receive_data
{
    public class movella_receive
    {
        private XdpcHandler xdpcHandler;
        public movella_receive()
        {
            xdpcHandler = new XdpcHandler();
        }

        private bool orientationResetDone = false;

        //public float AngleBetweenQuaternions(Quaternion q1, Quaternion q2)
        //{
        //    float dotProduct = Vector3.Dot(new Vector3(q1.x, q1.y, q1.z), new Vector3(q2.x, q2.y, q2.z)); // Use x, y, z for imaginary components
        //    float cosTheta = 2 * dotProduct + 2 * q1.w * q2.w - 1;
        //    float theta = Mathf.Acos(Mathf.Clamp(cosTheta, -1.0f, 1.0f)); // Clamp between -1 and 1
        //    return Mathf.Rad2Deg * theta; // Convert radians to degrees
        //}
        public void stopMeasurement(XsDotDevice device)
        {
            Console.WriteLine("Stopping measurement...");
            //foreach (XsDotDevice device in xdpcHandler.ConnectedDots)
            //{
            if (!device.stopMeasurement())
                Console.Write("Failed to stop measurement.");
            if (!device.disableLogging())
                Console.Write("Failed to disable logging.");
            //}

            xdpcHandler.cleanup();
        }

        public XsDotDevice[] Connect()
        {
            if (!xdpcHandler.initialize())
            {
                Console.WriteLine("Initialization failed. Aborting.");
                return new XsDotDevice[0]; // Return an empty array
            }

            xdpcHandler.scanForDots();

            if (xdpcHandler.detectedDots().empty())
            {
                Console.WriteLine("No Movella DOT device(s) found. Aborting.");
                xdpcHandler.cleanup();
                return new XsDotDevice[0]; // Return an empty array
            }

            xdpcHandler.connectDots();

            if (xdpcHandler.ConnectedDots.Count == 0)
            {
                Console.WriteLine("Could not connect to any Movella DOT device(s). Aborting.");
                xdpcHandler.cleanup();
                return new XsDotDevice[0]; // Return an empty array
            }

            // Return the connected dots array
            return xdpcHandler.ConnectedDots.ToArray();
        }

        public void Measurement(XsDotDevice device)
        {
            XsFilterProfileArray filterProfiles = device.getAvailableFilterProfiles();

            Console.WriteLine("Available filter profiles: ");
            for (uint j = 0; j < filterProfiles.size(); j++)
                Console.WriteLine(filterProfiles.at(j).label());

            Console.WriteLine("Current filter profile: {0}", device.onboardFilterProfile().label());
            if (device.setOnboardFilterProfile(new XsString("General")))
                Console.WriteLine("Successfully set filter profile to General");
            else
                Console.WriteLine("Failed to set filter profile!");

            Console.WriteLine("Setting quaternion CSV output");
            device.setLogOptions(XsLogOptions.Euler);

            XsString logFileName = new XsString("logfile_" + device.bluetoothAddress().toString().Replace(':', '-') + ".csv");
            Console.WriteLine("Enable logging to: {0}", logFileName.toString());
            if (!device.enableLogging(logFileName))
            {
                Console.WriteLine("Failed to enable logging. Reason: {0}", device.lastResultText().toString());

            }
            Console.WriteLine("Putting device into measurement mode. ");
            if (!device.startMeasurement(XsPayloadMode.ExtendedEuler))
            {
                Console.WriteLine("Could not put device into measurement mode. Reason: {0}", device.lastResultText().toString());

            }

        }

        //public XsDotDevice getDevice()
        //{
        //    int full = xdpcHandler.ConnectedDots.Count;
        //    while ( full != -1)
        //    {
        //        full--;
        //        return xdpcHandler.ConnectedDots[full];


        //    }

        //    return null;
        //}
        public void GetQuat(XsDotDevice device)
        {



            //Console.WriteLine("Starting measurement...");

            //Console.WriteLine("Main loop. Measuring data for 10 seconds.");
            //Console.WriteLine("-----------------------------------------");

            // First printing some headers so we see which data belongs to which device
            //Console.Write("{0,-42}", device.bluetoothAddress().toString());
            //Console.Write("\n");

            orientationResetDone = false;

            if (xdpcHandler.packetsAvailable())
            {
                Console.Write("\r");
                // Retrieve a packet
                XsDataPacket packet = xdpcHandler.getNextPacket(device.bluetoothAddress().toString());

                if (packet.containsOrientation())
                {
                    //XsEuler euler = packet.orientationEuler();
                    //Console.Write("Roll:{0,7:f2}, Pitch:{1,7:f2}, Yaw:{2,7:f2}| ", euler.roll(), euler.pitch(), euler.yaw());
                    XsQuaternion quat = packet.orientationQuaternion();
                    Console.Write("Quat:{0,7:f2}, {1,7:f2}, {2,7:f2}, {3,7:f2}| ", quat.x(), quat.y(), quat.z(), quat.w());
                } // END of  if (packet.containsOrientation())

                packet.Dispose();
            } // END of if (xdpcHandler.packetsAvailable())
        } // END of getQuat

        public void resetHeading(XsDotDevice device)
        {

            Console.Write("\nResetting heading for device {0}: ", device.bluetoothAddress().toString());
            if (device.resetOrientation(XsResetMethod.XRM_Heading))
                Console.Write("OK");
            else
                Console.Write("NOK: {0}", device.lastResultText().toString());
        } //END of resetHeading

    } // END of Class movella_receive
} // END of namespace receive_data