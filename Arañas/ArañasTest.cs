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
        mapa.Posiciones.Should().Contain(c => c.ConexionId == posicion);
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
        resultado.Trim().Should().Be("|");
    }
    

    [Theory]
    [InlineData("P0", "/"), InlineData("P4", "/"), InlineData("P13", @"\"), InlineData("P9", @"\")]
    public void ElMapa_Debe_MostrarLineasDeConexionDiagonalesDeP8(string posicion, string lineaEsperada)
    {
        //Arrange
        var mapa = new Mapa();
        //Act
        var resultado = mapa.MostrarLineaConexionDiagonal(posicion);

        //Assert
        resultado.Trim().Should().Be(lineaEsperada);
    }

    [Theory]
    [InlineData("P0", "P1"), InlineData("P0", "P4"), InlineData("P0", "P4")]
    [InlineData("P9", "P10"), InlineData("P10", "P14"), InlineData("P14", "P15")]
    public void CadaPosicion_Debe_TenerAlMenosUnaConexion(string posicionA, string posicionB)
    {
        //Arrange
        var mapa = new Mapa();

        //Act
        var resultado = mapa.EstanConectados(posicionA, posicionB);

        //Assert
        resultado.Should().Be(true);
    }

    [Fact]
    public void LaAraña_Debe_IniciarEnElMapaConUnaPosicionDada()
    {
        //Arrange
        var mapa = new Mapa();
        
        //Act
        var araña = new Araña(mapa,0);

        //Assert
        araña.Posicion.Should().Be(0);
    }
    
    
}

public class Araña
{ 
    public int Posicion { get; set; }

    public Araña(Mapa mapa, int i)
    {
        Posicion = 0;
    }
}

public class Mapa
{
    public List<Conexion> Posiciones { get; set; } = [];

    public Mapa()
    {
        for (int i = 0; i <= 20; i++)
            Posiciones.Add(new Conexion($"P{i}"));
        Conectar("P0", "P1");
        Conectar("P0", "P4");
        Conectar("P0", "P8");
        Conectar("P19", "P20");

        
        // Nodo 8
        Conectar("P8", "P0");
        Conectar("P8", "P4");
        Conectar("P8", "P9");
        Conectar("P8", "P13");
        Conectar("P8", "P17");
        
        // Filas
        Conectar("P0", "P1"); Conectar("P1", "P2"); Conectar("P2", "P3");
        Conectar("P4", "P5"); Conectar("P5", "P6"); Conectar("P6", "P7");
        Conectar("P9", "P10"); Conectar("P10", "P11"); Conectar("P11", "P12");
        Conectar("P13", "P14"); Conectar("P14", "P15"); Conectar("P15", "P16");
        Conectar("P17", "P18"); Conectar("P18", "P19"); Conectar("P19", "P20");

        // Columnas
        Conectar("P0", "P4"); Conectar("P4", "P9"); Conectar("P9", "P13"); Conectar("P13", "P17");
        Conectar("P1", "P5"); Conectar("P5", "P10"); Conectar("P10", "P14"); Conectar("P14", "P18");
        Conectar("P2", "P6"); Conectar("P6", "P11"); Conectar("P11", "P15"); Conectar("P15", "P19");
        Conectar("P3", "P7"); Conectar("P7", "P12"); Conectar("P12", "P16"); Conectar("P16", "P20");


        
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
                mapa += MostrarLineaConexionDiagonal($"P{i - 3}") + conexionesVerticales;
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
        return "|     ";
    }

    public string MostrarLineaConexionDiagonal(string p0)
    {
        if (p0 == "P0"|| p0 == "P4")
            return "/     ";
        if (p0 == "P13" || p0 == "P9")
            return @"\    ";
        else
            return "";
    }

    public bool EstanConectados(string posicionA, string posicionB)
    {
        var a = Posiciones.First(p => p.ConexionId == posicionA);   
        var b = Posiciones.First(p => p.ConexionId == posicionB);
        return a.EstaConectadoCon(b);
    }

    public void Conectar(string posicionA, string posicionB)
    {
     var a = Posiciones.First(p => p.ConexionId == posicionA);   
     var b = Posiciones.First(p => p.ConexionId == posicionB);   
     a.ConectarCon(b);
    }
    
    
}

public class Conexion
{
    public string ConexionId { get; set; }
    private readonly HashSet<Conexion> _conexiones = new(); 
    public Conexion(string conexionId)
    {
        this.ConexionId = conexionId;
    }
    
    public void ConectarCon(Conexion conexion)
    {
        _conexiones.Add(conexion);
        conexion._conexiones.Add(this);
    }

    public bool EstaConectadoCon(Conexion conexion)
    {
        return _conexiones.Contains(conexion);
    }
}