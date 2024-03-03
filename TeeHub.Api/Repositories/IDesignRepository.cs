using TeeHub.Api.Models.Domain;
using System.Collections.Generic;

namespace TeeHub.Api.Repositories
{
    public interface IDesignRepository
    {
        Design GetDesignById(Guid id);
        IEnumerable<Design> GetAllDesigns();
        void AddDesign(Design design);
        void UpdateDesign(Design design);
        void DeleteDesign(Guid id);
    }
}
