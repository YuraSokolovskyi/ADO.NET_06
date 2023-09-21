using Pract_15092023.DAL.Entity;
using Pract_15092023.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract_15092023
{
    public class StudentsProvider
    {
        private readonly IRepository<Student> _studentRepository;


        public StudentsProvider(IRepository<Student> repository)
        {
            _studentRepository = repository;
        }

        public void AddStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                AddStudent(student);
            }
        }

        public void AddStudent(Student student) 
        {
            if (_studentRepository
                    .GetAll()
                    .ToList()
                    .Select(st => st)
                    .Where(st => st.StudentCard.CardNumber == student.StudentCard.CardNumber)
                    .ToList().Count == 0) 
                _studentRepository.Add(student);
            else
            {
                Console.WriteLine("TEST");
            }
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.Get(id);
        }

        public List<Student> GetStudentsByName(string name)
        {
            return _studentRepository.GetAll().Where(student => student.Name == name).ToList();
        }
        
        public List<Student> GetStudentsByLastName(string lastName)
        {
            return _studentRepository.GetAll().Where(student => student.LastName == lastName).ToList();
        }
        
        public List<Student> GetStudentsByPhoneNumber(string phoneNumber)
        {
            return _studentRepository.GetAll().Where(student => student.PhoneNumber == phoneNumber).ToList();
        }
        
        public List<Student> GetStudentsByCardNumber(string cardNumber)
        {
            return _studentRepository.GetAll().Where(student => student.StudentCard.CardNumber == cardNumber).ToList();
        }
        
        public List<Student> GetStudentsSortedByAge(int numberOfStudents)
        {
            return _studentRepository.GetAll().OrderBy(student => student.BirthDate).Take(numberOfStudents + 1).ToList();
        }
        
        public List<Student> GetStudentsSortedByAgeReverse(int numberOfStudents)
        {
            return _studentRepository.GetAll().OrderByDescending(student => student.BirthDate).Take(numberOfStudents + 1).ToList();
        }

        public List<Student> GetStudentsWithActiveCards()
        {
            return _studentRepository.GetAll().Where(student => student.StudentCard.IsActive).ToList();
        }
        
        public List<Student> GetStudentsWithNotActiveCards()
        {
            return _studentRepository.GetAll().Where(student => !student.StudentCard.IsActive).ToList();
        }

        public List<Student> GetStudentsWithCardExpireDateAfter(DateTime date)
        {
            return _studentRepository.GetAll().Where(student => student.StudentCard.ExpireDate > date).ToList();
        }
        
        public List<Student> GetStudentsWithCardExpireDateBefore(DateTime date)
        {
            return _studentRepository.GetAll().Where(student => student.StudentCard.ExpireDate < date).ToList();
        }
        
        public List<Student> GetStudentsWithCardExpireDateEqual(DateTime date)
        {
            return _studentRepository.GetAll().Where(student => student.StudentCard.ExpireDate == date).ToList();
        }

        public List<Student> GetStudentsOlder(int age)
        {
            return _studentRepository.GetAll().Where(student => student.BirthDate <= DateTime.Today.AddYears(-age))
                .ToList();
        }
        
        public List<Student> GetStudentsYounger(int age)
        {
            return _studentRepository.GetAll().Where(student => student.BirthDate >= DateTime.Today.AddYears(-age))
                .ToList();
        }
        
        public List<Student> GetStudentsByAge(int age)
        {
            return _studentRepository.GetAll().Where(student => student.BirthDate.Year == DateTime.Today.AddYears(-age).Year)
                .ToList();
        }

        public Student GetStudentWithEmail(string email)
        {
            return _studentRepository.GetAll().Where(student => student.MailAddress == email).Take(1).ToList()[0];
        }
        
        public Student GetStudentWithPhone(string phone)
        {
            return _studentRepository.GetAll().Where(student => student.PhoneNumber == phone).Take(1).ToList()[0];
        }

        public IEnumerable<Student> GetStudents() 
        { 
            return  _studentRepository.GetAll(); 
        }

        public void UpdateName(int id, string name)
        {
            Student student = _studentRepository.Get(id);
            student.Name = name;
            _studentRepository.Update(student);
        }
        
        public void UpdateLastName(int id, string lastName)
        {
            Student student = _studentRepository.Get(id);
            student.LastName = lastName;
            _studentRepository.Update(student);
        }
        
        public void UpdateBirthDate(int id, DateTime birthdate)
        {
            Student student = _studentRepository.Get(id);
            student.BirthDate = birthdate;
            _studentRepository.Update(student);
        }
        
        public void UpdateMailAddress(int id, string mailAddress)
        {
            Student student = _studentRepository.Get(id);
            student.MailAddress = mailAddress;
            _studentRepository.Update(student);
        }
        
        public void UpdatePhoneNumber(int id, string phoneNumber)
        {
            Student student = _studentRepository.Get(id);
            student.PhoneNumber = phoneNumber;
            _studentRepository.Update(student);
        }
        
        public void UpdateStudentCard(int id, StudentCard card)
        {
            Student student = _studentRepository.Get(id);
            student.StudentCard = card;
            _studentRepository.Update(student);
        }

        public void DeleteStudentById(int id)
        {
            _studentRepository.Remove(GetStudentById(id));
        }
        
        public void DeleteStudentByCardNumber(string cardNumber)
        {
            _studentRepository.Remove(GetStudentsByCardNumber(cardNumber)[0]);
        }
    }
}
