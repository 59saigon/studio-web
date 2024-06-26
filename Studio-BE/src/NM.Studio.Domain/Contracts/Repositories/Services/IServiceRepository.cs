﻿using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.CQRS.Queries.Services;
using NM.Studio.Domain.Entities.Services;

namespace NM.Studio.Domain.Contracts.Repositories.Services
{
    public interface IServiceRepository : IBaseRepository
    {
        Task<IList<Service>> GetAllWithInclude(ServiceGetAllQuery query, CancellationToken cancellationToken = default);
    }
}
