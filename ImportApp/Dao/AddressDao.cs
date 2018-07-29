using Dapper;
using ImportApp.Model;
using MySql.Data.MySqlClient;

namespace ImportApp.Dao
{
    class AddressDao
    {
        public void Insert(Address address)
        {
            string sql = @"INSERT INTO `importapp`.`adress` (`StreetName`, `StreetNumber`, `FlatNumber`, `PostCode`, `PostOfficeCity`, `CorrespondenceStreetName`, 
                    `CorrespondenceStreetnumber`, `CorrespondenceFlatNumber`, `CorrespondencePostCode`, `CorrespondencePostOfficeCity`) 
                     VALUES (@StreetName, @StreetNumber, @FlatNumber,  @PostCode, @PostOfficeCity, @CorrespondenceStreetName, @CorrespondenceStreetNumber, 
                    @CorrespondenceFlatNumber, @CorrespondencePostCode, @CorrespondencePostOfficeCity); SELECT LAST_INSERT_ID();";

            var parameters = new DynamicParameters();
            parameters.Add("@StreetName", address.StreetName);
            parameters.Add("@StreetNumber", address.StreetNumber);
            parameters.Add("@FlatNumber", address.FlatNumber);
            parameters.Add("@PostCode", address.PostCode);
            parameters.Add("@PostOfficeCity", address.PostOfficeCity);
            parameters.Add("@CorrespondenceStreetName", address.CorrespondenceStreetName);
            parameters.Add("@CorrespondenceStreetNumber", address.CorrespondenceStreetNumber);
            parameters.Add("@CorrespondenceFlatNumber", address.CorrespondenceStreetName);
            parameters.Add("@CorrespondencePostCode", address.CorrespondencePostCode);
            parameters.Add("@CorrespondencePostOfficeCity", address.CorrespondencePostOfficeCity);


            using (var connection = new MySqlConnection(Connections.ConnectionString))
            {
                address.Id = connection.ExecuteScalar<int>(sql, parameters);
            }
        }
    }
}
