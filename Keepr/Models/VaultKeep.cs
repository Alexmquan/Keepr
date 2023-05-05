namespace Keepr.Models;
public class VaultKeep : RepoItem<int>

{
  // FIXME may need to come back and fix this model
  public string CreatorId { get; set; }
  public int VaultId { get; set; }
  public int KeepId { get; set; }

}

public class VaultedKeep : Vault
{
  public int VaultKeepId { get; set; }
}

public class MyVaultedKeep : Keep
{
  public int VaultKeepId { get; set; }
}