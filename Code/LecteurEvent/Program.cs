using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace LecteurEvent
{
    // Ce programme est clui qui écrit dans la mg queue
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue messageQueue = null;
            if (MessageQueue.Exists(@".\Private$\SomeTestName"))
            {
                messageQueue = new MessageQueue(@".\Private$\SomeTestName");
                messageQueue.Label = "Testing Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\SomeTestName");
                messageQueue = new MessageQueue(@".\Private$\SomeTestName");
                messageQueue.Label = "Newly Created Queue";
            }
            messageQueue.Send("First ever Message is sent to MSMQ", "Message 1");
            messageQueue.Send("First ever Message is sent to MSMQ", "Msg 2");
            messageQueue.Send("First ever Message is sent to MSMQ", "Msg 3");
            messageQueue.Send("First ever Message is sent to MSMQ", "Msg 4");
            messageQueue.Send("First ever Message is sent to MSMQ", "Msg 5");
        }
    }
}
