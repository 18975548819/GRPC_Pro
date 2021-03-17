using Grpc.Net.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GrpcAggreta.Greeter;

namespace GrpcAggreta
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1.��������
            GrpcChannel grpcChannelClient = GrpcChannel.ForAddress("https://localhost:5001");
            //2.�����ͻ���
            GreeterClient greeterClient = new Greeter.GreeterClient(grpcChannelClient);
            //��ʼ����
            HelloReply helloReply = greeterClient.SayHello(new HelloRequest { Name = "qqqqqqqqqqqqqq"
            });
            //4.��ӡ����
            Console.WriteLine($"��ӡ����ֵΪ��{helloReply.Message}");
            //5.�ͷ�����
            grpcChannelClient.Dispose();

            Console.ReadLine();
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
