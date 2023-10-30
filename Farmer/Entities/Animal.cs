namespace Farmer.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int LiveTime { get; set; }
        public int EatLevel { get; set; }
        public int DeadTime { get; set; }
        public bool GiveEgg { get; set; }
        public bool GiveMilk { get; set; }
        public string AnimalType { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }



    }
}
