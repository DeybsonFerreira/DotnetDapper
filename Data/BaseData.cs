using System.ComponentModel.DataAnnotations;

public abstract class BaseData
{
    [Key]
    public int Id { get; set; }
}