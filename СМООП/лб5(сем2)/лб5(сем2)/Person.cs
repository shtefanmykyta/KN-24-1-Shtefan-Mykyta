namespace лб5_сем2_
{
    using System;

    namespace ConsoleApp
    {
        public class Person
        {
            private string firstName;
            private string? lastName;
            private DateTime birthDate;
            public Person(string firstName, string lastName, DateTime birthDate)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.birthDate = birthDate;
            }
            public Person() : this("Elizabeth", null, new DateTime(2000, 1, 1)) { }
            public string FirstName
            {
                get =>{return firstName;}
                set => {firstName = value;}
            }

            public string LastName
            {
                get => (lastName==null)?"NULL":lastName;
                set => lastName = value;
            }

            public DateTime BirthDate
            {
                get => birthDate;
                set => birthDate = value;
            }

            public int BirthYear
            {
                get => birthDate.Year;
                set => birthDate = new DateTime(value, birthDate.Month, birthDate.Day);
            }
            public override string ToString()
            {
                return $"{FirstName} {LastName}, Born: {BirthDate.ToShortDateString()}";
            }
            public string ToShortString()
            {
                return $"{FirstName} {LastName}";
            }
        }
    }

}
