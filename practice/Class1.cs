////using System;

//class Ques1
//{
//    static int Add(int a, int b)
//    {
//        return a + b;
//    }

//    static double TempConversion(double celsius)
//    {
//        return (celsius * 9 / 5) + 32;
//    }

//    static double AreaOfCircle(double r)
//    {
//        return 2 * Math.PI * r;
//    }

//    static double VolOfCylinder(double r, double h)
//    {
//        return Math.PI * Math.Pow(r, 2) * h;
//    }

//    static int SimpleInterest(int p, int r, int t)
//    {
//        return (p * r * t) / 100;
//    }

//    static int PerimterOfRectangle(int l, int w)
//    {
//        return 2 * (l + w);
//    }

//    static double Power(double  b, double e)
//    {
//        return Math.Pow(b, e);
//    }

//    static double Avg(int a, int b, int c)
//    {
//        return (a + b + c) / 2;
//    }

//    static double KmToMiles(double km)
//    {
//        return km * 0.621371;
//    }


//    public static void Main(String[] args)
//    {
//        // 1.
//        Console.WriteLine("Welcome to Bridgelabz!");
        
//        // 2. Add 2 nos.
//        int a = int.Parse(Console.ReadLine());
//        int b = int.Parse(Console.ReadLine());
//        Console.WriteLine(Add(a, b));

//        // 3. Celsius to Fahrenheit Conversion
//        double tempCels = double.Parse(Console.ReadLine());
//        Console.WriteLine(TempConversion(tempCels));

//        // 4. Area of a cirlce
//        double radius = double.Parse(Console.ReadLine());
//        Console.WriteLine(AreaOfCircle(radius));

//        // 5. Volume of a Cylinder
//        double radius1 = double.Parse(Console.ReadLine());
//        double h = double.Parse(Console.ReadLine());
//        Console.WriteLine(VolOfCylinder(radius1, h));

//        // 6. Calc simple interest
//        int p = int.Parse(Console.ReadLine());
//        int r = int.Parse(Console.ReadLine());
//        int t = int.Parse(Console.ReadLine());
//        Console.WriteLine(SimpleInterest(p, r, t));

//        // 7. Perimeter of Rect.
//        int l  = int.Parse(Console.ReadLine());
//        int br = int.Parse(Console.ReadLine());
//        Console.WriteLine(PerimterOfRectangle(l, br));

//        // 8. Power calc
//        double bs = double.Parse(Console.ReadLine());
//        double e = double.Parse(Console.ReadLine());
//        Console.WriteLine(Power(bs, e));

//        // 9. avg of 3
//        a = int.Parse(Console.ReadLine());
//        b = int.Parse(Console.ReadLine());
//        int c = int.Parse(Console.ReadLine());
//        Console.WriteLine(Avg(a, b, c));
        
//        // 10. Conv km to miles
//        int km = int.Parse(Console.ReadLine());
//        Console.WriteLine(KmToMiles(km));

//    }
//}
