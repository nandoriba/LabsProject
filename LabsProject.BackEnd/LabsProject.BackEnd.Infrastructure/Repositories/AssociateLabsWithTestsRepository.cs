using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Repositories;
using LabsProject.BackEnd.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabsProject.BackEnd.Infrastructure.Repositories
{
    public class AssociateLabsWithTestsRepository : IAssociateLabsWithTestsRepository
    {
        private readonly DataContext _dataContext;

        public AssociateLabsWithTestsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(AssociateLabsWithTests item)
        {
            _dataContext.AssociateLabsWithTests.Add(item);
            _dataContext.SaveChanges();
        }

        public async Task<IEnumerable<AssociateLabsWithTests>> GetAll()
        {
            return await _dataContext.AssociateLabsWithTests
                .AsNoTracking().ToListAsync();                
        }

        public async Task<AssociateLabsWithTests> GetById(Guid id)
        {           
            return await _dataContext.AssociateLabsWithTests.AsNoTracking()
            .Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public void Remove(AssociateLabsWithTests item)
        {
            _dataContext.AssociateLabsWithTests.Remove(item);
            _dataContext.SaveChangesAsync();
        }
    }
}
