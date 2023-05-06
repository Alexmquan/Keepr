namespace Keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController
{
  private readonly ProfilesService _profilesService;
  private readonly Auth0Provider _auth;


  public ProfilesController(ProfilesService profilesService, Auth0Provider auth)
  {
    _profilesService = profilesService;
    _auth = auth;
  }

  [HttpGet("{profileId}")]
  [Authorize]

  public Task<ActionResult<Profile>> Get()
  {
    try
    {

    }
    catch (Exception e)
    {
      return Task.FromResult<ActionResult<Profile>>(BadRequest(e.Message));
    }
  }

}