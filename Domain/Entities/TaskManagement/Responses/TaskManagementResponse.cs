using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TaskManagement.Responses
{
    public class TaskManagementResponse { }

    public class TaskManagementListResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }
    public class TaskManagementGetResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
