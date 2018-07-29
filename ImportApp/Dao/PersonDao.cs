using System.Collections.Generic;
using System.Linq;
using Dapper;
using ImportApp.Model;
using MySql.Data.MySqlClient;

namespace ImportApp.Dao
{
    class PersonDao
    {
        private readonly AddressDao addressDao;

        public PersonDao()
        {
            addressDao = new AddressDao();
        }

        public void Insert(Person person)
        {
            addressDao.Insert(person.Address);

            string sql = @"INSERT INTO `importapp`.`person` (`FirstName`, `SecondName`, `Surname`, `NationalIdentificationNumber`, 
                    `PhoneNumber`, `PhoneNumber2`, `AddressId`) 
                     VALUES (@FirstName, @SecondName, @Surname, @NationalIdentificationNumber, @PhoneNumber, 
                     @PhoneNumber2, @AddressId); SELECT LAST_INSERT_ID();";


            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", person.FirstName);
            parameters.Add("@SecondName", null);
            parameters.Add("@Surname", person.Surname);
            parameters.Add("@NationalIdentificationNumber", person.NationalIdentificationNumber);
            parameters.Add("@PhoneNumber", person.PhoneNumber);
            parameters.Add("@PhoneNumber2", person.PhoneNumber2);
            parameters.Add("@AddressId", person.Address.Id);

            using (var connection = new MySqlConnection(Connections.ConnectionString))
            {
                person.Id = connection.ExecuteScalar<int>(sql, parameters);
            }
        }
    }
}
