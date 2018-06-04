﻿using System;
using nodewire;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace con
{
    class Controller
    {
        public void on_led(dynamic p)
        {
            Console.WriteLine("LED on");
        }

        public dynamic get_switch()
        {
            return 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SocketLink link = new SocketLink{ 
                server="dashboard.nodewire.org", 
                account="sadiq.a.ahmad@gmail.com", 
                pwd="secret", 
                instance="lrsnr49yxurz"
            };


            var c = link.connect();
            c.Wait();

            Controller ctrl = new Controller();

            var node = new Node("node01", link, ctrl);
            node.Inputs = "led";
            node.Outputs = "switch";
            var r = node.Run();
            r.Wait();
        }


        static void Test_PlainMessage()
        {
            dynamic user = new JObject();
            user.name = "Ahmad Sadiq";
            user.age = 9;

            PlainMessage message = new PlainMessage(@"cp portvalue user {'name':'ahmad sadiq', 'age':35} node01");
            PlainMessage msg = new PlainMessage { address = "cp", command = "ThisIs", sender = "node01" };
            PlainMessage cmd = new PlainMessage { address = "node01", command = "set", Port = "add", Value = user, sender = "ah" };
        }
    }
}
