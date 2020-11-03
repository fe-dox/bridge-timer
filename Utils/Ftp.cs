using System;
using System.Linq;
using System.Net;

namespace Utils
{
    public class Ftp
    {
        private NetworkCredential _credentials;
        private readonly string _username;
        private readonly string _password;
        private string _path;
        private string _address;
        public bool Connected { get; private set; }

        public event EventHandler? SendingFile;


        public Ftp(string username, string password, string path)
        {
            if (!path.StartsWith("ftp://")) path = "ftp://" + path;
            if (!path.EndsWith("/")) path += "/";
            _username = username;
            _password = password;
            var uri = new Uri(path);
            _address = "ftp://" + uri.Host;
            _path = path;
            _credentials = new NetworkCredential(_username, _password);
            Connected = false;
        }

        public void ConnectAndCreateDirectories()
        {
            var directiories = _path.Replace(_address, "").Split('/').Where(str => !string.IsNullOrWhiteSpace(str));

            Connected = true;
        }

        public void Disconnect()
        {
            Connected = false;
        }
    }
}