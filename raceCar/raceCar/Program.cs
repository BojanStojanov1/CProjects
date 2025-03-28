using raceCar;


 void RaceCars(Car car1, Car car2)
{
    int speed1 = car1.CalculateSpeed();
    int speed2 = car2.CalculateSpeed();

    if (speed1 > speed2)
        Console.WriteLine($"{car1.Model} driven by {car1.Driver.Name} won with a speed of {speed1}!");
    else if (speed2 > speed1)
        Console.WriteLine($"{car2.Model} driven by {car2.Driver.Name} won with a speed of {speed2}!");
    else
        Console.WriteLine("It's a tie!");
}
 
    Car[] cars = {
            new Car("Audi", 220),
            new Car("BMW", 130),
            new Car("Mercedes", 200),
            new Car("Porsche", 280)
        };

    Driver[] drivers = {
            new Driver("Bojan", 3),
            new Driver("Vlatko", 4),
            new Driver("Marjan", 5),
            new Driver("Andrej", 2)
        };

    while (true)
    {
        Console.WriteLine("Choose a car no.1:");
        for (int i = 0; i < cars.Length; i++)
            Console.WriteLine($"{i + 1}. {cars[i].Model}");
        int car1Index = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("Choose Driver:");
        for (int i = 0; i < drivers.Length; i++)
            Console.WriteLine($"{i + 1}. {drivers[i].Name}");
        int driver1Index = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("Choose a car no.2:");
        for (int i = 0; i < cars.Length; i++)
        {
            if (i != car1Index)
                Console.WriteLine($"{i + 1}. {cars[i].Model}");
        }
        int car2Index = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("Choose Driver:");
        for (int i = 0; i < drivers.Length; i++)
            Console.WriteLine($"{i + 1}. {drivers[i].Name}");
        int driver2Index = int.Parse(Console.ReadLine()) - 1;

        cars[car1Index].Driver = drivers[driver1Index];
        cars[car2Index].Driver = drivers[driver2Index];

        RaceCars(cars[car1Index], cars[car2Index]);

        Console.WriteLine("Do you want to race again? (yes/no): ");
        if (Console.ReadLine().ToLower() != "yes")
            break;
    }
    

