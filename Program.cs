using AFs;
class Program
{
    static void Main()
    {
        Pkgfun.Get_passwd();
        if (Pkgfun.havpasswd == false)
        {
            Pkgfun.Set_passwd();
        }
        bool checkstatic = Pkgfun.Check_passwd();
        while (checkstatic == false)
        {
            checkstatic = Pkgfun.Check_passwd();
        }
        Console.WriteLine("Login success!");
        Pkgfun.Fs.Close();
        Console.ReadKey();
    }
}
