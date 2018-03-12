using BrokereeSolutions.Models;
using BrokereeSolutions.Services;
using System;
using System.Threading;

namespace BrokereeSolutions
{
    class Program
    {
        static void Main(string[] args)
        {

            Process process = new Process(@"C:\BSTest\Input", DocumentTypeEnum.Csv);

            process.ProcessBinaryFiles().GetAwaiter();
            process.GetTasksStatuses();
            while (true)
            {
                Console.ReadLine();
                process.GetTasksStatuses();
            }

        }


    }


}
