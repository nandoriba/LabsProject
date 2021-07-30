using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Repositories;
using LabsProject.BackEnd.Domain.ValueObjects;
using LabsProject.BackEnd.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsProject.BackEnd.Infrastructure.Repositories
{
    public class LaboratoriesRepository : ILaboratoriesRepository
    {
        private readonly DataContext _dataContext;

        public LaboratoriesRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public void Add(Laboratories item)
        {
            _dataContext.Laboratories.Add(item);
            _dataContext.SaveChanges();
        }

        public void AddCollection(IEnumerable<Laboratories> collectionItem)
        {
            _dataContext.AddRange(collectionItem);
            _dataContext.SaveChanges();
        }

        public async Task<IEnumerable<Laboratories>> GetAll()
        {
            return await _dataContext
                .Laboratories
                .AsNoTracking()
                .Where(w => w.StateId == State.Active.Id)
                .ToListAsync();                
        }

        public async Task<Laboratories> GetById(Guid id)
        {
            return await _dataContext.Laboratories.AsNoTracking()
                .Where(w => w.Id == id && w.StateId != State.Inactive.Id)
                .FirstOrDefaultAsync();                            
        }       

        public void Update(Laboratories item)
        {
             _dataContext.Update(item);
            _dataContext.SaveChanges();
        }

        public void UpdateCollection(IEnumerable<Laboratories> collectionItem)
        {
            _dataContext.UpdateRange(collectionItem);
            _dataContext.SaveChanges();
        }
    }
}
