using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

public interface IBaseRepository<TEntity> where TEntity : BaseData
{
    Task<int?> Add(TEntity entity);
    Task Delete(int id);
    Task<bool> Update(TEntity entity);
    Task<TEntity> Get(object id);
    Task<IEnumerable<TEntity>> GetAll();
    Task<int?> AddAsync(TEntity entity);
    Task<int?> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(int id);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> GetAsync(int id);
    Task<TEntity> GetAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> Execute(string query, object? parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60);
}
