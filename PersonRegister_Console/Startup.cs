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
        public Startup()
        {
            Console.WriteLine("Registrer en person");
            Console.Write("Skriv venligst fornavn: ");
            string fornavn = Console.ReadLine();
            Console.Write("Skriv venligst efternavn: ");
            string efternavn = Console.ReadLine();
            Console.Write("Skriv Fødselsdato med følgende format DD-MM-YYYY: ");
            DateTime fødselsdato = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine(fornavn + " " + efternavn + " " + fødselsdato.Date.Year);
            Console.ReadKey();

        }

    }
}
