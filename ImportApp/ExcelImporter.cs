using System.Data;
using System.IO;
using ExcelDataReader;

namespace ImportApp
{
    internal class ExcelImporter
    {
        public DataTable ImportExcelFileToDataTable(string path)
        {
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                var reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                var excelReadResult = reader.AsDataSet(ExcelDataSetConfig());

                DataTable dataTable = excelReadResult.Tables[0];
                FormattDataTableHeaders(dataTable);

                return dataTable;
            }
        }

        private void FormattDataTableHeaders(DataTable dataTable)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
               column.Caption = FormatCaptionString(column.Caption);
            }

        }

        private string FormatCaptionString(string value)
        {
            return value               
                .Replace(" ", string.Empty)
                .Replace("_", string.Empty);
        }

        private ExcelDataSetConfiguration ExcelDataSetConfig()
        {
            return new ExcelDataSetConfiguration()
            {
                UseColumnDataType = true,
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true,
                    FilterRow = (rowReader) => true,
                    FilterColumn = (rowReader, columnIndex) => true
                }
            };
        }
    }
}
