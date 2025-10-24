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
    public List<int> Posiciones { get; set; }
}