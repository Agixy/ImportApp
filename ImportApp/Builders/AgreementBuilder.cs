using System.Data;
using ImportApp.Model;

namespace ImportApp.Builders
{
    class AgreementBuilder : ValueImporter
    {
        private const string NumberCaption = "NRUMOWY";

        public Agreement CreateFromDataTable(DataTable dataTable, int row, Person person, FinancialState financialState)
        {
            Agreement agreement = new Agreement()
            {
                Number = GetValueFromColumn(dataTable, NumberCaption, row),
                Person = person,
                FinancialState = financialState                
            };

            return agreement;
        }
    }
}
