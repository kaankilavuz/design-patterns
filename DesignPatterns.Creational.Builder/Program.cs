namespace DesignPatterns.Creational.Builder;

class Program
{
    static void Main(string[] args)
    {
        var personBuilder = new PersonBuilder();
        personBuilder.WithName("kaan");
        personBuilder.WithLastname("kilavuz");
        personBuilder.WithAge(27);
        personBuilder.WithAddress("gungoren");

        var person = personBuilder.Build();
        Console.WriteLine(person.ToString());

        Console.ReadKey();
    }

    class Person
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"{Name} {Lastname} {Age} {Address}";
        }
    }

    class PersonBuilder
    {
        private Person person;

        public PersonBuilder()
        {
            person = new Person();
        }

        public PersonBuilder WithName(string name)
        {
            person.Name = name;
            return this;
        }

        public PersonBuilder WithLastname(string lastname)
        {
            person.Lastname = lastname;
            return this;
        }

        public PersonBuilder WithAge(int age)
        {
            person.Age = age;
            return this;
        }

        public PersonBuilder WithAddress(string address)
        {
            person.Address = address;
            return this;
        }

        public Person Build()
        {
            return person;
        }
    }
}
