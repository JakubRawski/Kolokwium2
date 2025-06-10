using System.Collections;

namespace WebApplication1.DTOs;

public class PlayerDto : IEnumerable
{
    public int PlayerId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime BirthDate { get; set; }
    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}