using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts.Repository
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        IEnumerable<Account> AccountsByOwner(Guid ownerId);
    }
}