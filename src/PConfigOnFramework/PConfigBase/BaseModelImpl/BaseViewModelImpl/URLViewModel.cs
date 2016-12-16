using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseViewModelImpl
{
    public class URLViewModel : BasicModel, IViewModel
    {
        private string serverAddr;

        public string ServerAddr
        {
            get { return serverAddr; }
            set { serverAddr = value; }
        }
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        private string port;

        public string Port
        {
            get { return port; }
            set { port = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        //ftp://<user name>:<password>@<host/Internet address>:<port>/<url-path>
        //\"ftp://bts-bts_0001:3eAjtcew9i@ftp.irrimaxlive.com/\"
        //Regex r = new Regex(@"^(?<proto>\w+)://(?<userName>\w+)(?:?<password>\w+)?@(?<servAddr>\w+)?:(?<port>:\d+)?/(?<path>\w+)");
        //Regex r = new Regex(@"^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/");

        public string FullURL
        {
            get 
            {
                string temp = "ftp://";
                if (userName != null)
                {
                    temp += userName;
                }
                if (password != null && password != "")
                {
                    temp += ":" + password;
                }
                if (serverAddr != null && serverAddr != "")
                {
                    temp += "@" + serverAddr;
                }
                if (port != "" && port != null)
                {
                    temp += ":" + port;
                }
                if (path != "" && path != null)
                {
                    temp += path;
                }
                
                return temp;
                //return "ftp://" + userName + ":" + password + "@" + serverAddr + ":" + port + "/" + path; 
            }
            set
            {
                if (value != "")
                {
                    string temp = value;
                    if (temp[0] == '\"' && temp[temp.Length - 1] == '\"')
                    {
                        temp = temp.Substring(1, temp.Length - 2);
                    }

                    temp = temp.Substring(6, temp.Length - 6);
                    string[] result = temp.Split('@');
                    if (result.Length == 2)
                    {
                        parseUserNameAndPassword(result[0]);
                        parseAddrAndPort(parsePath(result[1]));
                    }
                    else if (result.Length == 1)
                    {
                        parseAddrAndPort(parsePath(result[0]));
                    }
                    
                }
               
            }
        }
        //ftp://bts-bts_0001:3eAjtcew9i@ftp.irrimaxlive.com
        private void parseUserNameAndPassword(string str)
        {
            string[] result = str.Split(':');
            if (result.Length == 2)
            {
                password = result[1];
            }
            userName = result[0];
        }

        private void parseAddrAndPort(string str)
        {
            string[] result = str.Split(':');
            if (result.Length == 2)
            {
                port = result[1];
            }
            serverAddr = result[0];
        }

        private string parsePath(string str)
        {
            string[] result = str.Split('/');
            if (result.Length == 2)
            {
                if (result[1] != null)
                {
                    path = "/" + result[1];
                }
                else
                {
                    path = "/";
                }

            }
            return result[0];
        }

        public URLViewModel()
        {

        }

        public URLViewModel(string fullpath)
        {
            this.FullURL = fullpath;
        }
    }
}
