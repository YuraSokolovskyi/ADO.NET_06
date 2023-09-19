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
            
            
            studentsProvider.UpdateName(1, "Ivan");
            

            var cardsRepository = new Repository<StudentCard>(context);
            CardsProvider cardsProvider = new CardsProvider(cardsRepository);
            
            // provider.AddStudents(students.Students);

            List<Student> students = studentsProvider.GetStudents().ToList();
            List<StudentCard> cards = cardsProvider.GetCards().ToList();
            
            foreach ( var student in students )
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