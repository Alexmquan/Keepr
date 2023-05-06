namespace Keepr.Services;
public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repo;

  public VaultKeepsService(VaultKeepsRepository repo)
  {
    _repo = repo;
  }

  internal VaultKeep AddVaultKeep(VaultKeep vaultKeepData)
  {
    VaultKeep vaultKeep = _repo.AddVaultKeep(vaultKeepData);
    return vaultKeep;
  }
}