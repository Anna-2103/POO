using Fachada;
using System;

CineFacade cine = new CineFacade();

cine.VerPelicula();

Console.WriteLine("Presione una tecla para terminar...");
Console.ReadKey();

cine.TerminarPelicula();
