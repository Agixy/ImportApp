using MySql.Data.MySqlClient;

namespace ImportApp
{
    class DatabaseCreator
    {
        private const string sqlCreateDatabase = "CREATE DATABASE IF NOT EXISTS `importapp` DEFAULT CHARACTER SET utf8 COLLATE utf8_polish_ci";
       
        public void CreateDatabase()
        {
            using (var connection = new MySqlConnection(Connections.ConnectionString))
            {
                connection.Open();
                MySqlCommand myCommand = new MySqlCommand(sqlCreateDatabase, connection);
                myCommand.ExecuteNonQuery();
            }
        }

        public void CreateTables()
        {
            CreateAdressTable();
            CreatePersonTable();
            CreateFinancialStateTable();
            CreateAgreementTable();
        }

        private void CreatePersonTable()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS `importapp`.`person` (
                `idPerson` INT NOT NULL AUTO_INCREMENT,
                `FirstName` VARCHAR(45) NULL,
                `SecondName` VARCHAR(45) NULL,
                `Surname` VARCHAR(45) NULL,
                `NationalIdentificationNumber` VARCHAR(45) NULL,
                `AddressId` INT NULL,
                `PhoneNumber` VARCHAR(45) NULL,
                `PhoneNumber2` VARCHAR(45) NULL,
                 PRIMARY KEY(`idPerson`),
                 INDEX `FK1_idx` (`AddressId` ASC) VISIBLE,
                 CONSTRAINT `Adress`
                 FOREIGN KEY(`AddressId`)
                 REFERENCES `importapp`.`adress` (`idAdress`)
                 ON DELETE NO ACTION
                 ON UPDATE NO ACTION)";

            using (var connection = new MySqlConnection(Connections.ConnectionString))
            {
                connection.Open();
                MySqlCommand myCommand = new MySqlCommand(sql, connection);
                myCommand.ExecuteNonQuery();
            }
        }

        private void CreateAdressTable()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS `importapp`.`adress` (
                `idAdress` INT NOT NULL AUTO_INCREMENT,
                `StreetName` VARCHAR(45) NULL,
                `StreetNumber` VARCHAR(45) NULL,
                `FlatNumber` VARCHAR(45) NULL,
                `PostCode` VARCHAR(45) NULL,
                `PostOfficeCity` VARCHAR(45) NULL,
                `CorrespondenceStreetName` VARCHAR(45) NULL,
                `CorrespondenceStreetnumber` VARCHAR(45) NULL,
                `CorrespondenceFlatNumber` VARCHAR(45) NULL,
                `CorrespondencePostCode` VARCHAR(45) NULL,
                `CorrespondencePostOfficeCity` VARCHAR(45) NULL,
                PRIMARY KEY(`idAdress`))
                ENGINE = InnoDB
                DEFAULT CHARACTER SET = utf8
                COLLATE = utf8_polish_ci";

            using (var connection = new MySqlConnection(Connections.ConnectionString))
            {
                connection.Open();
                MySqlCommand myCommand = new MySqlCommand(sql, connection);
                myCommand.ExecuteNonQuery();
            }
        }

        private void CreateAgreementTable()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS `importapp`.`agreement` (
                `idAgreement` INT NOT NULL AUTO_INCREMENT,
                `Number` VARCHAR(45) NULL,
                `PersonId` INT NULL,
                `FinancialStateId` INT NULL,
                PRIMARY KEY (`idAgreement`),
                INDEX `FK1_idx` (`PersonId` ASC) VISIBLE,
                INDEX `FK2_idx` (`FinancialStateId` ASC) VISIBLE,
                CONSTRAINT `Person`
                FOREIGN KEY (`PersonId`)
                REFERENCES `importapp`.`person` (`idPerson`)
                ON DELETE NO ACTION
                ON UPDATE NO ACTION,
                CONSTRAINT `FinancialState`
                FOREIGN KEY (`FinancialStateId`)
                REFERENCES `importapp`.`financialstate` (`idFinancialState`)
                ON DELETE NO ACTION
                ON UPDATE NO ACTION);";

            using (var connection = new MySqlConnection(Connections.ConnectionString))
            {
                connection.Open();
                MySqlCommand myCommand = new MySqlCommand(sql, connection);
                myCommand.ExecuteNonQuery();
            }
        }

        private void CreateFinancialStateTable()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS `importapp`.`financialstate` (
                `idFinancialState` INT NOT NULL AUTO_INCREMENT,
                `OutstandingLiabilites` DECIMAL(10,2) NULL,
                `Interests` DECIMAL(10,2) NULL,
                `PenaltyInterests` DECIMAL(10,2) NULL,
                `Fees` DECIMAL(10,2) NULL,
                `CourtFees` DECIMAL(10,2) NULL,
                `RepresentationCourtFees` DECIMAL(10,2) NULL,
                `VindicationCosts` DECIMAL(10,2) NULL,
                `RepresentationVindicationCosts` DECIMAL(10,2) NULL,
                PRIMARY KEY (`idFinancialState`));";

            using (var connection = new MySqlConnection(Connections.ConnectionString))
            {
                connection.Open();
                MySqlCommand myCommand = new MySqlCommand(sql, connection);
                myCommand.ExecuteNonQuery();
            }
        }
    }
}
