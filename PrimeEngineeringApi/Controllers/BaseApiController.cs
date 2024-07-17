﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PrimeEngineeringApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

    }
}
