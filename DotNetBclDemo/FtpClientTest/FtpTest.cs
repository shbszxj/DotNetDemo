using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ftpclient;

namespace FtpClientTest
{
    public class FtpTest
    {
        private FtpClient ftpClient;

        private readonly string _ip;

        public FtpTest(string ip)
        {
            _ip = ip;
        }

        public void Copy()
        {
            var docFolder = $"{Environment.CurrentDirectory}\\doc";
            var docs = Directory.GetFiles(docFolder);
            Console.WriteLine($"{ DateTime.Now.ToLongTimeString()}");
            foreach (var doc in docs)
            {
                var fileName = doc.Split('\\').Last();
                File.Copy(doc, $"{docFolder}\\{Guid.NewGuid()}.pdf");
                Console.WriteLine($"{fileName} copied");
            }
            Console.WriteLine($"{ DateTime.Now.ToLongTimeString()}");
        }

        private void initFtpClient()
        {
            ftpClient = new FtpClient();
            ftpClient.UseAsTcpIpOnly = false;
            ftpClient.Open(_ip, 21);
            ftpClient.Login("anonymous", "");
            ftpClient.CreateDataSendBuffer();
            Thread.Sleep(200);
        }

        private void shutDownFtpClient()
        {
            Thread.Sleep(200);
            ftpClient.FtpConnection.Dispose();
            Thread.Sleep(200);
            ftpClient.Close();
            ftpClient.Dispose();
            ftpClient = null;
        }

        public void NotifyDocumentsToNfsServer()
        {
            initFtpClient();
            ftpClient.Command("CWD doc", null);

            string list = "";
            ftpClient.List(false, ref list);
            string[] splittedList = list.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            // Clean up all documents in the doc folder, since all documents in this folder will be synchronized to the units
            foreach (var doc in splittedList)
            {
                ftpClient.Command("DELE " + doc, null);
            }

            var watch = new Stopwatch();
            var docs = Directory.GetFiles($"{Environment.CurrentDirectory}\\doc");
            foreach (var doc in docs)
            {
                watch.Restart();
                var fileName = doc.Split('\\').Last();
                ftpClient.Put(fileName, doc);
                Console.WriteLine($"{fileName} uploaded, takes time : {watch.Elapsed.ToString()}");
            }
            shutDownFtpClient();
            // upload documents
            //var filesNotExist = new List<string>();
            //for (int i = 0; i < documents.Count; i++)
            //{
            //    var doc = documents[i];
            //    string fileFullName = doc.FileName;
            //    try
            //    {
            //        var docPath = SettingsHelper.CONFIGFILEFOLDER + "\\Doc\\Server\\" + fileFullName;
            //        if (File.Exists(docPath))
            //        {
            //            ftpClient.Put(fileFullName, docPath);
            //            logger.Info(fileFullName + " uploaded to FTP folder " + IP);
            //        }
            //        else
            //        {
            //            filesNotExist.Add(fileFullName);
            //            logger.Error(fileFullName + " does not exist in the Server folder!");
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        logger.InfoException(e.Message, e);
            //    }
            //}
            //if (filesNotExist.Count > 0)
            //{
            //    var documentsTransferFailed = documents.Where(doc => filesNotExist.Contains(doc.FileName)).ToList();
            //    PluginHoster.DocumentNotExistFault(filesNotExist);

            //    // If transfered failed, delete the docs both client and Cu.
            //    PluginHoster.DocumentDelete(documentsTransferFailed.Select(x => x.Id).ToList());
            //}
            //shutDownFtpClient();
        }
    }
}
