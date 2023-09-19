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
            _studentRepository.Add(student);
        }

        public Student GetStudent(int id)
        {
            return _studentRepository.Get(id);
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
    }
}
