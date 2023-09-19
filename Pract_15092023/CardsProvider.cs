using Pract_15092023.DAL.Entity;
using Pract_15092023.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract_15092023
{
    public class CardsProvider
    {
        private readonly IRepository<StudentCard> _cardRepository;


        public CardsProvider(IRepository<StudentCard> repository)
        {
            _cardRepository = repository;
        }

        public void AddCards(List<StudentCard> Cards)
        {
            foreach (var Card in Cards)
            {
                AddCard(Card);
            }
        }

        public void AddCard(StudentCard Card) 
        {
            _cardRepository.Add(Card);
        }

        public StudentCard GetCard(int id)
        {
            return _cardRepository.Get(id);
        }

        public IEnumerable<StudentCard> GetCards() 
        { 
            return  _cardRepository.GetAll(); 
        }
        
        public void UpdateNumber(int id, string number)
        {
            StudentCard card = _cardRepository.Get(id);
            card.CardNumber = number;
            _cardRepository.Update(card);
        }
        
        public void UpdateExpireDate(int id, DateTime date)
        {
            StudentCard card = _cardRepository.Get(id);
            card.ExpireDate = date;
            _cardRepository.Update(card);
        }
        
        public void UpdateIsActive(int id, bool isActive)
        {
            StudentCard card = _cardRepository.Get(id);
            card.IsActive = isActive;
            _cardRepository.Update(card);
        }
        
        public void UpdateStudent(int id, Student student)
        {
            StudentCard card = _cardRepository.Get(id);
            card.Student = student;
            _cardRepository.Update(card);
        }
    }
}
