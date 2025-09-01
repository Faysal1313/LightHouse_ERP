using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace f1.Classes
{
    internal class secy
    {
       

        public static string secu()
        {
            string str = "";
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from win32_DiskDrive");
            try
            {
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        str = enumerator.Current["SerialNumber"].ToString();
                        return str;
                    }
                }
            }
            catch (ManagementException ex)
            {
                return "";
            }
            return str;
        }

        public static string secu1()
        {
            string str = "";
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
            try
            {
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        str = enumerator.Current["SerialNumber"].ToString();
                        return str;
                    }
                }
            }
            catch (ManagementException ex)
            {
                return "";
            }
            return str;
        }

        public static string secu2()
        {
            string str = "";
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM win32_DiskDrive");
            try
            {
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        str = enumerator.Current["SerialNumber"].ToString();
                        return str;
                    }
                }
            }
            catch (ManagementException ex)
            {
                return "";
            }
            return str;
        }

        public static string MD5hash(string text)
        {
            MD5 md5 = (MD5)new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));
            byte[] hash = md5.Hash;
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < hash.Length; ++index)
                stringBuilder.Append(hash[index].ToString("X2"));
            string str = ((object)stringBuilder).ToString();
            return str.Substring(0, 5) + "-" + str.Substring(5, 5) + "-" + str.Substring(10, 5) + "-" + str.Substring(15, 5) + "-" + str.Substring(20, 5);
        }

        public static string decoder(string text)
        {
            MD5 md5 = (MD5)new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));
            byte[] hash = md5.Hash;
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < hash.Length; ++index)
                stringBuilder.Append(hash[index].ToString("X5"));
            string str = ((object)stringBuilder).ToString();
            return str.Substring(2, 7) + "-" + str.Substring(5, 7) + "-" + str.Substring(10, 7) + "-" + str.Substring(18, 7) + "-" + str.Substring(19, 7);
        }
    }
}
