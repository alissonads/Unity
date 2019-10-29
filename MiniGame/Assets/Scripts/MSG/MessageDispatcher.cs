using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MessageDispatcher
{
    private static void deliverMessage(IAdvertiser receiver, Message message)
    {
        if (!receiver.HandleMessage(message))
            throw new Exception("NPC can't treat the message");
    }

    public static void DispatchMessage(IAdvertiser sender, IAdvertiser receiver, string message, object extraInfo = null)
    {
        deliverMessage(receiver, new Message(sender, receiver, message, extraInfo));
    }
}
