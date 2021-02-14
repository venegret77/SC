namespace Common.Models.Students
{
    public sealed class UpdateStudentModel : AddOrUpdateStudentModel
    {
        public long StudentId { get; set; }
    }
}
