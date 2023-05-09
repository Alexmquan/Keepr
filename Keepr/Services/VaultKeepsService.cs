namespace Keepr.Services;
public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repo;
  private readonly VaultsService _vaultsService;
  private readonly KeepsService _keepsService;

  public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService, KeepsService keepsService)
  {
    _repo = repo;
    _vaultsService = vaultsService;
    _keepsService = keepsService;
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
    Vault vault = _vaultsService.GetOneVault(vaultKeepData.VaultId, vaultKeepData.CreatorId);
    // Keep keep = _keepsService.GetOne(vaultKeepData.KeepId);
    // keep.Kept++;
    // _keepsService.EditKeep(keep, keep.Id, keep.CreatorId);

    if (vault.CreatorId != vaultKeepData.CreatorId)
    {
      throw new Exception("You cannot create this vault");
    }
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

  internal List<VaultKeep> GetAccountVaultKeeps(string id)
  {
    List<VaultKeep> vaultKeeps = _repo.GetAccountVaultKeeps(id);
    return vaultKeeps;
  }
}