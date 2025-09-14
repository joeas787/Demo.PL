
namespace Demo.DAL.Entities
{
    public class Department : BaseEntities
    {
        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
       
    }
}
