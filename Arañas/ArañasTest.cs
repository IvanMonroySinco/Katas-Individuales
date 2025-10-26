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
    
    [Theory]
    [InlineData("P0"), InlineData("P1"), InlineData("P2")]
    [InlineData("P5"), InlineData("P10"), InlineData("P15"), InlineData("P20")]
    public void ElMapa_Debe_MostrarLasVeintiunaPosicionesIdentificadaConLaLetraPYElNumeroEnteroCorrespondiente(string posicion)
    {
        //Arrange
        var mapa = new Mapa();
        
        //Act
        var resultado = mapa.Mostrar();
        
        //Assert
        resultado.Should().Contain(posicion); 
    }
    

    [Theory]
    [InlineData("P0 ── P1"), InlineData("P1 ── P2"), InlineData("P6 ── P7")]
    [InlineData("P9 ── P10"), InlineData("P11 ── P12"), InlineData("P17 ── P18")]
    
    public void ElMapa_Debe_MostrarConUnaLineaHorizontalLasConexionesHorizontales(string conexion)
    {
        //Arrange
        var mapa = new Mapa();
        //Act
        var resultado = mapa.Mostrar();
        
        //Assert
        resultado.Should().Contain(conexion); 
    }
    
    [Fact]
    public void PosicionP3_NoDebe_MostrarPosicionesASuDerecha()
    {
        //Arrange
        var mapa = new Mapa();
        //Act
        var resultado = mapa.Mostrar();
        
        //Assert
        resultado.Should().NotContain("P3 ── P"); 
    }

    [Fact]
    public void PosicionP7_NoDebe_MostrarPosicionesASuDerecha()
    {
        //Arrange
        var mapa = new Mapa();
        //Act
        var resultado = mapa.Mostrar();
        
        //Assert
        resultado.Should().NotContain("P7 ── P"); 
    }
    
    [Fact]
    public void PosicionP16_NoDebe_MostrarPosicionesASuDerecha()
    {
        //Arrange
        var mapa = new Mapa();
        //Act
        var resultado = mapa.Mostrar();
        
        //Assert
        resultado.Should().NotContain("P16 ── P"); 
    }
    
} 

public class Mapa
{
    public List<string> Posiciones { get; set; } = [];

    public Mapa()
    {
        for (int i = 0; i <= 20; i++)
            Posiciones.Add($"P{i}");
    }

    public string Mostrar()
    {
        string mapa = "";

        for (int i = 0; i <= 20; i++)
        {
            mapa += $"P{i} ── ";
            if (i == 3 || i == 7)
            {
                mapa += @"
";
            }
        }
           
        
        return mapa;
    }
}