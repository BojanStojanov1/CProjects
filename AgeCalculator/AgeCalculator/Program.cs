/*# Homework Class 4 📒

## Task
*Make a method called AgeCalculator
* The method will have one input parameter, your birthday date
* The method should return your age
* Show the age of a user after he inputs a date

> Note: take into consideration if the birthday is today, after or before today*/
 void AgeCalculator ()
{
    Console.Write("Enter the date of birth (yyyy-mm-dd): ");
    bool success = DateTime.TryParse(Console.ReadLine(), out DateTime birthDate);
    DateTime today = DateTime.Today;
    DateTime dayBefore = today.AddDays(-1);
    DateTime dayAfter = today.AddDays(1);
    var age = 0;
    if (success && birthDate != today && birthDate != dayBefore && birthDate != dayAfter)
    {
        age = DateTime.Now.Year - birthDate.Year;
        Console.WriteLine($"You are {age} years old!");
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
    
 }    

 
AgeCalculator();
Console.ReadLine();