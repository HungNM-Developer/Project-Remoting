using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;



namespace AppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
            ChannelServices.RegisterChannel(new TcpChannel(6969), false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ShoeBUS), "xxx", WellKnownObjectMode.SingleCall);
            Console.WriteLine("SERVER is started ....");
            Console.Read();
        }
    }
}
