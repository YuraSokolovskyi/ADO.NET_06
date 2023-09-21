using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pract_15092023.DAL;
using Pract_15092023.DAL.Entity;
using Pract_15092023.DAL.Repositories;

namespace Pract_15092023
{
    public class StudentList
    {
        public List<Student> Students;
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            // string jsonPath = "D:\\C#\\Students\\Pract_15092023\\Students.json";
            // string contents = File.ReadAllText(jsonPath);
            // StudentList students = JsonConvert.DeserializeObject<StudentList>(contents);

            var context = new StudentsContext();
            var studentsRepository = new Repository<Student>(context);
            StudentsProvider studentsProvider = new StudentsProvider(studentsRepository);
            
            var cardsRepository = new Repository<StudentCard>(context);
            CardsProvider cardsProvider = new CardsProvider(cardsRepository);
            
            
            List<Student> students = studentsProvider.GetStudents().ToList();
            List<StudentCard> cards = cardsProvider.GetCards().ToList();
            
            
            // studentsProvider.UpdateName(1, "Ivan");
            // studentsProvider.AddStudent(new Student()
            // {
            //     Name = "Romanova", 
            //     LastName = "Romanov",
            //     MailAddress = "otherMail@gmail.com",
            //     PhoneNumber = "3805445342456",
            //     BirthDate = new DateTime(2005, 5, 18, 12, 0, 0),
            //     StudentCard = new StudentCard()
            //     {
            //         CardNumber = "GA-153456",
            //         IsActive = true,
            //         ExpireDate = new DateTime(2025, 9, 16, 12, 0, 0)
            //     }
            // });
            
            // provider.AddStudents(students.Students);
            // studentsProvider.DeleteStudentById(5);
            // studentsProvider.DeleteStudentByCardNumber("GA-153456");
            
            foreach ( var student in studentsProvider.GetStudentsOlder(19) )
            {
                Console.WriteLine(
                    $@"Student Id: {student.Id}
                        Name: {student.Name} {student.LastName},
                        DateBirth: {student.BirthDate},
                        Mail: {student.MailAddress},
                        Phone: {student.PhoneNumber},
                        StudentCard: {student.StudentCard.CardNumber}, exp.date: {student.StudentCard.ExpireDate}");
            
            }
        }
    }
}