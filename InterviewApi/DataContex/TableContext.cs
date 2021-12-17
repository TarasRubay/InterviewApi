using InterviewApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.DataContex
{
    public class TableContex : DbContext
    {
        public TableContex(DbContextOptions<TableContex> option) : base(option)
        { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Incident> Incidents { get; set; }
    }
}
