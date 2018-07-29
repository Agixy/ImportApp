using ImportApp.Model;

namespace ImportApp.MappersToService
{
    class AddressMapper
    {
        public ImportService.Address MapToMainAddress(Address address)
        {
            var serviceAddress = new ImportService.Address
            {
                Street = address.StreetName,
                HouseNo = address.StreetNumber,
                LocaleNo = address.FlatNumber,
                PostalCode = address.PostCode,
                City = address.PostOfficeCity,
                AddressType = "Main"
            };

            return serviceAddress;
        }

        public ImportService.Address MapToCorrespondenceAddress(Address address)
        {
            var serviceAddress = new ImportService.Address
            {
                Street = address.CorrespondenceStreetName,
                HouseNo = address.CorrespondenceStreetNumber,
                LocaleNo = address.CorrespondenceFlatNumber,
                PostalCode = address.CorrespondencePostCode,
                City = address.CorrespondencePostOfficeCity,
                AddressType = "Correspondence"
            };
        
            return serviceAddress;
        }     
    }
}
