namespace Keepr.Services;
public class VaultsService
{
  private readonly VaultsRepository _repo;

  public VaultsService(VaultsRepository repo)
  {
    _repo = repo;
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
    originalVault.IsPrivate = vaultData.IsPrivate ?? originalVault.IsPrivate;

    _repo.EditVault(originalVault);
    originalVault.UpdatedAt = DateTime.Now;
    return originalVault;

  }

  internal Vault GetOneVault(int vaultId)
  {
    Vault vault = _repo.GetOne(vaultId);
    return vault;
  }
}