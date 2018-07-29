using ImportApp.Model;

namespace ImportApp.MappersToService
{
    class AgreementMapper
    {
        private readonly PersonMapper personMapper;

        public AgreementMapper()
        {
            personMapper = new PersonMapper(); 
        }

        public ImportService.Person MapToServiceObj(Agreement agreement)
        {
            var servicePerson = personMapper.MapToServiceObj(agreement.Person, agreement.FinancialState);

            return servicePerson;
        }
    }
}
