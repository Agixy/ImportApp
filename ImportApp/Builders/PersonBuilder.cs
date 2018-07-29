using System.Data;
using ImportApp.Model;
using PeselTester;

namespace ImportApp.Builders
{
    class PersonBuilder : ValueImporter
    {
        private readonly ValidationExecutor peselValidator = new ValidationExecutor();

        private const string NameCaption = "IMIE";
        private const string SurnameCaption = "NAZWISKO";
        private const string PeselCaption = "PESEL";
        private const string PhoneNumber1Caption = "TELEFON1";
        private const string PhoneNumber2Caption = "TELEFON2";

        public Person CreateFromDataTable(DataTable dataTable, int row, Address adress)
        {
            var pesel = GetValueFromColumn(dataTable, PeselCaption, row);
            var validationResult = peselValidator.Validate(pesel);
            if (validationResult != PeselValidationResult.Ok)
            {
                switch (validationResult)
                {
                    case PeselValidationResult.NotOnlyDigits:
                        throw new PeselInputException($"Wiersz: {row+1} - Pesel zawiera inne znaki niż cyfry");
                    case PeselValidationResult.WrongLenght:
                        throw new PeselInputException($"Wiersz: {row+1} - Pesel ma nieprawidłową długość");
                    case PeselValidationResult.WrongControlSum:
                        throw new PeselInputException($"Wiersz: {row+1} - Suma kontrolna peselu jest nieprawidłowa");
                }            
            }

            Person person = new Person()
            {
                FirstName = GetValueFromColumn(dataTable, NameCaption, row),
                SecondName = null,
                Surname = GetValueFromColumn(dataTable, SurnameCaption, row),
                NationalIdentificationNumber = pesel,
                PhoneNumber = GetValueFromColumn(dataTable, PhoneNumber1Caption, row),
                PhoneNumber2 = GetValueFromColumn(dataTable, PhoneNumber2Caption, row),
                Address = adress
            };

            return person;
        }
    }
}
