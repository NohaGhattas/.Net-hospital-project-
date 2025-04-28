using HospitalManagementSystem.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        { 
         await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByNameAsync(string name, string? departmentName = null)
        {
            IQueryable<T> query = _context.Set<T>();

            query = query.Where(e => EF.Property<string>(e, "Name") == name);

            if (!string.IsNullOrEmpty(departmentName))
            {
                if (typeof(T).GetProperty("Department") != null)
                {
                    query = query.Include("Department")
                                 .Where(e => EF.Property<string>(EF.Property<object>(e, "Department"), "Name") == departmentName);
                }
                else
                {
                    query = query.Where(e => EF.Property<string>(e, "DepartmentName") == departmentName);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
