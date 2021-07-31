using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Repositories;
using LabsProject.BackEnd.Domain.ValueObjects;
using LabsProject.BackEnd.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabsProject.BackEnd.Infrastructure.Repositories
{
    public class TestsRepository : ITestsRepository
    {
        private readonly DataContext _dataContext;

        public TestsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Tests item)
        {
            _dataContext.Tests.Add(item);
            _dataContext.SaveChanges();
        }    

        public async Task<IEnumerable<Tests>> GetAll()
        {
            return await _dataContext
                .Tests
                .AsNoTracking()
                .Where(w => w.StateId == State.Active.Id)
                .ToListAsync();
        }

        public async Task<Tests> GetById(Guid id)
        {
            return await _dataContext.Tests.AsNoTracking()
            .Where(w => w.Id == id && w.StateId != State.Inactive.Id).FirstOrDefaultAsync();
        }

        public void RemoveCollection(IEnumerable<Tests> collectionItem)
        {
            _dataContext.UpdateRange(collectionItem);
            _dataContext.SaveChanges();
        }

        public void Update(Tests item)
        {
            _dataContext.Entry(item).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }      
    }
}
