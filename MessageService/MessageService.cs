using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.WCF
{
    /// <summary>
    /// 设定消息的类型
    /// </summary>
    public enum MessageType { Receive, UserEnter, UserLeave, ReceiveWhisper };
    /// <summary>
    /// 定义一个本例的事件消息类. 创建包含有关事件的其他有用的信息的变量，只要派生自EventArgs即可。
    /// </summary>
    public class ChatEventArgs : EventArgs
    {
        public MessageType msgType;
        public string name;
        public string message;
    }
    [ServiceBehavior( InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MessageService : IMyMessage
  {
        private static Object syncObj = new Object();////定义一个静态对象用于线程部份代码块的锁定，用于lock操作
        IMyMessageCallback callback = null;
        public delegate void ChatEventHandler(object sender, ChatEventArgs e);//定义用于把处理程序赋予给事件的委托。
        public static event ChatEventHandler ChatEvent;//定义事件
        static Dictionary<string, ChatEventHandler> chatters = new Dictionary<string, ChatEventHandler>();//创建一个静态Dictionary（表示键和值）集合(字典)，用于记录在线成员，Dictionary<(Of <(TKey, TValue>)>) 泛型类
        private string name;
        private ChatEventHandler myEventHandler = null;

    //    public void MessageToServer(string message)
    //{
    //  Console.WriteLine("收自客户端的消息: {0}", message);
    //  IMyMessageCallback callback =
    //        OperationContext.Current.
    //              GetCallbackChannel<IMyMessageCallback>();

    //  callback.OnCallback("收到来自服务器的消息");
      

    // // Task.Factory.StartNew(new Action<object>(TaskCallback), callback);
    //}
        private void MyEventHandler(object sender, ChatEventArgs e)
        {
            try
            {
                switch (e.msgType)
                {
                    case MessageType.Receive:
                        callback.Receive(e.name, e.message);
                        break;
                    case MessageType.ReceiveWhisper:
                        callback.ReceiveWhisper(e.name, e.message);
                        break;
                    case MessageType.UserEnter:
                        callback.UserEnter(e.name);
                        break;
                    case MessageType.UserLeave:
                        callback.UserLeave(e.name);
                        break;
                }
            }
            catch
            {
                Leave();
            }
        }
        private void BroadcastMessage(ChatEventArgs e)
        {

            ChatEventHandler temp = ChatEvent;

            if (temp != null)
            {
                //循环将在线的用户广播信息
                foreach (ChatEventHandler handler in temp.GetInvocationList())
                {
                    //异步方式调用多路广播委托的调用列表中的ChatEventHandler 
                    handler.BeginInvoke(this, e, new AsyncCallback(EndAsync), null);
                }
            }
        }
        private void EndAsync(IAsyncResult ar)
        {
            ChatEventHandler d = null;

            try
            {
                //封装异步委托上的异步操作结果
                System.Runtime.Remoting.Messaging.AsyncResult asres = (System.Runtime.Remoting.Messaging.AsyncResult)ar;
                d = ((ChatEventHandler)asres.AsyncDelegate);
                d.EndInvoke(ar);
            }
            catch
            {
                ChatEvent -= d;
            }
        }
    
    public string[] Join(string name)
        {
            bool userAdded = false;
            myEventHandler = new ChatEventHandler(MyEventHandler);//将MyEventHandler方法作为参数传递给委托
            lock (syncObj)//线程的同步性，同步访问多个线程的任何变量，利用lock(独占锁)，确保数据访问的唯一性。
            {
                if (!chatters.ContainsKey(name) && name != "" && name != null)
                {
                    this.name = name;
                    chatters.Add(name, MyEventHandler);
                    userAdded = true;
                }
            }
            if (userAdded)
            {
                callback = OperationContext.Current.GetCallbackChannel<IMyMessageCallback>();//获取当前操作客户端实例的通道给IChatCallback接口的实例callback,此通道是一个定义为IChatCallback类型的泛类型,通道的类型是事先服务契约协定好的双工机制。
                ChatEventArgs e = new ChatEventArgs();//实例化事件消息类ChatEventArgs
                e.msgType = MessageType.UserEnter;
                e.name = name;
                BroadcastMessage(e);
                ChatEvent += myEventHandler;
                string[] list = new string[chatters.Count]; //以下代码返回当前进入聊天室成员的称列表
                lock (syncObj)
                {
                    chatters.Keys.CopyTo(list, 0);//将字典中记录的用户信息复制到数组中返回。
                }
                return list;
            }
            else
            {
                return null;
            }

        }

        public void Say(string msg)
        {
            ChatEventArgs e = new ChatEventArgs();
            e.msgType = MessageType.Receive;
            e.name = this.name;
            e.message = msg;
            BroadcastMessage(e);
        }

        public void Whisper(string to, string msg)
        {
            ChatEventArgs e = new ChatEventArgs();
            e.msgType = MessageType.ReceiveWhisper;
            e.name = this.name;
            e.message = msg;
            try
            {
                ChatEventHandler chatterTo;//创建一个临时委托实例
                lock (syncObj)
                {
                    chatterTo = chatters[to]; //查找成员字典中，找到要接收者的委托调用
                }
                chatterTo.BeginInvoke(this, e, new AsyncCallback(EndAsync), null);//异步方式调用接收者的委托调用
            }
            catch (KeyNotFoundException)
            {
            }
        }

        public void Leave()
        {
            if (this.name == null)
                return;

            lock (syncObj)
            {
                chatters.Remove(this.name);
            }
            ChatEvent -= myEventHandler;
            ChatEventArgs e = new ChatEventArgs();
            e.msgType = MessageType.UserLeave;
            e.name = this.name;
            this.name = null;
            BroadcastMessage(e);
        }
    }

}
