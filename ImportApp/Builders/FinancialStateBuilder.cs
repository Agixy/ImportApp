using System;
using System.Data;
using ImportApp.Model;

namespace ImportApp.Builders
{
    class FinancialStateBuilder : ValueImporter
    {
        private const string CapitalCaption = "KAPITAL";
        private const string InterestsCaption = "ODSETKI";
        private const string PentalyInterestsCaption = "ODSETKIKARNE";
        private const string FeesCaption = "OPŁATY";
        private const string CourtFeesCaption = "KOSZTYSADOWE";
        private const string RepresentationCourtFeesCaption = "KOSZTYZASTEPSTWASADOWEGO";
        private const string VindicationCostsCaption = "KOSZTYEGZEKUCJI";
        private const string RepresentationVindicationCostsCaption = "KOSZTYZASTEPSTWAEGZEKUCYJNEGO";
    
        public FinancialState CreateFromDataTable(DataTable dataTable, int row)
        {
            FinancialState financialState = new FinancialState()
            {
                Interests = ConvertToDecimal(GetValueFromColumn(dataTable, InterestsCaption, row)),
                PenaltyInterests = ConvertToDecimal(GetValueFromColumn(dataTable, PentalyInterestsCaption, row)),
                Fees = ConvertToDecimal(GetValueFromColumn(dataTable, FeesCaption, row)),
                CourtFees = ConvertToDecimal(GetValueFromColumn(dataTable, CourtFeesCaption, row)),
                RepresentationCourtFees = ConvertToDecimal(GetValueFromColumn(dataTable, RepresentationCourtFeesCaption, row)),
                VindicationCosts = ConvertToDecimal(GetValueFromColumn(dataTable, VindicationCostsCaption, row)),
                RepresentationVindicationCosts = ConvertToDecimal(GetValueFromColumn(dataTable, RepresentationVindicationCostsCaption, row)),
                Capital = ConvertToDecimal(GetValueFromColumn(dataTable, CapitalCaption, row)),
            };

            return financialState;
        }

        private decimal ConvertToDecimal(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? 0 : Convert.ToDecimal(value);
        }
    }
}
