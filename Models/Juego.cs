namespace TP5_Hevia_Ku.Models;
class Juego {
   public List<Sala> salas { get; set; } 
   public Juego()
   {
    salas = new List<Sala>()
            Rooms.Add(new Room { Id = 1, IsUnlocked = true });
            Rooms.Add(new Room { Id = 2, IsUnlocked = false });
            Rooms.Add(new Room { Id = 3, IsUnlocked = false });
            Rooms.Add(new Room { Id = 4,  IsUnlocked = false });
   }

}