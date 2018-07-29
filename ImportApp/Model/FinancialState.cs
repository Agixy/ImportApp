namespace ImportApp.Model
{
    class FinancialState
    {
        public int Id { get; set; }
        public decimal OutstandingLiabilites { get; set; }
        public decimal Interests { get; set; } 
        public decimal PenaltyInterests { get; set; }
        public decimal Fees { get; set; }
        public decimal CourtFees { get; set; } 
        public decimal RepresentationCourtFees { get; set; }
        public decimal VindicationCosts { get; set; } 
        public decimal RepresentationVindicationCosts { get; set; } 
        public decimal Capital { get; set; }
    }
}
