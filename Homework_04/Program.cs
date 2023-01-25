Person person_01 = new Person("George", "Smith", 24, Gender.Male);
Person person_02 = new Person("Robert", "Johnson", 47, Gender.Male);
Person person_03 = new Person("Sofia", "Miller", 19, Gender.Female);
Person person_04 = new Person("Charlotte", "Rodriguez", 32, Gender.Female);

//Կազմված զանգվածը փոխանցել մեթոդի որը կգտնի միջին տարիքային հարաբերությունը
Console.WriteLine(Person.AverageAge());


//Տալ հնարավորություն ձևափոխել Employee ստրուկտուրան սովորական Person-ի

Employee employee_01 = new Employee("Charlotte", "Johnson", 2400, "Web_developer");
Person person_05 = employee_01;

Console.WriteLine(employee_01.name + " " + employee_01.surname);

employee_01 = person_01;

Console.WriteLine(employee_01.name + " " + employee_01.surname);


//Ստեղծել ստրուկտուրա որը կլինի Point(x,y,z)
//Տալ հնարավորություն: Գումարել, հանել, բազմապատկել, բաժանել

Point point_01 = new Point(2, 5, 6);
Point point_02 = new Point(1, 7, 0);

Console.WriteLine(point_01 + point_02);
Console.WriteLine(point_01 - point_02);
Console.WriteLine(point_01 * point_02);
Console.WriteLine(point_01 / point_02);

struct Person
{
    public string name { get; private set; }
    public string surname { get; private set; }
    public int age { get; private set; }
    public Gender gender { get; private set; }
    private static Person[] people = new Person[0];
    private static int count;

    public Person(string name, string surname, int age, Gender gender)
    {
        this.name = name;
        this.surname = surname;
        this.age = age;
        this.gender = gender;

        Array.Resize(ref people, ++count);
        people[count - 1] = this;
    }

    public static double AverageAge()
    {
        double age = 0;
        foreach (var item in people)
        {
            age += item.age;
        }
        return age / people.Length;
    }

    public static implicit operator Person(Employee employee)
    {
        Person person = new Person();
        person.name = employee.name;
        person.surname = employee.surname;
        return person;
    }

}

struct Employee
{
    public string name { get; private set; }
    public string surname { get; private set; }
    public float salary { get; private set; }
    public string positionAtWork { get; private set; }

    public Employee(string name, string surname, float salary, string positionAtWork)
    {
        this.name = name;
        this.surname = surname;
        this.salary = salary;
        this.positionAtWork = positionAtWork;

    }

    public static implicit operator Employee(Person person)
    {
        Employee employee = new Employee();
        employee.name = person.name;
        employee.surname = person.surname;
        return employee;
    }

}

struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public Point(int X, int Y, int Z)
    {
        this.X = X;
        this.Y = Y;
        this.Z = Z;
    }

    public static Point operator +(Point left, Point right)
    {
        return new Point(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    }

    public static Point operator -(Point left, Point right)
    {
        return new Point(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    }

    public static Point operator *(Point left, Point right)
    {
        return new Point(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
    }

    public static Point operator /(Point left, Point right)
    {
        if (right.X == 0 || right.Y == 0 || right.Z == 0)
        {
            throw new DivideByZeroException();
        }
        return new Point(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
    }

    public override string ToString()
    {
        return $"(X:{X} Y:{Y} Z:{Z})";
    }
}


public enum Gender
{
    Male,
    Female,
    Other
}

