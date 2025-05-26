namespace TP5_Hevia_Ku.Models;
class Juego {
    public string nombre {get; set;}
    public int codigoSala {get; set;}
    public Dictionary <int, int> salas {get; set;}
}