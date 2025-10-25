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
    
    
    [Theory]
    [InlineData("P0"), InlineData("P1"), InlineData("P2")]
    [InlineData("P5"), InlineData("P10"), InlineData("P15"), InlineData("P20")]
    public void ElMapa_Debe_ContenerVeintiunaPosicionesDesdeElCeroAlVeinteIdentificadasConLaLetraPYElNumeroEnteroCorrespondiente(string posicion)
    {
        //Arrange
        var mapa = new Mapa();
        
        //Assert
        mapa.Posiciones.Should().Contain(posicion);
    }

    [Fact]
    public void ElMapa_Debe_MostrarP0()
    {
        //Arrange
        var mapa = new Mapa();
        
        //Act
        var resultado = mapa.Mostrar();
        
        //Assert
        resultado.Should().Contain("P0");
    }
    
    [Fact]
    public void ElMapa_Debe_MostrarP1()
    {
        //Arrange
        var mapa = new Mapa();
        
        //Act
        var resultado = mapa.Mostrar();
        
        //Assert
        resultado.Should().Contain("P1");
    }
} 

public class Mapa
{
    public List<string> Posiciones { get; set; } = [];

    public Mapa()
    {
        for (int i = 0; i <= 20; i++)
        {
            Posiciones.Add($"P{i}");
        }
    }

    public string Mostrar()
    {
        return "P0";
    }
}