namespace Keepr.Repositories;
public class KeepsRepository
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal void AddKeptToKeep(int keepId)
  {
    string sql = @"
    UPDATE keeps
    SET
    kept = kept + 1
    WHERE id = @KeepId
    ;";
    _db.Execute(sql, new { keepId });

  }

  internal int CreateKeep(Keep keepData)
  {
    string sql = @"
    INSERT INTO keeps
    (name, creatorId, description, img, views)
    VALUES
    (@Name, @CreatorId, @Description, @Img, @Views );
    SELECT LAST_INSERT_ID()
    ;";
    int id = _db.ExecuteScalar<int>(sql, keepData);
    return id;
  }

  // NOTE may need to come back and add more properties to edit
  internal void Edit(Keep keep)
  {
    string sql = @"
    UPDATE keeps
    SET
    name = @Name,
    views = @Views
    WHERE id = @Id
    ;";
    _db.Execute(sql, keep);
  }

  internal void EditKeep(Keep originalKeep)
  {
    string sql = @"
    UPDATE keeps
    SET
    name = @Name,
    description = @Description,
    img = @Img,
    kept = @Kept,
    views= @Views
    Where id = @Id
    ;";

    _db.Execute(sql, originalKeep);
  }

  internal List<Keep> GetAllKeeps()
  {
    string sql = @"
    SELECT
    k.*,
    creator.*
    FROM keeps k
    JOIN accounts creator ON k.creatorId = creator.Id
    ;";
    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;
    }).ToList();
    return keeps;
  }

  internal List<Keep> GetAllKeeps(string search)
  {
    search = '%' + search + '%';
    string sql = @"
    SELECT
    k.*,
    creator.*
    FROM keeps k
    JOIN accounts creator ON k.creatorId = creator.Id
    WHERE k.name = LIKE @search;
    ;";
    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;
    }, new { search }).ToList();
    return keeps;
  }

  internal List<Keep> GetKeepsByProfileId(string profileId)
  {
    string sql = @"
    SELECT
    k.*,
    profile.*
    FROM keeps k
    JOIN accounts profile ON k.creatorId = profile.id
    WHERE k.creatorId = @profileId 
    ;";

    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }, new { profileId }).ToList();
    return keeps;
  }

  internal Keep GetOne(int keepId)
  {
    string sql = @"
    SELECT
    k.*,
    creator.*
    FROM keeps k 
    JOIN accounts creator ON k.creatorId = creator.id
    WHERE k.id = @keepId
    ;";

    Keep keep = _db.Query<Keep, Profile, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;
    }, new { keepId }).FirstOrDefault();
    return keep;
  }

  internal List<VaultedKeep> GetVaultKeeps(int vaultId)
  {
    string sql = @"
    SELECT
    vk.id AS VaultKeepId,
    k.*,
    creator.*
    FROM vaultKeeps vk
    JOIN keeps k ON vk.keepId = k.id
    JOIN accounts creator ON k.creatorId = creator.id
    WHERE vaultId = @vaultId
    ;";
    List<VaultedKeep> vaultedKeeps = _db.Query<VaultedKeep, Profile, VaultedKeep>(sql, (vaultKeep, creator) =>
    {
      vaultKeep.Creator = creator;
      return vaultKeep;
    }, new { vaultId }).ToList();
    return vaultedKeeps;
  }

  internal int RemoveKeep(int keepId)
  {
    string sql = @"
    DELETE 
    FROM keeps
    WHERE id = @keepId
    LIMIT 1
    ;";
    int rowsAffected = _db.Execute(sql, new { keepId });
    return rowsAffected;
  }
}