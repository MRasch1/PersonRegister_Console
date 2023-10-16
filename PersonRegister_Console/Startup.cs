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

            Console.ReadKey();

        }


        public void OpretPerson(string fornavn, string efternavn, DateTime fødselsdato)
        {
            Console.Write("Skriv venligst fornavn: ");
            fornavn = Console.ReadLine();
            Console.Write("Skriv venligst efternavn: ");
            efternavn = Console.ReadLine();
            Console.Write("Skriv Fødselsdato med følgende format DD-MM-YYYY: ");
            fødselsdato = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine(fornavn + " " + efternavn + " " + fødselsdato.ToShortDateString());
        }


    }
}
