namespace Farmer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cash { get; set; }
        public  List<Animal> Animals { get; set; } = new List<Animal>();
        public List<Field> Fields { get; set; } = new List<Field>();

    }
}
