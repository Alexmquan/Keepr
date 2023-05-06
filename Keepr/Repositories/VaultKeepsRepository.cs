namespace Keepr.Repositories;
public class VaultKeepsRepository
{
  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal VaultKeep AddVaultKeep(VaultKeep vaultKeepData)
  {
    string sql = @"
    INSERT INTO
    vaultKeeps(creatorId, vaultId, keepId)
    Values
    (@CreatorId, @VaultId, @KeepId);
    SELECT
    LAST_INSERT_ID()
    ;";
    int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
    vaultKeepData.Id = id;
    return vaultKeepData;
  }

  internal VaultKeep GetOne(int id)
  {
    string sql = @"
    SELECT
    *
    FROM vaultKeeps 
    WHERE id = @id
    ;";

    VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { id }).FirstOrDefault();
    return vaultKeep;
  }

  internal int RemoveVaultKeep(int id)
  {
    string sql = @"
    DELETE FROM
    vaultKeeps
    WHERE id = @id
    ;";
    int rowsAffected = _db.Execute(sql, new { id });
    return rowsAffected;
  }
}