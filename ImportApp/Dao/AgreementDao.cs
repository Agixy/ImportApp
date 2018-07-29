using Dapper;
using ImportApp.Model;
using MySql.Data.MySqlClient;

namespace ImportApp.Dao
{
    class AgreementDao
    {
        private readonly PersonDao personDao;
        private readonly FinancialStateDao financialStateDao;

        public AgreementDao()
        {
            personDao = new PersonDao();
            financialStateDao = new FinancialStateDao();
        }

        public void Insert(Agreement agreement)
        {         
            personDao.Insert(agreement.Person);
            financialStateDao.Insert(agreement.FinancialState);

            string sql = @"INSERT INTO `importapp`.`agreement` (`Number`, `PersonId`, `FinancialStateId`)
                    VALUES (@Number, @PersonId, @FinancialStateId);
                    SELECT LAST_INSERT_ID();";

            var parameters = new DynamicParameters();
            parameters.Add("@Number", agreement.Number);
            parameters.Add("@PersonId", agreement.Person.Id);
            parameters.Add("@FinancialStateId", agreement.FinancialState.Id);

            using (var connection = new MySqlConnection(Connections.ConnectionString))
            {
                agreement.Id = connection.ExecuteScalar<int>(sql, parameters);
            }
        }
    }
}
