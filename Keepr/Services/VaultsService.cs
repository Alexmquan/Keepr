namespace Keepr.Services;
public class VaultsService
{
  private readonly VaultsRepository _repo;
  private readonly KeepsService _keepsService;

  public VaultsService(VaultsRepository repo, KeepsService keepsService)
  {
    _repo = repo;
    _keepsService = keepsService;
  }

  internal Vault CreateVault(Vault vaultData)
  {
    int id = _repo.CreateVault(vaultData);
    vaultData.Id = id;
    return vaultData;
  }

  internal Vault EditVault(Vault vaultData, int vaultId)
  {
    Vault originalVault = this.GetOneVault(vaultId);

    originalVault.Name = vaultData.Name ?? originalVault.Name;
    originalVault.Description = vaultData.Description ?? originalVault.Description;
    originalVault.Img = vaultData.Img ?? originalVault.Img;
    originalVault.IsPrivate = vaultData.IsPrivate != null ? vaultData.IsPrivate : originalVault.IsPrivate;

    _repo.EditVault(originalVault);
    originalVault.UpdatedAt = DateTime.Now;
    return originalVault;

  }

  internal Vault GetOneVault(int vaultId)
  {
    Vault vault = _repo.GetOne(vaultId);
    if (vault == null)
    {
      throw new Exception("That Vault does not exist");
    }
    return vault;
  }

  internal List<VaultedKeep> GetVaultKeeps(int vaultId, string userId)
  {
    Vault vault = GetOneVault(vaultId);
    if (vault == null)
    {
      throw new Exception("Your Vault Id is invalid.");
    }

    List<VaultedKeep> keeps = _keepsService.GetVaultKeeps(vaultId);
    return keeps;
  }

  internal string RemoveVault(int vaultId, string userId)
  {
    Vault vault = this.GetOneVault(vaultId);

    if (vault == null)
    {
      throw new Exception("No vault with that Id");
    }

    if (vault.CreatorId != userId)
    {
      throw new Exception("Something went wrong");
    }

    int rowsAffected = _repo.RemoveVault(vaultId);

    if (rowsAffected == 0)
    {
      throw new Exception("Delete Failed");
    }

    return $"Your Vault {vault.Name} has been removed";
  }
}