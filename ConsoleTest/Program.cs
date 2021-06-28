using System;
using Tools;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Test t = new Test { password = "Hello World!", salt = Guid.NewGuid().ToString() };
            Test t2 = new Test { password = t.password, salt = t.salt };
            Console.WriteLine( PasswordHasher.Hashing<Test>(t, t=>t.password, t=>t.salt) );
            Console.WriteLine( PasswordHasher.Hashing<Test>(t2, t=>t.password, t=>t.salt) );
        }
    }

    class Test {
        public string password;
        public string salt;
    }
}
