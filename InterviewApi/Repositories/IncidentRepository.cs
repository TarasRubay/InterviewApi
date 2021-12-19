using InterviewApi.DataContex;
using InterviewApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.Repositories
{
    public class IncidentRepository : IRepository<Incident>
    {
        private readonly TableContex _context;


        public IncidentRepository() { }
        public IncidentRepository(TableContex context)
        {
            _context = context;

        }

        public Incident Create(Incident entity)
        {
            if(entity is null) throw new ArgumentNullException(nameof(entity));

            _context.Incidents.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<Incident> GetAll()
        {
            return _context.Incidents;
        }

        public Incident GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Incident GetByName(string name)
        {
            return _context.Incidents.Where(p => p.Name == name).FirstOrDefault();
        }

    }
}