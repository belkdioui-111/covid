using covid_console.persistence;
using System;
using System.Collections.Generic;

namespace covid_console
{
    class Program
    {
        static void Main(string[] args)
        {

            CitoyenPersistence citoyenPersistence = new CitoyenPersistence();
         
            citoyenPersistence.addCitoyen(new Citoyen("cd84847473", "badre","elkdi",58,"saada",212052,DateTime.Now)) ;

            List<Citoyen> citoyens = citoyenPersistence.getAllCitoyens();
            foreach (Citoyen c in citoyens)
            {
                Console.WriteLine(c.Cin);
            }
        }
    }
}
