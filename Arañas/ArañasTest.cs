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

    [Fact]
    public void ElMapa_Debe_ContenerPosicionP0()
    {
        //Arrange
        var mapa = new Mapa();
        
        //Assert
        mapa.Posiciones.Should().Contain("P0");
    }
    
    [Fact]
    public void ElMapa_Debe_ContenerPosicionP1()
    {
        //Arrange
        var mapa = new Mapa();
        
        //Assert
        mapa.Posiciones.Should().Contain("P1");
    }
    
    [Fact]
    public void ElMapa_Debe_ContenerPosicionP2()
    {
        //Arrange
        var mapa = new Mapa();
        
        //Assert
        mapa.Posiciones.Should().Contain("P2");
    }
} 

public class Mapa
{
    public List<string> Posiciones { get; set; } = [];

    public Mapa()
    {
        Posiciones.Add("P0");
        Posiciones.Add("P1");
        Posiciones.Add("P2");
        
        for (int i = 0; i <= 17; i++)
        {
            Posiciones.Add(i.ToString());
        }
    }
}