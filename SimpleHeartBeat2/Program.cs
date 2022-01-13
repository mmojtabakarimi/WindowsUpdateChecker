using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace SimpleHeartBeat2
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<HeratBeat>(s =>
                {
                    s.ConstructUsing(heartbeat => new HeratBeat());
                    s.WhenStarted(heartbeat => heartbeat.Start());
                    s.WhenStopped(heartbeat => heartbeat.Start());
                });
                x.RunAsLocalService();
                x.SetDisplayName("mojtabasrv");
                x.SetServiceName("mojtabasrv");
                x.SetDescription("Hello this is my first service  with C#");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetType());
            Environment.ExitCode = exitCodeValue;


        }
    }
}
