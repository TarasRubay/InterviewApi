using InterviewApi.DataContex;
using InterviewApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly TableContex _context;
       
        
        public AccountRepository() { }
        public AccountRepository(TableContex context)
        {
            _context = context;
            
        }

        public Account Create(Account entity)
        {
            _context.Accounts.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts;
        }

        public Account GetById(int id)
        {
            return _context.Accounts.Where(p => p.Id == id).FirstOrDefault();
        }

    }
}
