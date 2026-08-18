////Prog p1 = new Prog();
////p1.x = 1;
////Prog p2 = p1;
////p2.x = 2;
////Console.WriteLine(p1.x);
////Console.WriteLine(p2.x);

////struct1.Prog s1 = new struct1.Prog();
////s1.x = 3;
////struct1.Prog s2 = s1;
////s2.x = 4;
////Console.WriteLine(s1.x);
////Console.WriteLine(s2.x);

////// class
////class Prog
////{
////    public int x;
////}

////// struct
////namespace struct1
////{
////    struct Prog
////    {
////        public int x;
////    }
////}

//// delegate- learning

//Prog p = new Prog();
//int add(int a, int b)
//{
//    return a + b;
//}
//int sub(int a, int b)
//{
//    return a - b;
//}

//MyDelegate deleg = add;
//deleg += sub;

//Console.WriteLine(p.function(10, 15, add));
//Console.WriteLine(p.function(10, 15, sub));
//delegate int MyDelegate(int a, int b);

//class Prog
//{
//    public int function(int a, int b, MyDelegate deleg)
//    {
//        return deleg(a, b);
//    }
//}

