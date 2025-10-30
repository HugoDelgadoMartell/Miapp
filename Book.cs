using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miapp
{
    public class Book
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublicDate { get; set; }
        public int Sales { get; set; }

        public Book(string title, int authorId, int publicDate, int sales)
        {
            Title = title;
            AuthorId = authorId;
            PublicDate = publicDate;
            Sales = sales;


        }


        public static List<Book> Books()
        {
            return new List<Book>
            {
                new Book("Don quijote de la mancha",1,1605,500),
                new Book("Historia de dos ciudades",2,1850,200),
                new Book("El señor de los anillos",3,1978,150),
                new Book("El principito",4,1951,140),
                new Book("El hobbit",5,1982,100),
                new Book("Paco Yunque",6,1945,120),
                new Book("El león, la bruja y el armario",7,1950,85),
                new Book("El codigo da vinci",8,2003,80),
                new Book("El alquimista",9,1988,65),
                new Book("Movy Dick",10,1939,100)

            };

        }

    }

}





