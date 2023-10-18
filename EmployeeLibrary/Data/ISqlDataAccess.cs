using Dapper;

namespace EmployeeLibrary.Data
{
    public interface ISqlDataAccess
    {
        Task<T?> LoadDataAsync<T, U>(string sql, U parameters, string connectionStringName = "Default");
        Task<IList<T>> LoadDataListAsync<T, U>(string sql, U parameters, string connectionStringName = "Default");
        Task<T?> LoadDataMultipleAsync<T, U, F, S>(string sql, U parameters, Func<F, S, T> map, string connectionStringName = "Default");
        Task<IList<T>> LoadDataMultipleListAsync<T, U, F, S>(string sql, U parameters, Func<F, S, T> map, string connectionStringName = "Default");
        Task<bool> SaveDataAsync(string storedProcedure, DynamicParameters parameters, string connectionStringName = "Default");
    }
}