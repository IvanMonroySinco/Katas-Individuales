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

    [Theory]
    [InlineData("P8"), InlineData("P17"), InlineData("P18"), InlineData("P19"), InlineData("P20")]
    public void ElMapa_NoDebe_MostrarLineaDeConexionVerticalSiNoExisteConexion(string posicion)
    {
        //Arrange
        var mapa = new Mapa();
        //Act
        var resultado = mapa.MostrarLineaConexionVertical(posicion);

        //Assert
        resultado.Should().Be("");
    }


    [Theory]
    [InlineData("P0"), InlineData("P4"), InlineData("P9")]
    public void ElMapa_Debe_MostrarConUnaLineaVerticalLasConexionesVerticalesHaciaAbajo(string posicion)
    {
        //Arrange
        var mapa = new Mapa();
        //Act
        var resultado = mapa.MostrarLineaConexionVertical(posicion);

        //Assert
        resultado.Should().Be("|");
    }

    [Fact]
    public void ElMapa_Debe_MostrarConUnaLineaDiagonalHaciaArribaLaConexionEntreP8YP0()
    {
        //Arrange
        var mapa = new Mapa();
        //Act
        var resultado = mapa.MostrarLineaConexionDiagonal("P0");

        //Assert
        resultado.Should().Be("/");
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
        string conexionesVerticales = "";


        for (int i = 0; i <= 20; i++)
        {
            var posicion = $"P{i}";
            conexionesVerticales += MostrarLineaConexionVertical(posicion);
            mapa += posicion;
            if (i == 3 || i == 7 || i == 16 || i == 12 || i == 20)
            {
                mapa += Environment.NewLine;
                mapa += conexionesVerticales;
                mapa += Environment.NewLine;
                conexionesVerticales = "";
            }
            else
                mapa += " ── ";
        }

        return mapa;
    }


    public string MostrarLineaConexionVertical(string posicion)
    {
        if (posicion == "P8" || posicion == "P17" || posicion == "P18" || posicion == "P19" || posicion == "P20")
            return "";
        return "|";
    }

    public object MostrarLineaConexionDiagonal(string p0)
    {
        throw new NotImplementedException();
    }
}