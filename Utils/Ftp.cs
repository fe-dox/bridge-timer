using System;
using System.IO;
using System.Linq;
using System.Net;

namespace Utils
{
    public class Ftp
    {
        private readonly NetworkCredential _credentials;
        private readonly string _path;
        private readonly string _address;
        public bool Connected { get; private set; }


        public Ftp(string username, string password, string path)
        {
            if (!path.StartsWith("ftp://")) path = "ftp://" + path;
            if (!path.EndsWith("/")) path += "/";
            var uri = new Uri(path);
            _address = "ftp://" + uri.Host;
            _path = path;
            _credentials = new NetworkCredential(username, password);
            Connected = false;
        }

        public void ConnectAndCreateDirectories()
        {
            var directories = _path.Replace(_address, "").Split('/').Where(str => !string.IsNullOrWhiteSpace(str));
            var currentDirectory = _address;

            try
            {
                var ftpWebRequest = (FtpWebRequest) WebRequest.Create(currentDirectory);
                ftpWebRequest.Credentials = _credentials;
                ftpWebRequest.GetResponse().Close();
            }
            catch (WebException e)
            {
                if (((FtpWebResponse) e.Response).StatusCode == FtpStatusCode.NotLoggedIn)
                    throw;

                if (e.Status == WebExceptionStatus.ConnectFailure ||
                    e.Status == WebExceptionStatus.NameResolutionFailure)
                    throw;
            }

            foreach (string directory in directories)
            {
                try
                {
                    currentDirectory += "/" + directory;
                    var ftpWebRequest = (FtpWebRequest) WebRequest.Create(currentDirectory);
                    ftpWebRequest.Credentials = _credentials;
                    ftpWebRequest.UseBinary = true;
                    ftpWebRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                    var response = ftpWebRequest.GetResponse();
                    var ftpStream = response.GetResponseStream();
                    ftpStream?.Close();
                    response.Close();
                }
                catch (WebException ex)
                {
                    if (((FtpWebResponse) ex.Response).StatusCode == FtpStatusCode.NotLoggedIn)
                        throw;

                    if (ex.Status == WebExceptionStatus.ConnectFailure ||
                        ex.Status == WebExceptionStatus.NameResolutionFailure)
                        throw;

                    //directory already exist I know that is weak but there is no way to check if a folder exist on ftp...
                }
            }

            Connected = true;
        }

        public bool UploadDirectory(string localPath, string pathOnServer = "", WebClient? client = null)
        {
            client ??= new WebClient {Credentials = _credentials};

            string[] files = Directory.GetFiles(localPath, "*.*");
            string[] subDirs = Directory.GetDirectories(localPath);

            foreach (string file in files)
            {
                UploadFile(pathOnServer + Path.GetFileName(file), file, client);
            }

            foreach (string subDir in subDirs)
            {
                CreateDirectory(pathOnServer + Path.GetFileName(subDir));
                UploadDirectory(subDir, pathOnServer + "/" + Path.GetFileName(subDir) + "/", client);
            }

            return true;
        }

        private bool CreateDirectory(string name)
        {
            try
            {
                var ftpWebRequest = (FtpWebRequest) WebRequest.Create(_path + name);
                ftpWebRequest.Credentials = _credentials;
                ftpWebRequest.UseBinary = true;
                ftpWebRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                var response = ftpWebRequest.GetResponse();
                response.GetResponseStream()?.Close();
                response.Close();
            }
            catch (WebException ex)
            {
                if (((FtpWebResponse) ex.Response).StatusCode == FtpStatusCode.NotLoggedIn)
                    return false;
                if (ex.Status == WebExceptionStatus.ConnectFailure ||
                    ex.Status == WebExceptionStatus.NameResolutionFailure)
                    return false;

                //directory already exist I know that is weak but there is no way to check if a folder exist on ftp...
            }

            return true;
        }

        public bool UploadFile(string pathOnServer, string filePath)
        {
            var client = new WebClient
            {
                Credentials = _credentials
            };
            return UploadFile(pathOnServer, filePath, client);
        }

        private bool UploadFile(string pathOnServer, string filepath, WebClient client)
        {
            if (!Connected)
            {
                throw new Exception("FTP Not connected");
            }

            try
            {
                client.UploadFile($"{_path}{pathOnServer}", WebRequestMethods.Ftp.UploadFile,
                    filepath);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}