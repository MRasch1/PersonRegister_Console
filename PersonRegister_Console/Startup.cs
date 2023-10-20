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
            Console.WriteLine("Registrer en person");
            OpdaterPerson();
            Console.ReadKey();
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
        }

        public void OpdaterPerson()
        {
            Console.Write("Vælg ID på person du vil ændre på: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Skriv venligst nyt fornavn: ");
            string nytFornavn = Console.ReadLine();
            Console.Write("Skriv venligst nyt efternavn: ");
            string nytEfternavn = Console.ReadLine();
            Console.Write("Skriv ny Fødselsdato med følgende format DD-MM-YYYY: ");
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
    }
}
