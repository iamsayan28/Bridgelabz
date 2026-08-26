//using System;

//class Program
//{
//    public static void Main()
//    {
//        //Assignment-02
//        // Q1
//        int birthYear = 2000;
//        int currentYear = 2024;
//        int age = currentYear - birthYear;

//        Console.WriteLine("Harry's age in 2024 is " + age);


//        // Q2
//        int maths = 94;
//        int physics = 95;
//        int chemistry = 96;

//        double average = (maths + physics + chemistry) / 3.0;

//        Console.WriteLine("Sam's average mark in PCM is " + average);


//        // Q3
//        double km = 10.8;
//        double miles = km * 1.6;

//        Console.WriteLine("The distance " + km + " km in miles is " + miles);


//        // Q4
//        double costPrice = 129;
//        double sellingPrice = 191;

//        double profit = sellingPrice - costPrice;
//        double profitPercentage = (profit / costPrice) * 100;

//        Console.WriteLine(
//            "The Cost Price is INR " + costPrice +
//            " and Selling Price is INR " + sellingPrice +
//            "\nThe Profit is INR " + profit +
//            " and the Profit Percentage is " + profitPercentage
//        );


//        // Q5
//        int pens = 14;
//        int students = 3;

//        int pensPerStudent = pens / students;
//        int remainingPens = pens % students;

//        Console.WriteLine(
//            "The Pen Per Student is " + pensPerStudent +
//            " and the remaining pen not distributed is " + remainingPens
//        );


//        // Q6
//        double fee = 125000;
//        double discountPercent = 10;

//        double discount = fee * discountPercent / 100;
//        double finalFee = fee - discount;

//        Console.WriteLine(
//            "The discount amount is INR " + discount +
//            " and final discounted fee is INR " + finalFee
//        );


//        // Q7
//        double radiusKm = 6378;
//        double pi = Math.PI;

//        double volumeKm = (4.0 / 3.0) * pi * Math.Pow(radiusKm, 3);

//        double radiusMiles = radiusKm * 0.621371;
//        double volumeMiles = (4.0 / 3.0) * pi * Math.Pow(radiusMiles, 3);

//        Console.WriteLine(
//            "The volume of earth in cubic kilometers is " +
//            volumeKm +
//            " and cubic miles is " +
//            volumeMiles
//        );


//        // Q8
//        double inputKm = double.Parse(Console.ReadLine());

//        double inputMiles = inputKm / 1.6;

//        Console.WriteLine(
//            "The total miles is " + inputMiles +
//            " mile for the given " + inputKm + " km"
//        );


//        // Q9
//        double studentFee = double.Parse(Console.ReadLine());
//        double studentDiscountPercent = double.Parse(Console.ReadLine());

//        double studentDiscount = studentFee * studentDiscountPercent / 100;

//        double discountedFee = studentFee - studentDiscount;

//        Console.WriteLine(
//            "The discount amount is INR " + studentDiscount +
//            " and final discounted fee is INR " + discountedFee
//        );


//        // Q10
//        double heightCm = double.Parse(Console.ReadLine());

//        double totalInches = heightCm / 2.54;
//        int feet = (int)(totalInches / 12);
//        double inches = totalInches % 12;

//        Console.WriteLine(
//            "Your Height in cm is " + heightCm +
//            " while in feet is " + feet +
//            " and inches is " + inches
//        );


//        // Q11
//        double number1 = double.Parse(Console.ReadLine());
//        double number2 = double.Parse(Console.ReadLine());

//        double addition = number1 + number2;
//        double subtraction = number1 - number2;
//        double multiplication = number1 * number2;
//        double division = number1 / number2;

//        Console.WriteLine(
//            "The addition, subtraction, multiplication and division value " +
//            "of 2 numbers " + number1 + " and " + number2 +
//            " is " + addition + ", " +
//            subtraction + ", " +
//            multiplication + ", and " +
//            division
//        );


//        // Q12
//        double baseCm = double.Parse(Console.ReadLine());
//        double triangleHeightCm = double.Parse(Console.ReadLine());

//        double areaCm = 0.5 * baseCm * triangleHeightCm;
//        double areaInches = areaCm / (2.54 * 2.54);

//        Console.WriteLine(
//            "The area of the triangle is " +
//            areaCm + " square centimeters and " +
//            areaInches + " square inches"
//        );


//        // Q13
//        double perimeter = double.Parse(Console.ReadLine());

//        double side = perimeter / 4;

//        Console.WriteLine(
//            "The length of the side is " + side +
//            " whose perimeter is " + perimeter
//        );


//        // Q14
//        double distanceInFeet = double.Parse(Console.ReadLine());

//        double distanceInYards = distanceInFeet / 3;
//        double distanceInMiles = distanceInYards / 1760;

//        Console.WriteLine(
//            "The distance in yards is " + distanceInYards +
//            " and in miles is " + distanceInMiles
//        );


//        // Q15
//        double unitPrice = double.Parse(Console.ReadLine());
//        int quantity = int.Parse(Console.ReadLine());

//        double totalPrice = unitPrice * quantity;

//        Console.WriteLine(
//            "The total purchase price is INR " + totalPrice +
//            " if the quantity " + quantity +
//            " and unit price is INR " + unitPrice
//        );


//        // Q16
//        int numberOfStudents = int.Parse(Console.ReadLine());
//        int handshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;
//        Console.WriteLine(
//            "The maximum number of handshakes is " + handshakes
//        );

//        //Assignment-03
//        // Q1
//        int n1 = int.Parse(Console.ReadLine());
//        int n2 = int.Parse(Console.ReadLine());

//        int quotient = n1 / n2;
//        int remainder = n1 % n2;

//        Console.WriteLine(
//            "The Quotient is " + quotient +
//            " and Remainder is " + remainder +
//            " of two numbers " + number1 +
//            " and " + number2
//        );


//        // Q2
//        int a = int.Parse(Console.ReadLine());
//        int b = int.Parse(Console.ReadLine());
//        int c = int.Parse(Console.ReadLine());

//        int operation1 = a + b * c;
//        int operation2 = a * b + c;
//        int operation3 = c + a / b;
//        int operation4 = a % b + c;

//        Console.WriteLine(
//            "The results of Int Operations are " +
//            operation1 + ", " +
//            operation2 + ", " +
//            operation3 + ", and " +
//            operation4
//        );


//        // Q3
//        double doubleA = double.Parse(Console.ReadLine());
//        double doubleB = double.Parse(Console.ReadLine());
//        double doubleC = double.Parse(Console.ReadLine());

//        double doubleOperation1 = doubleA + doubleB * doubleC;
//        double doubleOperation2 = doubleA * doubleB + doubleC;
//        double doubleOperation3 = doubleC + doubleA / doubleB;
//        double doubleOperation4 = doubleA % doubleB + doubleC;

//        Console.WriteLine(
//            "The results of Double Operations are " +
//            doubleOperation1 + ", " +
//            doubleOperation2 + ", " +
//            doubleOperation3 + ", and " +
//            doubleOperation4
//        );


//        // Q4
//        double celsius = double.Parse(Console.ReadLine());

//        double fahrenheitResult = (celsius * 9 / 5) + 32;

//        Console.WriteLine(
//            "The " + celsius +
//            " Celsius is " + fahrenheitResult +
//            " Fahrenheit"
//        );


//        // Q5
//        double fahrenheit = double.Parse(Console.ReadLine());

//        double celsiusResult = (fahrenheit - 32) * 5 / 9;

//        Console.WriteLine(
//            "The " + fahrenheit +
//            " Fahrenheit is " + celsiusResult +
//            " Celsius"
//        );


//        // Q6
//        double salary = double.Parse(Console.ReadLine());
//        double bonus = double.Parse(Console.ReadLine());

//        double totalIncome = salary + bonus;

//        Console.WriteLine(
//            "The salary is INR " + salary +
//            " and bonus is INR " + bonus +
//            ". Hence Total Income is INR " + totalIncome
//        );


//        // Q7
//        int firstNumber = int.Parse(Console.ReadLine());
//        int secondNumber = int.Parse(Console.ReadLine());

//        int temp = firstNumber;
//        firstNumber = secondNumber;
//        secondNumber = temp;

//        Console.WriteLine(
//            "The swapped numbers are " +
//            firstNumber + " and " + secondNumber
//        );


//        // Q8
//        string name = Console.ReadLine();
//        string fromCity = Console.ReadLine();
//        string viaCity = Console.ReadLine();
//        string toCity = Console.ReadLine();

//        double fromToVia = double.Parse(Console.ReadLine());
//        double viaToFinalCity = double.Parse(Console.ReadLine());
//        double timeTaken = double.Parse(Console.ReadLine());

//        double totalDistance = fromToVia + viaToFinalCity;

//        Console.WriteLine(
//            "The results of the trip are: " +
//            name + ", " +
//            totalDistance + " miles, and " +
//            timeTaken + " hours"
//        );


//        // Q9
//        double side1 = double.Parse(Console.ReadLine());
//        double side2 = double.Parse(Console.ReadLine());
//        double side3 = double.Parse(Console.ReadLine());

//        double perim = side1 + side2 + side3;

//        double totalDistanceMeters = 5000;
//        double rounds = totalDistanceMeters / perim;

//        Console.WriteLine(
//            "The total number of rounds the athlete will run is " +
//            rounds +
//            " to complete 5 km"
//        );


//        // Q10
//        int numberOfChocolates = int.Parse(Console.ReadLine());
//        int numberOfChildren = int.Parse(Console.ReadLine());

//        int chocolatesPerChild = numberOfChocolates / numberOfChildren;

//        int remainingChocolates = numberOfChocolates % numberOfChildren;

//        Console.WriteLine(
//            "The number of chocolates each child gets is " +
//            chocolatesPerChild +
//            " and the number of remaining chocolates is " +
//            remainingChocolates
//        );


//        // Q11
//        double principal = double.Parse(Console.ReadLine());
//        double rate = double.Parse(Console.ReadLine());
//        double time = double.Parse(Console.ReadLine());

//        double simpleInterest = (principal * rate * time) / 100;

//        Console.WriteLine(
//            "The Simple Interest is " +
//            simpleInterest +
//            " for Principal " +
//            principal +
//            ", Rate of Interest " +
//            rate +
//            " and Time " +
//            time
//        );


//        // Q12
//        double weight = double.Parse(Console.ReadLine());

//        double weightInKg = weight * 2.2;

//        Console.WriteLine(
//            "The weight of the person in pounds is " +
//            weight +
//            " and in kg is " +
//            weightInKg
//        );
//    }
//}