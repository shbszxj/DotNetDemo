using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;

namespace FtpClientTest
{
    public class FluentFtpTest
    {
        private FtpClient _client;

        private readonly string _ip;

        public FluentFtpTest(string ip)
        {
            _ip = ip;
            _client = new FtpClient(_ip);
            _client.ConnectTimeout = 100000;
            _client.DataConnectionConnectTimeout = 100000;
            _client.DataConnectionReadTimeout = 100000;
            _client.ReadTimeout = 100000;
            _client.Credentials = new System.Net.NetworkCredential("anonymous", "");
        }

        ~FluentFtpTest()
        {
            _client.Dispose();
        }

        public void Connect()
        {
            _client.Connect();
        }

        public void Disconnect()
        {
            _client.Disconnect();
        }

        public void DeleteFiles()
        {
            foreach (FtpListItem item in _client.GetListing("/doc"))
            {

                // if this is a file
                //if (item.Type == FtpFileSystemObjectType.File)
                //{

                //    // get the file size
                //    long size = _client.GetFileSize(item.FullName);

                //}

                //// get modified date/time of the file or folder
                //DateTime time = _client.GetModifiedTime(item.FullName);

                //// calculate a hash for the file on the server side (default algorithm)
                //FtpHash hash = _client.GetHash(item.FullName);
                _client.DeleteFile($"{item.FullName}");
            }
        }

        public void UploadFiles()
        {
            var generalWatch = new Stopwatch();
            var watch = new Stopwatch();
            var docs = Directory.GetFiles($"{Environment.CurrentDirectory}\\doc");
            generalWatch.Start();
            foreach (var doc in docs)
            {
                watch.Restart();
                var fileName = doc.Split('\\').Last();
                try
                {
                    _client.RetryAttempts = 10;
                    _client.UploadFile(doc, $"/doc/{fileName}", FtpExists.Overwrite, false, FtpVerify.Retry);
                    Console.WriteLine($"{fileName} uploaded, takes time : {watch.Elapsed.ToString()}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"upload {fileName} failed, takes time : {watch.Elapsed.ToString()}, error {e.InnerException.Message} ");
                }
            }
            Console.WriteLine($"total used : {generalWatch.Elapsed}");
            generalWatch.Stop();
        }
    }
}
