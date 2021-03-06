using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseData
{
    protected string ConnectionString { get; set; }

    protected BaseRepository(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public async Task Delete(int id)
    {
        await using var connection = new SqlConnection(ConnectionString);
        var entity = connection.Get<TEntity>(id);
        await connection.DeleteAsync(entity);
        await connection.CloseAsync();
    }

    public async Task<bool> Update(TEntity entity)
    {
        await using var connection = new SqlConnection(ConnectionString);
        var result = connection.Update(entity);
        await connection.CloseAsync();
        return result;
    }

    public async Task<TEntity> Get(object id)
    {
        await using var connection = new SqlConnection(ConnectionString);
        var result = await connection.GetAsync<TEntity>(id);
        await connection.CloseAsync();
        return result;
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        await using var connection = new SqlConnection(ConnectionString);
        var result = await connection.GetAllAsync<TEntity>();
        await connection.CloseAsync();
        return result;
    }
    
    public async Task<int?> Add(TEntity entity)
    {
        await using var connection = new SqlConnection(ConnectionString);
        var result = await connection.InsertAsync(entity);
        await connection.CloseAsync();
        return result;
    }
    public virtual async Task<int?> AddAsync(TEntity entity)
    {
        return await AddAsync(entity, CancellationToken.None).ConfigureAwait(false);
    }

    public virtual async Task<int?> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        return await Task.Run(() => Add(entity), cancellationToken).ConfigureAwait(false);
    }

    public virtual async Task DeleteAsync(int id)
    {
        await DeleteAsync(id, CancellationToken.None).ConfigureAwait(false);
    }

    public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        await Task.Run(() => Delete(id), cancellationToken).ConfigureAwait(false);
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity)
    {
        return await Task.Run(() => Update(entity), CancellationToken.None).ConfigureAwait(false);
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        return await Task.Run(() => Update(entity), cancellationToken).ConfigureAwait(false);
    }

    public virtual async Task<TEntity> GetAsync(int id)
    {
        return await GetAsync(id, CancellationToken.None).ConfigureAwait(false);
    }

    public virtual async Task<TEntity> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await Task.Run(() => Get(id), cancellationToken).ConfigureAwait(false);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await GetAllAsync(CancellationToken.None).ConfigureAwait(false);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Task.Run(GetAll, cancellationToken).ConfigureAwait(false);
    }

    public async Task<TEntity> ExecuteSingle(string query, object? parameters = null)
    {
        await using var connection = new SqlConnection(ConnectionString);
        var result = connection.QuerySingle<TEntity>(query, parameters, commandType: CommandType.Text);
        await connection.CloseAsync();
        return result;
    }

    public async Task<TEntity> ExecuteSingleOrDefault(string query, object? parameters = null)
    {
        await using var connection = new SqlConnection(ConnectionString);
        var result = connection.QuerySingleOrDefault<TEntity>(query, parameters, commandType: CommandType.Text);
        await connection.CloseAsync();
        return result;
    }

    public async Task<IEnumerable<TEntity>> Execute(string query, object? parameters = null, CommandType commandType = CommandType.Text, int commandTimeOut = 60)
    {
        await using var connection = new SqlConnection(ConnectionString);
        var result = connection.Query<TEntity>(query, parameters, commandType: commandType, commandTimeout: commandTimeOut);
        await connection.CloseAsync();
        return result;
    }
}