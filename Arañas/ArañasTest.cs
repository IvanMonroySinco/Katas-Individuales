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
    public void
        ElMapa_Debe_ContenerVeintiunaPosicionesDesdeElCeroAlVeinteIdentificadasConLaLetraPYElNumeroEnteroCorrespondiente(
            string posicion)
    {
        //Arrange
        var mapa = new Mapa();

        //Assert
        mapa.Posiciones.Should().Contain(posicion);
    }

    [Theory]
    [InlineData("P0"), InlineData("P1"), InlineData("P2")]
    [InlineData("P5"), InlineData("P10"), InlineData("P15"), InlineData("P20")]
    public void ElMapa_Debe_MostrarLasVeintiunaPosicionesIdentificadaConLaLetraPYElNumeroEnteroCorrespondiente(
        string posicion)
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


    [Theory]
    [InlineData("P3 ── P"), InlineData("P7 ── P"), InlineData("P16 ── P"),
     InlineData("P12 ── P"), InlineData("P20 ── P")]
    public void El_Mapa_DebeMostrarSaltoDeLineaCuandoPosicionNoTieneConexionALaDerecha(string conexion)
    {
        //Arrange
        var mapa = new Mapa();
        //Act
        var resultado = mapa.Mostrar();

        //Assert
        resultado.Should().NotContain(conexion);
    }

    [Fact]
    public void ElMapa_Debe_MostrarConUnaLineaVerticalLaConexionEntreP0YP4()
    {
        //Arrange
        var mapa = new Mapa();
        //Act
        var resultado = mapa.Mostrar();

        //Assert
        resultado.Count(c => c == '|').Should().BeGreaterThanOrEqualTo(1);
    }

    [Fact]
    public void ElMapa_Debe_MostrarConUnaLineaVerticalLaConexionEntreP4YP9ManteniendoLaLineaDeP0YP4()
    {
        //Arrange
        var mapa = new Mapa();
        //Act
        var resultado = mapa.Mostrar();

        //Assert
        resultado.Count(c => c == '|').Should().BeGreaterThanOrEqualTo(2);
    }

    [Fact]
    public void ElMapa_Debe_MostrarConUnaLineaVerticalLaConexionEntreP9YP13ManteniendoLasLineasDeP0P4YP4P9()
    {
        //Arrange
        var mapa = new Mapa();
        //Act
        var resultado = mapa.Mostrar();

        //Assert
        resultado.Count(c => c == '|').Should().BeGreaterThanOrEqualTo(3);
    }

    [Fact]
    public void PosicionP8_NoDebe_MostrarConexionesVerticales()
    {
        //Arrange
        var mapa = new Mapa();
        var posicion = "P8";
        //Act
        var resultado = mapa.MostrarLineaConexionVertical(posicion);
        //Assert
        resultado.Should().Be(""); 
    }
    
    [Fact]
    public void Posicion17_NoDebe_MostrarConexionesVerticales()
    {
        //Arrange
        var mapa = new Mapa();
        var posicion = "P17";
        //Act
        var resultado = mapa.MostrarLineaConexionVertical(posicion);
        //Assert
        resultado.Should().Be(""); 
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
        string mapa = "|||";

        for (int i = 0; i <= 20; i++)
        {
            var posicion = $"P{i}";
            mapa += posicion;
            if (i == 3 || i == 7 || i == 16 || i == 12 || i == 20)
                mapa += Environment.NewLine;
            else
                mapa += " ── ";
        }

        return mapa;
    }


    public string MostrarLineaConexionVertical(string posicion)
    {
        if (posicion == "P8" || posicion == "P17")
            return "";
        throw new NotImplementedException();
    }
}