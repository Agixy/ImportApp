using ImportApp.Model;

namespace ImportApp.MappersToService
{
    class FinancialStateMapper
    {
        public ImportService.FinancialState MapToServiceObj(FinancialState financialState)
        {
            var serviceFinancialState = new ImportService.FinancialState()
            {
                Interest = financialState.Interests,
                PenaltyInterest = financialState.PenaltyInterests,
                Fees = financialState.Fees,
                CourtFees = financialState.CourtFees,
                CourtRepresentationFees = financialState.RepresentationCourtFees,
                Capital = financialState.Capital
            };

            return serviceFinancialState;
        }
    }
}
