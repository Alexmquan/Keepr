namespace Keepr.Models;

public class Keep : RepoItem<int>
{
  public string CreatorId { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public int Views { get; set; } = 0;
  public int Kept { get; set; } = 0;
  public Profile Creator { get; set; }
}