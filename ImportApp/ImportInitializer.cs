using ImportApp.Builders;

namespace ImportApp
{
    public class ImportInitializer
    {
        private DatabaseCreator databaseCreator;
        private RecordBuilder recordBuilder;
        private ServiceSender serviceSender;
       
        public ImportInitializer()
        {
            InitializeDependencis();
        }

        private void InitializeDependencis()
        {
            recordBuilder = new RecordBuilder();
            databaseCreator = new DatabaseCreator();
            serviceSender = new ServiceSender();
        }
    
        public void Start(string path)
        {
            databaseCreator.CreateDatabase();
            databaseCreator.CreateTables();

            var records = recordBuilder.ImportRecords(path);   

            recordBuilder.SaveRecordsToDatabase(records);

            serviceSender.Send(records);
        }     
    }
}

