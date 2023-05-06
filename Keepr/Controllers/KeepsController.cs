namespace Keepr.Controllers;
[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth;

  public KeepsController(KeepsService keepsService, Auth0Provider auth)
  {
    _keepsService = keepsService;
    _auth = auth;
  }

  [HttpPost]
  [Authorize]

  public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      keepData.CreatorId = userInfo.Id;
      Keep keep = _keepsService.CreateKeep(keepData);
      keep.Creator = userInfo;
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Keep>> GetKeeps(string search)
  {
    try
    {
      List<Keep> keeps;
      if (search == null)
      {
        keeps = _keepsService.GetKeeps();
      }
      else
      {
        keeps = _keepsService.GetKeeps(search);
      }
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{keepId}")]
  public ActionResult<Keep> GetOneKeep(int keepId)
  {
    try
    {
      Keep keep = _keepsService.GetOne(keepId);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{keepId}")]
  [Authorize]

  public async Task<ActionResult<string>> RemoveKeep(int keepId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      string message = _keepsService.RemoveKeep(keepId, userInfo.Id);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{keepId}")]
  [Authorize]

  public async Task<ActionResult<Keep>> EditKeep([FromBody] Keep keepData, int keepId)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      keepData.Id = keepId;
      Keep keep = _keepsService.EditKeep(keepData, keepId, userInfo.Id);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}