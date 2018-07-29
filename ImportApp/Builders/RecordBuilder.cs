using System.Collections.Generic;
using System.Data;
using ImportApp.Dao;
using ImportApp.Model;

namespace ImportApp.Builders
{
    class RecordBuilder
    {
        private AddressBuilder _addressBuilder;
        private PersonBuilder _personBuilder;
        private FinancialStateBuilder _financialStateBuilder;
        private AgreementBuilder _agreementBuilder;
        private AgreementDao _agreementDao;
        private ExcelImporter excelImporter;

        public RecordBuilder()
        {
            InitializeDependencis();
        }

        private void InitializeDependencis()
        {
            _addressBuilder = new AddressBuilder();
            _personBuilder = new PersonBuilder();
            _financialStateBuilder = new FinancialStateBuilder();
            _agreementBuilder = new AgreementBuilder();
            _agreementDao = new AgreementDao();
            excelImporter = new ExcelImporter();
           
        }

        public List<Agreement> ImportRecords(string path)
        {          
            DataTable dataTable = excelImporter.ImportExcelFileToDataTable(path); // tutaj to ma byc?

            List<Agreement> agreements = new List<Agreement>();
            
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Address address = _addressBuilder.CreateFromDataTable(dataTable, i);
                Person person = _personBuilder.CreateFromDataTable(dataTable, i, address);
                FinancialState financialState = _financialStateBuilder.CreateFromDataTable(dataTable, i);
                Agreement agreement = _agreementBuilder.CreateFromDataTable(dataTable, i, person, financialState);
                agreements.Add(agreement);
            }

            return agreements;
        }

        public void SaveRecordsToDatabase(List<Agreement> agreements)
        {
            foreach (var agreement in agreements)
            {
                _agreementDao.Insert(agreement);
            }
        }          
    }
}
