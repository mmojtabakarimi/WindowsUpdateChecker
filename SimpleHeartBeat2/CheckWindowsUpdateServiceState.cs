using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleHeartBeat2
{
    class CheckWindowsUpdateServiceState
    {
        private readonly ServiceController sc;
        public CheckWindowsUpdateServiceState(string serviceName)
        {
            sc = new ServiceController(serviceName);
        }

        public bool CheckServiceStat()
        {
            sc.Refresh();
            Console.WriteLine("chekc service  state {0} {1} ", sc.ServiceName , sc.Status);
            if (sc.Status != ServiceControllerStatus.Running)
                return false;
            return true;
        }

       public void stopService()
        {
            if (CheckServiceStat() == true )
            {
                sc.Stop();
                Thread.Sleep(2000); //sleep  2  second
            }
        }
    }
}
