using MediatR;

namespace PrimeEngineeringApi.Handlers.Employees.AddContributor
{
    public class AddContributorQuery : IRequest<AddContributorQueryResponse>
    {
        public int TaskId { get; set; }
        public int NewContributorId { get; set; }
    }
}
