using WrapperExample.TpsService;

namespace WrapperExample.TestData
{
    public class TestService : ITpsService
    {
        public Patient Patient { get; }

        public Plan Plan { get; }

        public TestService()
        {
            Patient = new Patient
            {
                Id = "123456789",
                FirstName = "Shannon",
                LastName = "Abbot"
            };

            Plan = new Plan
            {
                Id = "Plan",
                Fractions = 30,
                DosePerFractionGy = 2.0
            };
        }
    }
}
