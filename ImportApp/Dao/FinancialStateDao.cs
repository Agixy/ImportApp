using Dapper;
using ImportApp.Model;
using MySql.Data.MySqlClient;

namespace ImportApp.Dao
{
    class FinancialStateDao
    {
        public void Insert(FinancialState financialState)
        {
            string sql = @"INSERT INTO `importapp`.`financialstate` (`OutstandingLiabilites`, `Interests`, `PenaltyInterests`, `Fees`, `CourtFees`, 
                `RepresentationCourtFees`, `VindicationCosts`, `RepresentationVindicationCosts`) 
                 VALUES (@OutstandingLiabilites, @Interests, @PenaltyInterests, @Fees, @CourtFees, 
                 @RepresentationCourtFees, @VindicationCosts, @RepresentationVindicationCosts); SELECT LAST_INSERT_ID();";

            var parameters = new DynamicParameters();
            parameters.Add("@OutstandingLiabilites", financialState.OutstandingLiabilites);
            parameters.Add("@Interests", financialState.Interests);
            parameters.Add("@PenaltyInterests", financialState.PenaltyInterests);
            parameters.Add("@Fees", financialState.Fees);
            parameters.Add("@CourtFees", financialState.CourtFees);
            parameters.Add("@RepresentationCourtFees", financialState.RepresentationCourtFees);
            parameters.Add("@VindicationCosts", financialState.VindicationCosts);
            parameters.Add("@RepresentationVindicationCosts", financialState.RepresentationVindicationCosts);

            using (var connection = new MySqlConnection(Connections.ConnectionString))
            {
                financialState.Id = connection.ExecuteScalar<int>(sql, parameters);
            }
        }
    }
}
