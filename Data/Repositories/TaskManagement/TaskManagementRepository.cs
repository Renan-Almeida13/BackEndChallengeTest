using Dapper;
using Data.Connections;
using Domain.Entities.TaskManagement.Commands;
using Domain.Entities.TaskManagement.Queries;
using Domain.Entities.TaskManagement.Responses;
using Domain.Interfaces.TaskManagement;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.TaskManagement
{
    public class TaskManagementRepository : MSSQL, ITaskManagementRepository
    {
        private const string TABLE = "TaskManagement";

        public IEnumerable<TaskManagementListResponse> List()
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"SELECT *
                         FROM {TABLE}
                         WHERE RemovalDate IS NULL";

            var response = connection.Query<TaskManagementListResponse>(sql);

            return response;
        }

        public int Add(AddTaskManagementCommand request)
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"
                       INSERT INTO {TABLE} (RegisteredByUserId, RegistrationDate, UserName, Date, StartTime, EndTime, Subject, Description)
                       VALUES ( {request.UserId}, GETDATE(), '{request.UserName}', '{request.Date}', '{request.StartTime}', '{request.EndTime}', '{request.Subject}', '{request.Description}')
                       SELECT CAST(SCOPE_IDENTITY() as int)";

            var response = connection.Query<int>(sql).First();

            return response;
        }

        public int Edit(EditTaskManagementCommand request)
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"
                       UPDATE {TABLE} SET ModifiedByUserId = {request.UserId},
                                          LastModifiedDate = GETDATE(),
                                          UserName = '{request.UserName}',
                                          Date = '{request.Date}',
                                          StartTime = '{request.StartTime}',
                                          EndTime = '{request.EndTime}',
                                          Subject = '{request.Subject}',
                                          Description = '{request.Description}'
                       WHERE Id = {request.Id}";

            var response = connection.Execute(sql);

            return request.Id;
        }

        public int Remove(RemoveTaskManagementCommand request)
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"
                       UPDATE {TABLE} SET RemovedByUserId = {request.UserId},
                                          RemovalDate = GETDATE()
                       WHERE Id = {request.Id}";

            var response = connection.Execute(sql);

            return request.Id;
        }

        public bool Exist(ExistTaskManagementQuery request)
        {
            using var connection = new SqlConnection(GetConnection());
            var sql = $@"SELECT COUNT(*)
                 FROM {TABLE}
                 WHERE RemovalDate IS NULL
                 AND Subject = '{request.Subject}'";

            if (request.Id != 0)
            {
                sql += $@"
                AND Id <> {request.Id}";
            }

            var response = connection.QuerySingle<int>(sql) > 0;

            return response;
        }
    }
}
