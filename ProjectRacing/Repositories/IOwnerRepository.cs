using ProjectRacing.Entities;
namespace ProjectRacing.Repositories;
public interface IOwnerRepository
{
    IEnumerable<Owner> GetOwners();
    Owner GetOwnerById(int id);
    void CreateOwner(Owner owner);
    void UpdateOwner(Owner owner);
    void DeleteOwner(int id);
}