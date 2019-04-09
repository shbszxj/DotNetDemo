using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ftpClient = new FtpTest("192.168.8.240");
            //ftpClient.NotifyDocumentsToNfsServer();

            var ftpClient = new FluentFtpTest("192.168.8.250");
            ftpClient.Connect();
            ftpClient.DeleteFiles();
            ftpClient.UploadFiles();
            ftpClient.Disconnect();
            Console.Read();
        }
    }
}
