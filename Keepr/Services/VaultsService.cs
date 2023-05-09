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

  internal Vault EditVault(Vault vaultData, int vaultId, string userId)
  {
    Vault originalVault = this.GetOneVault(vaultId, userId);

    if (originalVault.CreatorId != userId)
    {
      throw new Exception("You're trying to edit that which does not belong to you");
    }

    originalVault.Name = vaultData.Name ?? originalVault.Name;
    originalVault.Description = vaultData.Description ?? originalVault.Description;
    originalVault.Img = vaultData.Img ?? originalVault.Img;
    originalVault.IsPrivate = vaultData.IsPrivate != null ? vaultData.IsPrivate : originalVault.IsPrivate;

    _repo.EditVault(originalVault);
    originalVault.UpdatedAt = DateTime.Now;
    return originalVault;

  }

  internal List<Vault> GetAccountVaults(string id)
  {
    List<Vault> vaults = _repo.GetAccountVaults(id);
    // if (vaults == null)
    // {
    //   throw new Exception("You do not have any Vaults");
    // }
    return vaults;
  }

  internal Vault GetOneVault(int vaultId, string userId)
  {
    Vault vault = _repo.GetOne(vaultId);
    if (vault == null)
    {
      throw new Exception("That Vault does not exist");
    }

    if (vault.IsPrivate == true && vault.CreatorId != userId)
    {
      throw new Exception("This Vault is locked doooown");
    }
    return vault;
  }

  internal List<VaultedKeep> GetVaultKeeps(int vaultId, string userId)
  {
    Vault vault = GetOneVault(vaultId, userId);

    List<VaultedKeep> keeps = _keepsService.GetVaultKeeps(vaultId);

    return keeps;
  }

  internal List<Vault> GetVaultsByProfileId(string profileId)
  {
    List<Vault> vaults = _repo.GetVaultsByProfileId(profileId);
    List<Vault> noPrivate = vaults.FindAll(v => v.IsPrivate == false);
    return noPrivate;
  }

  internal string RemoveVault(int vaultId, string userId)
  {
    Vault vault = this.GetOneVault(vaultId, userId);

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