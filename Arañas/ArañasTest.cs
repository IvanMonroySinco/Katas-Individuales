using System.Runtime.InteropServices;
using FluentAssertions;

namespace Arañas;

public class ArañasTest
{
    [Fact]
    public void ElMapa_Debe_TenerVeintiunaPosiciones() 
    {
        //Arrange
        var mapa = new Mapa();
        
        //Assert
        mapa.Posiciones.Count.Should().Be(21);
    }
    
} 

public class Mapa
{
    public List<int> Posiciones { get; set; } = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20];
}