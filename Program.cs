using System;
using System.Linq;
using Miapp;



var libros = Book.Books();
var autores = Author.Authors();


// mostrar por consola los 3 libros con mas ventas  

Console.WriteLine("Los top 3 libros con ventas");
var top3 = libros.OrderByDescending(l => l.Sales).Take(3);
foreach (var l in top3)
    Console.WriteLine($"{l.Title} - {l.Sales} millones");
Separador();


void Separador()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--------------------------");
    Console.ResetColor();
}


//mostrar por consola los 3 libros con menos ventas

var menosVendidos = libros.OrderBy(l => l.Sales).Take(3);
foreach (var l in menosVendidos)
    Console.WriteLine($"{l.Title} - {l.Sales} millones");
Separador();

/*
 Auhtor con mas publicaciones 
 Agrupar los libros por su authorid
 */

var autortop = libros
    .GroupBy(l => l.AuthorId) // agrupar por autor
    .OrderByDescending(g => g.Count()) // ordena segun la cantidad de libros por author
    .Join(autores,  //unidos por la lista de autores
    g => g.Key,     //del grupo de libros usa el key de author id
    a => a.AuthorId, //deñ autor usa su author
    (g, a) => new {  //nombre del autor 
        a.Name,     //nombre del autor
        Cantidad = g.Count()    //cantidad de libros publicados 
    })

.First();


Console.WriteLine($"{autortop.Name} - {autortop.Cantidad}Libros");

//Libros hacemnos de 50 años publicados

Console.WriteLine("Libros publicados hace menos de 50 años");

int anioActual = DateTime.Now.Year;
var recientes = libros.Where(l => (anioActual - l.PublicDate) < 50);
foreach (var l in recientes)
    Console.WriteLine($"{l.Title} - {l.PublicDate}");

Separador();

// libros que comience con "EL"

Console.WriteLine("Libros que comienza con El");

var autoresConEl = libros
    .Where(l => l.Title.StartsWith("El"))
    .Join(autores,
    l => l.AuthorId,
    a => a.AuthorId,
    (l, a) => a.Name)
    .Distinct();

foreach (var nombre in autoresConEl)
    Console.WriteLine(nombre);
Separador();