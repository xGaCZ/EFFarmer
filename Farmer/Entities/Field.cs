namespace Farmer.Entities
{
    public class Field
    {
        public int Id { get; set; }
        public string FieldNumber { get; set; }
        public int Area { get; set; }
        public bool FieldHasWater { get; set;}
        public int FieldClass { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
