namespace Keepr.Services;
public class ProfilesService
{
  private readonly ProfilesRepository _repo;

  public ProfilesService(ProfilesRepository repo)
  {
    _repo = repo;
  }

  internal Profile GetProfileById(string profileId)
  {
    return _repo.GetProfileById(profileId);
  }
}