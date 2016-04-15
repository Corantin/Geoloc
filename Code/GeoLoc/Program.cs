using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;


namespace GeoLoc
{
    // Ce pogramme est le lecteur de la MsgQueue
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue messageQueue = new MessageQueue(@".\Private$\SomeTestName");
            System.Messaging.Message[] messages = messageQueue.GetAllMessages();

            foreach (System.Messaging.Message message in messages)
            {

                Console.WriteLine(message.Label);
                Console.WriteLine(message.Body);
                //Console.WriteLine(message.);
            }
            // after all processing, delete all the messages
            messageQueue.Purge();

        }
    }
}
