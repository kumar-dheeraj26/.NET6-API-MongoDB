using StudentsManagement.Models;

namespace StudentsManagement.Services
{
    public interface IStudentService
    {
        Student Create(Student student);
        List<Student> Get();
        Student Get(string id);
        void Update(string id, Student student);
        void Remove(string id);
    }
}
