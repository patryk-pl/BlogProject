using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Database
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        List<Entity> GetAll();
        bool AddNew(Entity entity);
        bool Delete(Entity entity);
        bool SaveChanges();
    }
}
