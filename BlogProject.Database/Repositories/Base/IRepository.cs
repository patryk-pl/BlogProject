using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Database
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        List<Entity> GetAll();
        Task<bool> AddNew(Entity entity);
        Task<bool> Delete(Entity entity);
        Task<bool> SaveChangesAsync();
    }
}
