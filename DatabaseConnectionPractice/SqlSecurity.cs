using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Baseball.Data.Sql
{
    public class SqlSecurity : ISecurity
    {
        private readonly string connectionString;

        public SqlSecurity(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            this.connectionString = connectionString;
        }

        public Person Authenticate(string username, string password)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Person WHERE Username = @Username AND Password = @Password";
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            throw new InvalidOperationException();
                        }
                        reader.Read();
                        var person = new Person();
                        person.PersonId = reader.GetInt32(0);
                        person.IsPlayer = reader.GetBoolean(3);
                        person.IsCaptain = reader.GetBoolean(4);
                        person.DisplayName = reader.GetString(5);
                        return person;
                    }
                }
            }
        }
    }
}
