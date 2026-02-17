
using POO;

Console.WriteLine("proyecto 1");


List<Docente> listadoDocentes = new List<Docente>();

Docente docenteJulianEsteban = new Docente();

docenteJulianEsteban.IdPersona = 1;
docenteJulianEsteban.IdDocente = 1;
docenteJulianEsteban.Nombres = "Julian Esteban";
docenteJulianEsteban.Apellidos = "Alzate";
docenteJulianEsteban.CorreoElectronico = "julian.alzate@uco.edu.co";
docenteJulianEsteban.TipoContrato = "Tiempo Completo";
docenteJulianEsteban.Asignatura = "Programación Orientada a Objetos";
docenteJulianEsteban.Facultad = "Ingeniería";

Docente docenteMariaVictoria = new Docente()
{
    IdPersona = 2,
    IdDocente = 2,
    Nombres = "Maria Victoria",
    Apellidos = "Salazar",
    CorreoElectronico = "victoria.salazar@uco.edu.co",
    TipoContrato = "Tiempo completo",
    Asignatura = "Calculo",
    Facultad = "Ciencias Básicas"
};

Docente docentePatricia = new Docente()
{
    IdPersona = 3,
    IdDocente = 3,
    Nombres = "Patricia",
    Apellidos = "Hernandez",
    CorreoElectronico = "pat.hernandez@uco.edu.co",
    TipoContrato = "Medio tiempo",
    Asignatura = "Algebra lineal ",
    Facultad = "Ingeniería"
};

listadoDocentes.Add(docenteJulianEsteban);
listadoDocentes.Add(docenteMariaVictoria);
listadoDocentes.Add(docentePatricia);

var docentesIngenieria = listadoDocentes.Where(item => item.Facultad.Equals("Ingeniería"));

Console.WriteLine("Listado de todos los docentes: \n");
foreach (var item in listadoDocentes)
{
    Console.WriteLine(item.Nombres);
}

Console.WriteLine("Listado de docentes de Ingeniería: \n");
foreach (var item in docentesIngenieria)
{
    Console.WriteLine(item.Nombres);
}

Console.ReadLine();