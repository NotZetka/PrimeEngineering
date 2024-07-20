using MediatR;

namespace PrimeEngineeringApi.Handlers.Employees.GetNoContributorsforTask
{
    public class GetNoContributorsforTaskQuery : IRequest<GetNoContributorsforTaskQueryResponse>
    {
        public int TaskId { get; set; }
    }
}
