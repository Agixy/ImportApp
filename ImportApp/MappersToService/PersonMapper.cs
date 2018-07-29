using ImportApp.ImportService;
using ImportApp.MappersToService;
using FinancialState = ImportApp.Model.FinancialState;
using Person = ImportApp.Model.Person;

namespace ImportApp
{
    class PersonMapper
    {
        private readonly FinancialStateMapper financialStateMapper;
        private readonly AddressMapper addressMapper;

        public PersonMapper()
        {
            financialStateMapper = new FinancialStateMapper();
            addressMapper = new AddressMapper();
        }

        public ImportService.Person MapToServiceObj(Person person, FinancialState financialState)
        {
            var servicefinancialState = financialStateMapper.MapToServiceObj(financialState);
            var mainAddress = addressMapper.MapToMainAddress(person.Address);
            var correspondenceAddress = addressMapper.MapToCorrespondenceAddress(person.Address);     

            ImportService.Person servicePerson = new ImportService.Person
            {
                Name = person.FirstName,
                Surname = person.Surname,
                NationalIdentificationNumber = person.NationalIdentificationNumber,
                FinancialState = servicefinancialState,             
                Phones = new Phone[] {new Phone{}, new Phone()},
                Addresses = new Address[] {mainAddress, correspondenceAddress}    
            };
         
            return servicePerson;
        }
    }
}





