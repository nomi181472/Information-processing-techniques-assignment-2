using System;
using System.Configuration;
using Topshelf;

namespace k173652_Q1_
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessGenerator.directory = ConfigurationManager.AppSettings["Question1Directive"];
            ProcessGenerator.waitTime = Convert.ToInt32(ConfigurationManager.AppSettings["setTimeInMinutes"]);

            Environment.ExitCode = (int)Convert.ChangeType(HostFactory.Run
               (
                service =>
                {
                    service.Service<ProcessGenerator>(pg =>
                    {
                        pg.ConstructUsing(processGenerator => new ProcessGenerator());
                        pg.WhenStarted(processGenerator => processGenerator.Start());
                        pg.WhenStopped(processGenerator => processGenerator.Stop());

                    });
                    service.RunAsLocalSystem();
                    service.SetServiceName("DataFetcherFromPakStockExchange");
                    service.SetDisplayName("Data Fetching...");
                    service.SetDescription("This Service run the question 1 from assignment 1 ");


                }
               ), typeof(TopshelfExitCode));


        }
    }
}
