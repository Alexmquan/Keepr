namespace Keepr.Services;
public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repo;

  public VaultKeepsService(VaultKeepsRepository repo)
  {
    _repo = repo;
  }
}