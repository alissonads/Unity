using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Message
{
    private IAdvertiser sender;
    private IAdvertiser receiver;
    private string msg;
    private object extraInfo;

    public Message(IAdvertiser sender, IAdvertiser receiver, string msg, object extraInfo = null)
    {
        this.sender = sender;
        this.receiver = receiver;
        this.msg = msg;
        this.extraInfo = extraInfo;
    }

    public Message(Message other)
    {
        sender = other.sender;
        receiver = other.receiver;
        msg = (string)other.msg.Clone();
        extraInfo = other.extraInfo;
    }

    public Message Clone()
    {
        return new Message(sender, receiver, (string)msg.Clone(), extraInfo);
    }

    public IAdvertiser Sender
    {
        set { sender = value; }
        get { return sender; }
    }

    public IAdvertiser Receiver
    {
        set { receiver = value; }
        get { return receiver; }
    }

    public string Msg
    {
        set { msg = value; }
        get { return msg; }
    }

    public object ExtraInfo
    {
        set { extraInfo = value; }
        get { return extraInfo; }
    }
}
