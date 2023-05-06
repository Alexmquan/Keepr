namespace Keepr.Repositories;
public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal int CreateVault(Vault vaultData)
  {
    string sql = @"
   INSERT INTO vaults
   (name, creatorId, description, img, isPrivate)
   VALUES
   (@Name, @CreatorId, @Description, @Img, @IsPrivate);
   SELECT LAST_INSERT_ID()
   ;";

    int id = _db.ExecuteScalar<int>(sql, vaultData);
    return id;
  }

  internal void EditVault(Vault originalVault)
  {
    string sql = @"
    UPDATE vaults
    SET
    name = @Name,
    description = @Description,
    img = @Img,
    isPrivate = @IsPrivate
    WHERE id = @Id
    ;";

    _db.Execute(sql, originalVault);
  }

  internal Vault GetOne(int vaultId)
  {
    string sql = @"
    SELECT
    v.*,
    creator.*
    FROM vaults v
    JOIN accounts creator ON v.creatorId = creator.id
    WHERE v.id = @vaultId
    ;";

    Vault vault = _db.Query<Vault, Profile, Vault>(sql, (vault, creator) =>
    {
      vault.Creator = creator;
      return vault;
    }, new { vaultId }).FirstOrDefault();
    return vault;
  }

  internal int RemoveVault(int vaultId)
  {
    string sql = @"
    DELETE
    FROM vaults
    WHERE id = @vaultId
    LIMIT 1
    ;";
    int rowsAffected = _db.Execute(sql, new { vaultId });
    return rowsAffected;
  }
}