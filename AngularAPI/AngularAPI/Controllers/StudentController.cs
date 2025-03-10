using System.Data;
using System.Data.SqlClient;
using AngularAPI.APIModel;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly string _configuration;
        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration.GetConnectionString("conStr");
        }
        #region
        [HttpPost, Route("Api/ListOfStudent")]
        public async Task<StudentResponse> ListOfStudent()
        {
            StudentResponse response = new StudentResponse();
            response.StudentList = new List<StudentResponseData>();
            #region Parameters
            var parameters = new DynamicParameters();
            #endregion
            try
            {
                using (IDbConnection con = new SqlConnection(_configuration))
                {
                    var responseAllData = await con.QueryAsync<BasicStudentResponse>("API_ListOfStudent", null, null, null, CommandType.StoredProcedure);
                    bool RunOnce = true;
                    if (responseAllData != null)
                    {
                        foreach (var item in responseAllData)
                        {
                            if (RunOnce)
                            {
                                response.Message = item.Message;
                                response.Code = item.Code;
                                response.success = item.success;
                                RunOnce = false;
                            }
                            #region
                            StudentResponseData Data = new StudentResponseData();
                            Data.Name = item.Name;
                            Data.StudentID = item.StudentID;
                            Data.Batch = item.Batch;
                            Data.Email = item.Email;
                            Data.Mobile = item.Mobile;
                            #endregion
                            response.StudentList.Add(Data);
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 999;
                response.success = false;
                return response;
            }
        }
        #endregion
        #region API Create Student

        [HttpPost, Route("Api/CreateStudent")]
        public async Task<BasicStudentResponse> CreateStudent(StudentRequest request)
        {
            var response = new BasicStudentResponse();
           
            #region Parameters
            var parameters = new DynamicParameters();
            parameters.Add("Name", request.Name,DbType.String);
            parameters.Add("Email", request.Email,DbType.String);
            parameters.Add("Batch", request.Batch,DbType.String);
            parameters.Add("Mobile", request.Mobile,DbType.String);
            
            #endregion
            try
            {
                using (IDbConnection con = new SqlConnection(_configuration))
                {
                    response = await con.QueryFirstAsync<BasicStudentResponse>("API_createtbl_Student", parameters, null, null, CommandType.StoredProcedure);

                   
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 999;
                response.success = false;
                return response;
            }
        }
        #endregion

        #region API Update Student
        

        [HttpPost, Route("Api/UpdateStudent")]
        public async Task<BasicStudentResponse> UodateStudent(StudentUpdateRequest request)
        {
            var response = new BasicStudentResponse();

            #region Parameters
            var parameters = new DynamicParameters();
            parameters.Add("Name", request.Name, DbType.String);
            parameters.Add("Email", request.Email, DbType.String);
            parameters.Add("Batch", request.Batch, DbType.String);
            parameters.Add("Mobile", request.Mobile, DbType.String);
            parameters.Add("studentID", request.StudentID, DbType.String);

            #endregion
            try
            {
                using (IDbConnection con = new SqlConnection(_configuration))
                {
                    response = await con.QueryFirstAsync<BasicStudentResponse>("update_student", parameters, null, null, CommandType.StoredProcedure);


                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 999;
                response.success = false;
                return response;
            }
        }
        #endregion

        #region API Get Student


        [HttpPost, Route("Api/GetStudent")]
        public async Task<BasicStudentResponse> GetStudent(Int32? studentID)
        {
            var response = new BasicStudentResponse();

            #region Parameters
            var parameters = new DynamicParameters();
            parameters.Add("studentID",studentID, DbType.Int32);

            #endregion
            try
            {
                using (IDbConnection con = new SqlConnection(_configuration))
                {
                    response = await con.QueryFirstAsync<BasicStudentResponse>("get_student", parameters, null, null, CommandType.StoredProcedure);


                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 999;
                response.success = false;
                return response;
            }
        }
        #endregion

        #region API Delete Student


        [HttpPost, Route("Api/DeleteStudent")]
        public async Task<BasicStudentResponse> DeleteStudent(Int32? s)
        {
            var response = new BasicStudentResponse();

            #region Parameters
            var parameters = new DynamicParameters();
            parameters.Add("studentID", s, DbType.Int32);

            #endregion
            try
            {
                using (IDbConnection con = new SqlConnection(_configuration))
                {
                    response = await con.QueryFirstAsync<BasicStudentResponse>("API_Delete_student", parameters, null, null, CommandType.StoredProcedure);


                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Code = 999;
                response.success = false;
                return response;
            }
        }
        #endregion


    }

}
