using System.Collections.Generic;
using ImportApp.Builders;
using ImportApp.ImportService;
using ImportApp.Model;

namespace ImportApp
{
    class ServiceSender
    {
        private readonly PersonMapper personMapper;
        private readonly IImportService importService;

        public ServiceSender()
        {
            personMapper = new PersonMapper();
            importService = new ImportServiceClient();
        }

        public void Send(List<Agreement> records)
        {            
            foreach (var record in records)
            {
                var person = personMapper.MapToServiceObj(record.Person, record.FinancialState);

                //importService.DoImport(person);
            }

        }
    }
}
