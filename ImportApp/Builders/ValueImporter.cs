using System;
using System.Data;

namespace ImportApp.Builders
{
    abstract class ValueImporter
    {
        public string GetValueFromColumn(DataTable dataTable, string columnName, int row)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.Caption.ToUpper() == columnName)
                    return dataTable.Rows[row][column.ColumnName].ToString();               
            }

            throw new Exception("Nie ma kolumny o takiej nazwie");          
        } 
    }
}
