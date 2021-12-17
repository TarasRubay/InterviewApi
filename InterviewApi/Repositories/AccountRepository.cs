using InterviewApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.Repositories
{
    public class AccountRepository
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Contact> _contactRepository;
        private readonly IRepository<Incident> _incedentRepository;
        public AccountRepository() { }
        public AccountRepository(
            IRepository<Account> accountRepository,
            IRepository<Contact> contactRepository,
            IRepository<Incident> incedentRepository)
        {
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
            _incedentRepository = incedentRepository;
        }
        public virtual IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAll();
        }
    }
}
