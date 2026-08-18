using System;

class Program
{
    public static void Main()
    {
        // Q1
        int birthYear = 2000;
        int currentYear = 2024;
        int age = currentYear - birthYear;

        Console.WriteLine("Harry's age in 2024 is " + age);


        // Q2
        int maths = 94;
        int physics = 95;
        int chemistry = 96;

        double average = (maths + physics + chemistry) / 3.0;

        Console.WriteLine("Sam's average mark in PCM is " + average);


        // Q3
        double km = 10.8;
        double miles = km * 1.6;

        Console.WriteLine("The distance " + km + " km in miles is " + miles);


        // Q4
        double costPrice = 129;
        double sellingPrice = 191;

        double profit = sellingPrice - costPrice;
        double profitPercentage = (profit / costPrice) * 100;

        Console.WriteLine(
            "The Cost Price is INR " + costPrice +
            " and Selling Price is INR " + sellingPrice +
            "\nThe Profit is INR " + profit +
            " and the Profit Percentage is " + profitPercentage
        );


        // Q5
        int pens = 14;
        int students = 3;

        int pensPerStudent = pens / students;
        int remainingPens = pens % students;

        Console.WriteLine(
            "The Pen Per Student is " + pensPerStudent +
            " and the remaining pen not distributed is " + remainingPens
        );


        // Q6
        double fee = 125000;
        double discountPercent = 10;

        double discount = fee * discountPercent / 100;
        double finalFee = fee - discount;

        Console.WriteLine(
            "The discount amount is INR " + discount +
            " and final discounted fee is INR " + finalFee
        );


        // Q7
        double radiusKm = 6378;
        double pi = Math.PI;

        double volumeKm = (4.0 / 3.0) * pi * Math.Pow(radiusKm, 3);

        double radiusMiles = radiusKm * 0.621371;
        double volumeMiles = (4.0 / 3.0) * pi * Math.Pow(radiusMiles, 3);

        Console.WriteLine(
            "The volume of earth in cubic kilometers is " +
            volumeKm +
            " and cubic miles is " +
            volumeMiles
        );


        // Q8
        double inputKm = double.Parse(Console.ReadLine());

        double inputMiles = inputKm / 1.6;

        Console.WriteLine(
            "The total miles is " + inputMiles +
            " mile for the given " + inputKm + " km"
        );


        // Q9
        double studentFee = double.Parse(Console.ReadLine());
        double studentDiscountPercent = double.Parse(Console.ReadLine());

        double studentDiscount = studentFee * studentDiscountPercent / 100;

        double discountedFee = studentFee - studentDiscount;

        Console.WriteLine(
            "The discount amount is INR " + studentDiscount +
            " and final discounted fee is INR " + discountedFee
        );


        // Q10
        double heightCm = double.Parse(Console.ReadLine());

        double totalInches = heightCm / 2.54;
        int feet = (int)(totalInches / 12);
        double inches = totalInches % 12;

        Console.WriteLine(
            "Your Height in cm is " + heightCm +
            " while in feet is " + feet +
            " and inches is " + inches
        );


        // Q11
        double number1 = double.Parse(Console.ReadLine());
        double number2 = double.Parse(Console.ReadLine());

        double addition = number1 + number2;
        double subtraction = number1 - number2;
        double multiplication = number1 * number2;
        double division = number1 / number2;

        Console.WriteLine(
            "The addition, subtraction, multiplication and division value " +
            "of 2 numbers " + number1 + " and " + number2 +
            " is " + addition + ", " +
            subtraction + ", " +
            multiplication + ", and " +
            division
        );


        // Q12
        double baseCm = double.Parse(Console.ReadLine());
        double triangleHeightCm = double.Parse(Console.ReadLine());

        double areaCm = 0.5 * baseCm * triangleHeightCm;
        double areaInches = areaCm / (2.54 * 2.54);

        Console.WriteLine(
            "The area of the triangle is " +
            areaCm + " square centimeters and " +
            areaInches + " square inches"
        );


        // Q13
        double perimeter = double.Parse(Console.ReadLine());

        double side = perimeter / 4;

        Console.WriteLine(
            "The length of the side is " + side +
            " whose perimeter is " + perimeter
        );


        // Q14
        double distanceInFeet = double.Parse(Console.ReadLine());

        double distanceInYards = distanceInFeet / 3;
        double distanceInMiles = distanceInYards / 1760;

        Console.WriteLine(
            "The distance in yards is " + distanceInYards +
            " and in miles is " + distanceInMiles
        );


        // Q15
        double unitPrice = double.Parse(Console.ReadLine());
        int quantity = int.Parse(Console.ReadLine());

        double totalPrice = unitPrice * quantity;

        Console.WriteLine(
            "The total purchase price is INR " + totalPrice +
            " if the quantity " + quantity +
            " and unit price is INR " + unitPrice
        );


        // Q16
        int numberOfStudents = int.Parse(Console.ReadLine());
        int handshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;
        Console.WriteLine(
            "The maximum number of handshakes is " + handshakes
        );
    }
}