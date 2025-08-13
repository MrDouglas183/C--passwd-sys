using System.Text;

namespace AFs;

public class Pkgfun()
{
    static string passwd = "Null";
    public static bool havpasswd = false;
    public static FileStream Fs = new FileStream("passwd.passwd", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
    public static void Get_passwd()
    {
        Fs.Position = 0;
        StringBuilder havgetb = new StringBuilder();
        int getb = Fs.ReadByte();
        if (getb == -1)
        {
            havpasswd = false;
        }
        else if (getb != -1)
        {
            havpasswd = true;
            while (getb != -1)
            {
                havgetb.Append(getb.ToString());
                getb = Fs.ReadByte();
                passwd = havgetb.ToString();
            }
        }
        else
        {
            Console.WriteLine("wrong!unknown form of passwd");
            Console.ReadKey();
        }
    }

    public static void Set_passwd()
    {
        Console.Write("you have no passwd,please enter a new passwd ~> ");
            string? TempPasswd = Console.ReadLine();
        if (TempPasswd != null)
        {
            passwd = TempPasswd;
            for (int i = 1; i <= TempPasswd?.Length; i = i + 1)
            {
                string strInum = TempPasswd.Substring(i - 1, 1);
                byte INum = Convert.ToByte(strInum);
                Fs.WriteByte(INum);
            }
        }
    }

    public static bool Check_passwd()
    {
        Console.Write("please enter your passwd ~> ");
        string? getpasswd = Console.ReadLine();
        if (getpasswd == passwd)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}