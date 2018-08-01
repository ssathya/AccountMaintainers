using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Repository;
using Entities;
using Entities.ExtendedModels;
using Entities.Extensions;
using Entities.Models;

namespace Repository
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Repository.RepositoryBase{Entities.Models.Owner}" />
    /// <seealso cref="Contracts.Repository.IOwnerRepository" />
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        /// <summary>
        /// Gets all owners.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll()
                .OrderBy(o => o.Name);
        }

        /// <summary>
        /// Gets an owner by identifier.
        /// </summary>
        /// <param name="ownerId">The owner identifier.</param>
        /// <returns></returns>
        public Owner GetOwnerById(Guid ownerId)
        {
            return Find(o => o.Id.Equals(ownerId));
        }

        /// <summary>
        /// Gets an owner with details.
        /// </summary>
        /// <param name="ownerId">The owner identifier.</param>
        /// <returns></returns>
        public OwnerExtended GetOwnerWithDetails(Guid ownerId)
        {
            return new OwnerExtended(GetOwnerById(ownerId))
            {
                Accounts = RepositoryContext.Accounts
                    .Where(a => a.OwnerId == ownerId)
            };
        }

        /// <summary>
        /// Creates an owner.
        /// </summary>
        /// <param name="newOwner">The new owner.</param>
        public void CreateOwner(Owner newOwner)
        {
            newOwner.Id = new Guid();
            Create(newOwner);
            Save();
        }

        /// <summary>
        /// Updates an owner.
        /// </summary>
        /// <param name="dbOwner">The database owner.</param>
        /// <param name="owner">The owner.</param>
        public void UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Map(owner);
            Update(dbOwner);
            Save();
        }

        /// <summary>
        /// Deletes an owner.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public void DeleteOwner(Owner owner)
        {
            Delete(owner);
            Save();
        }
    }
}