namespace Keepr.Services;
public class KeepsService
{
  private readonly KeepsRepository _repo;

  public KeepsService(KeepsRepository repo)
  {
    _repo = repo;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    int id = _repo.CreateKeep(keepData);
    keepData.Id = id;
    return keepData;
  }

  internal Keep EditKeep(Keep keepData, int keepId)
  {
    Keep originalKeep = this.GetOne(keepId);

    originalKeep.Name = keepData.Name ?? originalKeep.Name;
    originalKeep.Description = keepData.Description ?? originalKeep.Description;
    originalKeep.Img = keepData.Img ?? originalKeep.Img;

    _repo.EditKeep(originalKeep);
    originalKeep.UpdatedAt = DateTime.Now;
    return originalKeep;

  }

  internal List<Keep> GetKeeps()
  {
    List<Keep> keeps = _repo.GetAllKeeps();
    return keeps;
  }

  internal List<Keep> GetKeeps(string search)
  {
    List<Keep> keeps = _repo.GetAllKeeps(search);
    return keeps;
  }

  internal List<Keep> GetKeepsByProfileId(string profileId)
  {
    List<Keep> keeps = _repo.GetKeepsByProfileId(profileId);
    return keeps;
  }

  internal Keep GetOne(int keepId)
  {
    Keep keep = _repo.GetOne(keepId);
    // NOTE May not need this but using based on instaCult ref.
    keep.Views++;
    _repo.Edit(keep);

    if (keep == null)
    {
      throw new Exception("That Keep does not exist");
    }
    return keep;
  }

  internal List<VaultedKeep> GetVaultKeeps(int vaultId)
  {
    List<VaultedKeep> keeps = _repo.GetVaultKeeps(vaultId);
    if (keeps == null)
    {
      throw new Exception("That keep does not exist");
    }
    return keeps;
  }

  internal string RemoveKeep(int keepId, string userId)
  {
    Keep keep = this.GetOne(keepId);

    if (keep.CreatorId != userId)
    {
      throw new Exception("Something went wrong.");
    }

    int rowsAffected = _repo.RemoveKeep(keepId);

    if (rowsAffected == 0)
    {
      throw new Exception("Delete Failed");
    }

    return $"Your keep {keep.Name} has been deleted.";
  }
}