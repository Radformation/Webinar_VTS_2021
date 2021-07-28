namespace WrapperExample.TpsService
{
    public class Plan
    {
        public string Id { get; set; }
        public int Fractions { get; set; }
        public double DosePerFractionGy { get; set; }
        public double TotalDoseGy => DosePerFractionGy * Fractions;
    }
}