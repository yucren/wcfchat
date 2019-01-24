using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace Wrox.ProCSharp.WCF
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    class ClientCallback : IMyMessageCallback
  {
    public async void OnCallback(string message)
    {
      Console.WriteLine("message from the server: {0}", message);
      await Task.Run(() => {
          Thread.Sleep(1000);

       //   Program.messageChannel.MessageToServer("谢谢"); });
        }
  }


  class Program
  {
     public static   IMyMessage messageChannel = null;
    static void Main()
    {
      Console.WriteLine("Client - wait for service");
      Console.ReadLine();

      DuplexSample();

      Console.WriteLine("Client - press return to exit");
      Console.ReadLine();

    }

    private async static void DuplexSample()
    {
      var binding = new WSDualHttpBinding();
      var address =
            new EndpointAddress("http://localhost:8733/Design_Time_Addresses/MessageService/Service1/");

      var clientCallback = new ClientCallback();
      var context = new InstanceContext(clientCallback);

      var factory = new DuplexChannelFactory<IMyMessage>(context, binding, address);

      messageChannel = factory.CreateChannel();

     // await Task.Run(() => messageChannel.MessageToServer("接收来自服务器的消息"));
    }
  }
}
