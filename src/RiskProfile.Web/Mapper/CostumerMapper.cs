using RiskProfile.Domain.Models;
using RiskProfile.Web.Message.Request;

namespace RiskProfile.Web.Mapper
{
    internal class CostumerMapper
    {
        internal static Customer Mapper(CalculateRiskProfileRequest request)
        {
            return new Customer(request.Age,
                                request.Dependents,
                                Mapper(request.House),
                                request.Income,
                                request.MaritalStatus,
                                request.RiskQuestions,
                                Mapper(request.Vehicle));
        }

        private static House Mapper(CalculateRiskProfileHouseRequest request)
        {
            if (request == null)
                return null;

            return new House(request.OwnershipStatus);
        }

        private static Vehicle Mapper(CalculateRiskProfileVehicleRequest request)
        {
            if (request == null)
                return null;

            return new Vehicle(request.Year);
        }
    }
}
