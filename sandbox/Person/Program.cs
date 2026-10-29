class Program
{
    static void Main()
    {
        Person myPerson = new Person("Bob", "Floyd", 56, 238);

        Console.WriteLine(myPerson.GetPersonInformation());

        Police myPolice = new Police("Lance", "Bob", 34, 186, "Taser");
       

        Console.WriteLine(myPolice.GetPoliceInformation());

        Doctor myDoctor = new Doctor("Billy", "Payne", 20, 150, "Knife");

        Console.WriteLine(myDoctor.GetDoctorInformation());

        List<Person> myPeople = new List<Person>();

        myPeople.Add(myPerson);
        myPeople.Add(myDoctor);
        myPeople.Add(myPolice);

        foreach(Person person in myPeople)
        {
            Console.WriteLine(person.GetPersonInformation());
        }

    }
}