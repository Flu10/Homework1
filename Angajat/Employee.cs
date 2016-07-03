/*Pe Employee
- Un constructor in care trimteti toate campurile(Lastname, Firstname, DateOfBirth, DateOfEmployment ,
Salary , AvailableDaysOff)
-Afisare Nume, Prenume,Salariu, Numar zile disonibile(DisplayInfo)
-Scadere zile de concediu ale Employee(SubstractDays)-metoda ce nu poate fi accesata din exetriorul clasei
-Adaugare concediu nou. Se trimite un obiect de tipul Leave- trebuie sa scada si
numarul de zile totale ale angajatului(va apela metoda SubstractDays.
Se seteaza variabila Employee de pe Leave cu obiectul curent. ).(AddNewLeave)
Creare exceptie custom: NegativeLeaveDays. Se arunca exceptia nou creata daca 
numarul de zile luate la un concediu este mai mare decat numarul de zile totale ale angajatului.
Se Arunca exceptie in  metoda AddNewLeave cu mesajul “Numarul de zile ramase nu poate fi mai mare 
decat durata concediului”.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Angajat
{

    public class NegativeLeaveDays : Exception
    {
        public NegativeLeaveDays()
        {
        }

        /*  public NegativeLeaveDays(string message)
              : base(message)
          {
          }

          public NegativeLeaveDays(string message, Exception inner)
              : base(message, inner)
          {
          }
          */
    } //Creare Exceptie
    class Employee : Person
    {
        DateTime dateOfEmployment;
        int salary;
        int availableDaysOff;
        List<Leave> listLeave = new List<Leave>();
        //mostenire clasa Person
        public Employee()
        {

        }//constructor fara parametrii
        public Employee(string Lastname, string Firstname, DateTime DateOfBirth, DateTime DateOfEmployment, int Salary, int AvailableDaysOff)
        {
            lastName = Lastname;
            firstName = Firstname;
            dateOfBirth = DateOfBirth;
            dateOfEmployment = DateOfEmployment;
            salary = Salary;
            availableDaysOff = AvailableDaysOff;

        } //Constructor

        public void DisplayInfo()
        {
            Console.WriteLine("Last Name: " + lastName);
            Console.WriteLine("First Name: " + firstName);
            Console.WriteLine("Salary:{0}", salary);
            Console.WriteLine("Available Days Off:{0}", availableDaysOff);
            Console.WriteLine("Anul nasterii:{0}", dateOfBirth);

        }//Metoda de afisare a informatiilor cerute in cerinta

        public void LeaveDisplayInfo()
        { int count=0;
            Console.WriteLine("Istoric Concedii 2016 ");
            for (int i = 0; i < listLeave.Count; i++)
            {
                if (listLeave[i].startingDate.Year == 2016)
                {
                    count++;
                    Console.WriteLine("Numele angajatului: " + listLeave[i].employee);
                    Console.WriteLine("Durata concediului: " + listLeave[i].duration);
                    Console.WriteLine("Data de start a concediului: " + listLeave[i].startingDate);
                    Console.WriteLine("Tipul concediului: " + listLeave[i].vacation);
                }
                
            }
            if(count==0)
            {
                Console.WriteLine("Nu exista concedii in 2016 pentru acest angajat");
            }
        }//Metoda de afisare a concediilor .

        private void SubstractDays(int duration)
        {
            availableDaysOff = availableDaysOff - duration;

        }//Metoda de scadere zile de concediu ale Employee



        public void AddNewLeave(DateTime startingDate, int duration, LeaveType vacation)
        {

            if (duration > availableDaysOff)
            {
                throw new NegativeLeaveDays();//lansare exceptie manuala
            }
            try
            {
                Leave newleave = new Leave(startingDate, duration, vacation);
                newleave.employee = this.lastName + " " + this.firstName;

                SubstractDays(duration);
                listLeave.Add(newleave);//adaugare concedii in lista de concedii
            }
            catch (NegativeLeaveDays)
            {
                Console.WriteLine("Numarul de zile ramase nu poate fi mai mare decat durata concediului!");
            }


        }//Metoda de adaugare concediu nou
    }

}
