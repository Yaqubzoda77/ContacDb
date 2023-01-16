using Domain.Dtos;
using Npgsql;
using Dapper;
namespace Infrustructure.Services;

public class ContactServices
{
    private string _connectionString = "Server=127.0.0.1;Port=5432;Database=ContactDB;User Id=postgres;Password=13577;";
    public List<Contact> GetContact()
    {
       
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM ContactDb order by id";
            var result = connection.Query<Contact>(sql);
            return result.ToList();
        }

    }
    public bool AddContact(Contact contact)
    {

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"insert into ContactDb(Name,Address,telephone)" +
                      $"values ('{contact.Name}','{contact.Address}',{contact.telephone})";
            var inserted =  connection.Execute(sql);
            if (inserted > 0) return true;
            else return false;
        }
    }
        
    public bool UpdateContact(Contact contact)
    {

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            string sql = $"update ContactDb set Name= '{contact.Name}', Address = '{contact.Address}' , telephone = {contact.telephone} where Id = {contact.Id} ";
            var updated = connection.Execute(sql);
            if (updated > 0) return true;
            else return false;
        }   
    }
    public bool DeleteContact(int  id)
    {

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"delete from ContactDb where Id = {id}";
            var deleted = connection.Execute(sql);
            if (deleted > 0) return true;
            else return false;
        }
    }
    
    public List<Contact> FindByName(string Name)
    {

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            var sql = $"select * from ContactDb where Name = '{Name}'";
            var deleted = connection.Query<Contact>(sql);
            return deleted.ToList();
        }
    }
                
}