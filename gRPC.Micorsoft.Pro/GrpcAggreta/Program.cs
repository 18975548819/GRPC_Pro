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
            //1.建立连接
            GrpcChannel grpcChannelClient = GrpcChannel.ForAddress("https://localhost:5001");
            //2.创建客户端
            GreeterClient greeterClient = new Greeter.GreeterClient(grpcChannelClient);
            //开始调用
            HelloReply helloReply = greeterClient.SayHello(new HelloRequest { Name = "qqqqqqqqqqqqqq"
            });
            //4.打印返回
            Console.WriteLine($"打印返回值为：{helloReply.Message}");
            //5.释放连接
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
