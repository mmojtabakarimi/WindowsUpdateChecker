using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SimpleHeartBeat2
{
    public class HeratBeat
    {
        private readonly Timer _Timer;
        CheckWindowsUpdateServiceState checkWindowsUpdateServiceState;
        public HeratBeat()
        {
            _Timer = new Timer(1000) { AutoReset = true };
            _Timer.Elapsed += TimerElapsed;
            checkWindowsUpdateServiceState = new CheckWindowsUpdateServiceState("wuauserv");

        }
        private void TimerElapsed(object  sender ,ElapsedEventArgs e)
        {
            checkWindowsUpdateServiceState.stopService();

            if (checkWindowsUpdateServiceState.CheckServiceStat() == true)
            {
                string[] lines = new string[] { DateTime.Now.ToString() + "1Service Running " };
                File.AppendAllLines(@"c:\temp\test.txt", lines);
            }
            else
            {
                string[] lines = new string[] { DateTime.Now.ToString()+"2Service Stoped" }; 
                File.AppendAllLines(@"c:\temp\test.txt", lines);
            }



        }
        public void Start()
        {
            _Timer.Start();
        }
        public void Stop()
        {
            _Timer.Stop();
        }

    }
}
