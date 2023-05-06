namespace Keepr.Services;
public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repo;

  public VaultKeepsService(VaultKeepsRepository repo)
  {
    _repo = repo;
  }

  internal VaultKeep GetOneVaultKeep(int vaultKeepId)
  {
    VaultKeep vaultKeep = _repo.GetOne(vaultKeepId);
    if (vaultKeep == null)
    {
      throw new Exception("That VaultKeep is no good.");
    }
    return vaultKeep;
  }

  internal VaultKeep AddVaultKeep(VaultKeep vaultKeepData)
  {
    VaultKeep vaultKeep = _repo.AddVaultKeep(vaultKeepData);
    return vaultKeep;
  }

  internal string RemoveVaultKeep(int vkId, string userId)
  {
    VaultKeep vaultKeep = this.GetOneVaultKeep(vkId);

    if (vaultKeep.CreatorId != userId)
    {
      throw new Exception("something went wrong");
    }

    int rowsAffected = _repo.RemoveVaultKeep(vkId);
    if (rowsAffected == 0)
    {
      throw new Exception("Delete Failed");
    }

    return $"Your vaultKeep has been removed";
  }
}