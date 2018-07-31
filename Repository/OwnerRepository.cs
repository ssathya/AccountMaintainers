﻿using System.Collections.Generic;
using System.Linq;
using Contracts.Repository;
using Entities;
using Entities.Models;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll()
                .OrderBy(o => o.Name);
        }
    }
}