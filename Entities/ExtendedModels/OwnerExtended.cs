using System;
using System.Collections.Generic;
using Entities.Models;

namespace Entities.ExtendedModels
{
    public class OwnerExtended : Owner
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public IEnumerable<Account> Accounts { get; set; }

        public OwnerExtended()
        {
        }

        public OwnerExtended(Owner owner)
        {
            Id = owner.Id;
            Name = owner.Name;
            DateOfBirth = owner.DateOfBirth;
            Address = owner.Address;
        }
    }
}