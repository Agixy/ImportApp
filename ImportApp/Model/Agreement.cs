namespace ImportApp.Model
{
    class Agreement
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public Person Person { get; set; }
        public FinancialState FinancialState { get; set; }
    }
}
