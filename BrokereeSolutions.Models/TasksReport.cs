using BrokereeSolutions.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrokereeSolutions.Models
{
    public class TasksReport
    {
        public List<BaseTask> Tasks { get; set; }
    }

    public class BaseTask
    {
        public string FileName { get; set; }
        public TaskStatusEnum Status => SystemTask.Status == TaskStatus.Running ? TaskStatusEnum.InProgress : SystemTask.Status == TaskStatus.Faulted ? TaskStatusEnum.Failed : SystemTask.Status == TaskStatus.Canceled ? TaskStatusEnum.Cancelled : SystemTask.Status == TaskStatus.RanToCompletion ? TaskStatusEnum.Completed : TaskStatusEnum.NotStarted;
        public Task SystemTask { get; set; }
        public Exception Error { get; set; }
    }
}
