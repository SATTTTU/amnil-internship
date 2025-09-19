using System;
namespace Assignment5{
public class UseCase
{
        public static void Main(String[] args)
        {
            //  Program program = new Program();
            //     program.Run(args);
            // CheckUtilities program =new CheckUtilities ();
            // program.Run(args);

        Book b1=new Book(1,"C# ","John Doe");
        Book b2 =new Book(2,"Java ","Jane Smith");
        Member m1=new Member (1,"siva");
        Member m2 =new Member (2,"ram");
        m1.Borrow(b1);
        m2.Borrow(b1);
        m2.Borrow(b2);
        m1.Return(b1);
        m1.Borrow(b1);
        
    }

}
}