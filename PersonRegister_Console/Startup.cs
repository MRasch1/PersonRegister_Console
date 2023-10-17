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
            OpretPerson();
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


    }
}
