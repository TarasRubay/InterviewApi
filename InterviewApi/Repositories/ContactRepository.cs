using InterviewApi.DataContex;
using InterviewApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private readonly TableContex _context;


        public ContactRepository() { }
        public ContactRepository(TableContex context)
        {
            _context = context;

        }

        public Contact Create(Contact entity)
        {
            _context.Contacts.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _context.Contacts;
        }

        public Contact GetById(int id)
        {
            return _context.Contacts.Where(p => p.Id == id).FirstOrDefault();
        }

    }
}