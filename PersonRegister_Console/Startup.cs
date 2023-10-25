using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegister_Console
{
    internal class Startup
    {
        RepoDB repoDB = new RepoDB();

        public Startup()
        {
            Menu();
        }

        public void Menu()
        {
            int menuIndtast;
            do
            {

                Console.WriteLine("Menu");
                Console.WriteLine("Tast 1. for at oprette en person.");
                Console.WriteLine("Tast 2. for at opdatere en person.");
                Console.WriteLine("Tast 3. for at slette en person.");
                Console.WriteLine("Tast 0. for at lukke programmet.");

                while (!int.TryParse(Console.ReadLine(), out menuIndtast) || menuIndtast > 3 || menuIndtast < 0) ;

                if (menuIndtast == 1)
                {
                    OpretPerson();
                }

                else if (menuIndtast == 2)
                {
                    OpdaterPerson();
                }

                else if (menuIndtast == 3)
                {
                    SletPerson();
                }

                else if (menuIndtast == 0) { }

                Console.ReadKey();
                Console.Clear();
            } while (menuIndtast != 0);
        }

        public void OpretPerson()
        {
            DateTime fødselsdato;

            Console.Write("Skriv venligst fornavn: ");
            string fornavn = Console.ReadLine();
            Console.Write("Skriv venligst efternavn: ");
            string efternavn = Console.ReadLine();
            Console.Write("Skriv Fødselsdato med følgende format DD-MM-YYYY: ");
            while (!DateTime.TryParse(Console.ReadLine(), out fødselsdato))
            {
                Console.WriteLine("Indtast en gyldig fødselsdato: ");
            };
            repoDB.InsertPersonIRegister(fornavn, efternavn, fødselsdato);
            Console.WriteLine(fornavn + " " + efternavn + " " + fødselsdato.ToShortDateString());
            //Console.WriteLine("SELECT * FROM Person");
        }

        public void OpdaterPerson()
        {
            Console.Write("Vælg ID på person du vil ændre på: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Skriv venligst nyt fornavn eller efterlad felt blankt: ");
            string nytFornavn = Console.ReadLine();
            Console.Write("Skriv venligst nyt efternavn eller efterlad felt blankt: ");
            string nytEfternavn = Console.ReadLine();
            Console.Write("Skriv ny Fødselsdato med følgende format DD-MM-YYYY  eller efterlad felt blankt: ");
            repoDB.UpdatePersonIRegister(nytFornavn, nytEfternavn, IsItNullable(), id);
            //Console.WriteLine(nytFornavn + " " + nytEfternavn + " " + nyFødselsdato.ToShortDateString());
        }

        public DateTime? IsItNullable()
        {
            DateTime? nullableDateTime = null;
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (DateTime.TryParse(input, out DateTime parsedDateTime))
                {
                    nullableDateTime = parsedDateTime;
                    return nullableDateTime;
                }
                else
                {
                    Console.WriteLine("Indtast en gyldig fødselsdato: ");
                    return nullableDateTime;
                }
            }
            else
            {
                //Bruger har ikke indtastet noget, så nullableDateTime er null.
                return nullableDateTime;
            }
        }

        public void SletPerson()
        {
            int id;

            Console.WriteLine("Vælg ID på den person du gerne vil slette: ");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("indtast et gyldigt tal: ");
            }
            repoDB.DeletePersonIRegister(id);
        }
    }
}
