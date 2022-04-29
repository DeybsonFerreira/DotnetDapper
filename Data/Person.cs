using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Person")]
public class Person : BaseData
{
    public Person()
    {
        this.FirstName = string.Empty;
        this.LastName = string.Empty;
    }
    [Required]
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
