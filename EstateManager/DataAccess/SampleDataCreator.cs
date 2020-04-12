using EstateManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EstateManager.DataAccess
{
    class SampleDataCreator
    {
        private static EstateManagerContext dbContext = EstateManagerContext.Current;

        public async static Task createSampleDataAsync()
        {
            if (dbContext.Persons.Count() == 0)
            {
                createPersons();
            }
            if (dbContext.Appointments.Count() == 0)
            {
                createAppointments(20, 5);
            }
            if (dbContext.Users.Count() == 0)
            {
                createUsers(dbContext.Users.Where(u => u.Type == TypeUser.Admin).Count() == 0);
            }
        }

        private static void createPersons()
        {
            Random rnd = new Random();
            for (int i = 0; i < 15; i++)
            {
                string[] arrayNames = { "Jean", "Paule", "Pierre", "Jacqueline", "Michel", "David", "Léo", "Claudette", "Cloé", "Gertrude", "Max", "Lucie", "Lucas", "Clément", "Carole" };

                string firstName = arrayNames[i];
                string lastName = arrayNames[i];
                string cellPhone = "";
                string mail = firstName + "." + lastName + "@truc.fr";
                string Adress = rnd.Next(0, 200) + " rue du " + lastName;
                string ZipCode = "";
                string city = lastName + firstName;

                for (int j = 0; j < 5; j++)
                {
                    ZipCode += rnd.Next(0, 10);
                }
                for (int j = 0; j < 10; j++)
                {
                    cellPhone += rnd.Next(0, 10);
                }
                Person toAdd = new Person()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    ZipCode = ZipCode,
                    Address = Adress,
                    City = city,
                    CellPhone = cellPhone
                };
                dbContext.Add(toAdd);
            }
            dbContext.SaveChanges();
        }

        private static void createAppointments(int appointmentsCount, int periodFromToday)
        {
            Random rnd = new Random();
            for (int i = 0; i < appointmentsCount; i++)
            {
                DateTime temp = DateTime.Now.AddDays(rnd.Next(-periodFromToday, periodFromToday));
                dbContext.Appointments.Add(new Appointment
                {
                    Date = temp,
                    Reason = "Reason : ma date est le " + temp,
                    Person1Id = rnd.Next(1, 10),
                    Person2Id = rnd.Next(1, 10)
                }); ;
            }
            dbContext.SaveChanges();
        }

        private static void createUsers(bool createAdmin)
        {
            if (createAdmin)
            {
                dbContext.Add(new User
                {
                    Password = "admin",
                    Type = TypeUser.Admin,
                    Username = "admin",
                    PersonId = 1
                });
            }
            for (int i = 0; i < 5; i++)
            {
                dbContext.Add(new User
                {
                    Password = i + "password" + i,
                    Type = TypeUser.Client,
                    Username = i + "username" + i,
                    PersonId = i + 1
                });
            }
            for (int i = 5; i < 10; i++)
            {
                dbContext.Add(new User
                {
                    Password = i + "password" + i,
                    Type = TypeUser.Commercial,
                    Username = i + "username" + i,
                    PersonId = i + 1
                });
            }
            for (int i = 10; i < 12; i++)
            {
                dbContext.Add(new User
                {
                    Password = i + "password" + i,
                    Type = TypeUser.Secretary,
                    Username = i + "username" + i,
                    PersonId = i + 1
                });
            }
            dbContext.SaveChanges();
        }
    }
}
