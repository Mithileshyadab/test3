namespace AngularAPI.APIModel
{
    #region Student
    public class BasicStudentResponse
    {
        public string? Message { get; set; }
        public int? Code { get; set; }
        public bool? success { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Batch { get; set; }
        public string? Mobile { get; set; }
        public int? StudentID { get; set; }
        
    }
    public class StudentResponseData
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Batch { get; set; }
        public string? Mobile { get; set; }
        public int? StudentID { get; set; }

    }
    public class StudentResponse
    {
        public string? Message { get; set; }
        public int? Code { get; set; }
        public bool? success { get; set; }
        public List<StudentResponseData>? StudentList { get; set; }

    }
    public class StudentRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Batch { get; set; }
        public string? Mobile { get; set; }
       
    }
    public class StudentUpdateRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Batch { get; set; }
        public string? Mobile { get; set; }
        public int? StudentID { get; set; }
    }

    public class Responsecommon
    {
        public string? Message { get; set; }
        public int? code { get; set; }
        public bool? success { get; set; }
       
    }
    #endregion
}
