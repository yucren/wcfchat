using System.ServiceModel;

namespace Wrox.ProCSharp.WCF
{
    
   public interface IMyMessageCallback
   {
        
     [OperationContract(IsOneWay =false)]
      void OnCallback(string message);
        [OperationContract(IsOneWay = true)]
        void Receive(string senderName, string message);

        [OperationContract(IsOneWay = true)]
        void ReceiveWhisper(string senderName, string message);

        [OperationContract(IsOneWay = true)]
        void UserEnter(string name);

        [OperationContract(IsOneWay = true)]
        void UserLeave(string name);
    }

   [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IMyMessageCallback))]
   
   public interface IMyMessage
   {
      //[OperationContract]
      
      //void MessageToServer(string message);
        [OperationContract(IsOneWay = false, IsInitiating = true, IsTerminating = false)]//----->IsOneWay = false等待服务器完成对方法处理;IsInitiating = true启动Session会话,IsTerminating = false 设置服务器发送回复后不关闭会话
        string[] Join(string name);//用户加入

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void Say(string msg);//群聊信息

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void Whisper(string to, string msg);//私聊信息

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void Leave();//用户加入
    }

}
