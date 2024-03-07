using MovellaDotPcSdk;
using receive_data;
using Movella;

namespace testing
{
    class Program
    {


        public static void Main(string[] args)
        {
            var movellaReceiver = new movella_receive();
            //XdpcHandler xdpcHandler = new XdpcHandler();


            // Call the Connect method
            XsDotDevice[] connectedDots = movellaReceiver.Connect();
            foreach (XsDotDevice device in connectedDots)
            {
                movellaReceiver.Measurement(device);
                movellaReceiver.resetHeading(device);
            }

            //var device = movellaReceiver.getDevice();
            foreach (XsDotDevice device in connectedDots)
            {
                long startTime = XsTimeStamp.nowMs();
                while (XsTimeStamp.nowMs() - startTime <= 10000)
                {
                    movellaReceiver.GetQuat(device);

                    //movellaReceiver.resetHeading(device);

                }
            }
        }
    }
}