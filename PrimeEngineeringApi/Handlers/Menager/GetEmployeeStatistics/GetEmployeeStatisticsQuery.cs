﻿using MediatR;
using PrimeEngineeringApi.Data;

namespace PrimeEngineeringApi.Handlers.Menager.GetEmployeeStatistics
{
    public class GetEmployeeStatisticsQuery : IRequest<GetEmployeeStatisticsQueryResponse>
    {
        public int EmployeeId { get; set; }
    }
}
