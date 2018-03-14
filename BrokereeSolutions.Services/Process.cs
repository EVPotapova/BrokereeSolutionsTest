using BrokereeSolutions.Models;
using BrokereeSolutions.Models.Enums;
using BrokereeSolutions.Services.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokereeSolutions.Services
{
    public class Process
    {
        public bool IsCompleted => !(Result.Tasks.Any(t => t.Status == TaskStatusEnum.InProgress || t.Status == TaskStatusEnum.NotStarted));
        TasksReport Result { get; set; } = new TasksReport
        {
            Tasks = new List<BaseTask>()
        };
        string InputDirectory { get; set; }
        DocumentTypeEnum ResultType { get; set; }
        DocumentTypeEnum BaseType { get; set; }

        public Process(string inputPath, DocumentTypeEnum baseType, DocumentTypeEnum resultType)
        {
            InputDirectory = inputPath;
            ResultType = resultType;
            BaseType = baseType;
        }

        private BaseConverter GetConverter(string fileName)
        {
            switch (BaseType)
            {
                case DocumentTypeEnum.Binary:
                    return new BinaryConverter(fileName, ResultType);
                default:
                    //TODO: Test purposes
                    return new BinaryConverter(fileName, ResultType);
            }
        }

        public async Task ProcessFiles()
        {

            Result.Tasks.Clear();



            var files = Directory.EnumerateFiles(InputDirectory);
            var groups = files.Split(5);//TODO: to settings/program params, количество одновременно обрабатываемых файлов

            foreach (var gr in groups)
                for (int i = 0; i < gr.Count(); i++)
                {
                    var filePath = gr.ElementAt(i);
                    BaseConverter converter = GetConverter(filePath);
                    BaseTask bTask = new BaseTask
                    {
                        FileName = Path.GetFileName(filePath)
                    };
                    try
                    {
                        if (i != 0)
                        {
                            var lastTask = Result.Tasks.FirstOrDefault(t => t.FileName.Equals(Path.GetFileName(gr.ElementAt(i - 1)))).SystemTask;
                            bTask.SystemTask = lastTask.ContinueWith(_ => converter.ReadAndWrite());

                        }
                        else
                        {
                            bTask.SystemTask = Task.Run(() => converter.ReadAndWrite());

                        }
                        Result.Tasks.Add(bTask);
                    }
                    catch (AggregateException ex)
                    {
                        bTask.Error = ex;
                    }
                }
        }

        //TODO: To report ?
        public string GetTaskStatus(int id)
        {
            var task = Result.Tasks.FirstOrDefault(t => t.SystemTask != null && t.SystemTask.Id == id);

            if (task != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{task.SystemTask.Id} - {task.FileName} - {task.Status}"); if (task.Error != null)
                {
                    sb.AppendLine(task.Error.GetaAllMessages());
                }
                return sb.ToString();
            }
            else
                return "Task is not found.";
        }

        public string GetTasksStatuses()
        {
            StringBuilder sb = new StringBuilder();
            foreach (BaseTask task in Result.Tasks)
            {
                sb.AppendLine($"{task.SystemTask.Id} - {task.FileName} - {task.Status}");
                if(task.Error!=null)
                {
                    sb.AppendLine(task.Error.GetaAllMessages());
                }
            }
            return sb.ToString();
        }


    }
}
