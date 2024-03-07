using MovellaDotPcSdk;
using receive_data;     
using Movella;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace testing
{
    class Program
    {
        public static void Main(string[] args)
        {
            var movellaReceiver = new movella_receive();

            //connect to the device
            List<XsDotDevice> connectedDots = movellaReceiver.Connect();

            Console.Write(connectedDots.Count);

            //start measurement
            foreach (XsDotDevice device in connectedDots)
            {
                movellaReceiver.Measurement(device);
            }
            //formating
            foreach (XsDotDevice device in connectedDots)
            {
                Console.Write("{0,-42}", device.bluetoothAddress().toString());
            }

            //start recording data
            long startTime = XsTimeStamp.nowMs();
            while (XsTimeStamp.nowMs() - startTime <= 10000)
            {
                //Thread.Sleep(10);
                Console.Write("\r");
                foreach (XsDotDevice device in connectedDots)
                {
                    movellaReceiver.GetQuat(device);

                }
                //if((XsTimeStamp.nowMs() - startTime) > 5000)
                //{
                //    foreach (XsDotDevice device in connectedDots)
                //    {
                //        movellaReceiver.resetend(device);
                //    }
                //}

            }
            //reset before stopping measurement
            foreach (XsDotDevice device in connectedDots)
            {
                movellaReceiver.resetend(device);
            }

            Console.WriteLine("Stopping measurement...");
            //stopping measurement
            foreach (XsDotDevice device in connectedDots)
            {
                movellaReceiver.stopMeasurement(device);
            }
            movellaReceiver.clean();
        }
    }
}

