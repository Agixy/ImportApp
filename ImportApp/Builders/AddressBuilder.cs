using System.Data;
using ImportApp.Model;

namespace ImportApp.Builders
{
    class AddressBuilder : ValueImporter
    {
        private const string MainStreetNameCaption = "MAINSTREETNAME";
        private const string MainStreetNumberCaption = "MAINSTREETNUMBER";
        private const string MainStreetFlatNumberCaption = "MAINSTREETFLATNUMBER";
        private const string MainPostCodeCaption = "MAINPOSTCODE";
        private const string MainPostOfficeCityCaption = "MAINPOSTOFFICECITY";
        private const string CorrespondenceStreetNameCaption = "CORRESPONDENCESTREETNAME";
        private const string CorrespondenceStreetNumberCaption = "CORRESPONDENCESTREETNUMBER";
        private const string CorrespondenceStreetFlatNumberCaption = "CORRESPONDENCESTREETFLATNUMBER";
        private const string CorrespondencePostCodeCaption = "CORRESPONDENCEPOSTCODE";
        private const string CorrespondencePostOfficeCityCaption = "CORRESPONDENCEPOSTOFFICECITY";

        public Address CreateFromDataTable(DataTable dataTable, int row) 
        {
            Address address = new Address()
            {
                StreetName = GetValueFromColumn(dataTable, MainStreetNameCaption, row),
                StreetNumber = GetValueFromColumn(dataTable, MainStreetNumberCaption, row),
                FlatNumber = GetValueFromColumn(dataTable, MainStreetFlatNumberCaption, row),
                PostCode = GetValueFromColumn(dataTable, MainPostCodeCaption, row),
                PostOfficeCity = GetValueFromColumn(dataTable, MainPostOfficeCityCaption, row),
                CorrespondenceStreetName = GetValueFromColumn(dataTable, CorrespondenceStreetNameCaption, row),
                CorrespondenceStreetNumber = GetValueFromColumn(dataTable, CorrespondenceStreetNumberCaption, row),
                CorrespondenceFlatNumber = GetValueFromColumn(dataTable, CorrespondenceStreetFlatNumberCaption, row),
                CorrespondencePostCode = GetValueFromColumn(dataTable, CorrespondencePostCodeCaption, row),
                CorrespondencePostOfficeCity = GetValueFromColumn(dataTable, CorrespondencePostOfficeCityCaption, row),
            };

            return address;
        }
    }
}
