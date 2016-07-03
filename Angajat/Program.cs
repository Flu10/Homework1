using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angajat
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberEmployee;
            string lastName,firstName;
            LeaveType vacation=LeaveType.Other;



            Console.WriteLine("Cate persoane doriti sa angajati ? ");
            numberEmployee=int.Parse(Console.ReadLine());

         
            Employee[] employee = new Employee[numberEmployee];

            for (int i=0;i<numberEmployee;i++)
            {  
                Console.WriteLine("Dati Last Name angajatului {0} :",i);
                lastName= Console.ReadLine();


                Console.WriteLine("Dati First Name angajatului {0} :", i);
                firstName = Console.ReadLine();

              
                Console.WriteLine("Dati Salariul angajatului {0} :", i);
                int salary = int.Parse(Console.ReadLine());
               

                Console.WriteLine("Dati numarul de zile libere ale angajatului {0} :", i);
                int availableDaysOff = int.Parse(Console.ReadLine());
                //
                Console.WriteLine("Dati anul in care se face angajarea  angajatului {0} :", i);
                int anAngajare = int.Parse(Console.ReadLine());


                Console.WriteLine("Dati luna in care se face angajarea  angajatului {0} :", i);
                int lunaAngajare = int.Parse(Console.ReadLine());

                Console.WriteLine("Dati ziua in care se face angajarea  angajatului {0} :", i);
                int ziAngajare = int.Parse(Console.ReadLine());

                DateTime DateOfEmployment = new DateTime(anAngajare, lunaAngajare, ziAngajare);
                //
                Console.WriteLine("Dati anul in care s-a nascut angajatul {0} :", i);
                int anNastere = int.Parse(Console.ReadLine());


                Console.WriteLine("Dati luna in care s-a nascut angajatul{0} :", i);
                int lunaNastere = int.Parse(Console.ReadLine());

                Console.WriteLine("Dati ziua in care s-a nascut angajatul {0} :", i);
                int ziNastere = int.Parse(Console.ReadLine());

                DateTime DateOfBirth = new DateTime(anNastere, lunaNastere, ziNastere);

                //


                employee[i] = new Employee(lastName,firstName,DateOfBirth,DateOfEmployment,salary,availableDaysOff);
                //
                Console.WriteLine("Afisare:");
                employee[i].DisplayInfo();//Afisare informatii angajat.

                int numarConcedii = 2;//Posibilitatea de a oferi 2 concedii fiecarui angajat.
                while(numarConcedii>0)
                {
                    numarConcedii--;
                    Console.WriteLine("Adaugare concediu angajatului {0}", i);

                    Console.WriteLine("Dati anul in care se da concediul angajatului{0} :", i);
                    int anConcediu = int.Parse(Console.ReadLine());


                    Console.WriteLine("Dati luna in care se da concediul angajatului {0} :", i);
                    int lunaConcediu = int.Parse(Console.ReadLine());

                    Console.WriteLine("Dati ziua in care se da concediul angajatului {0} :", i);
                    int ziConcediu = int.Parse(Console.ReadLine());

                    DateTime startingDate = new DateTime(anConcediu, lunaConcediu, ziConcediu);

                    Console.WriteLine("Dati durata concediului angajatului {0}:", i);
                    int duration = int.Parse(Console.ReadLine());

                    Console.WriteLine("Dati tipul concediului angajatului {0}// Medical=0, Holiday=1, Other=2:", i);
                    int tipe = int.Parse(Console.ReadLine());

                    if (tipe == 0)
                    {
                        vacation = LeaveType.Medical;
                    }
                    if (tipe == 1)
                    {
                        vacation = LeaveType.Holiday;
                    }
                    if (tipe == 2)
                    {
                        vacation = LeaveType.Other;
                    }

                    employee[i].AddNewLeave(startingDate, duration, vacation);//adaugare concediu 

                }


                employee[i].LeaveDisplayInfo();//Afisare informatii concedii 2016
                employee[i].DisplayInfo();// Afisare informatii angajat, pentru a se observa ca metoda SubstractDays functioneaza
                Console.Read();
                
            }
            

        }
    }
}
