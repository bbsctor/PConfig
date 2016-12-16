using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfigFrame.BaseModel;

namespace PConfigBase.BaseModelImpl.BaseDataModelImpl
{
    //数据
    //“ftp://	            用户名	：	  密码	@	ftp服务器地址	路径	”
    //22 66 74 70 3A 2F 2F		    3AH		    40H			                22H
    public class URLDataModel : BasicModel, IDataModel
    {
        public byte[] userName;
        public byte[] password;
        public byte[] serverAddr;
        public byte[] path;
        public byte[] port;

        private static byte[] url;
        public byte[] Url
        {
            get { return URLDataModel.url; }
            set { URLDataModel.url = value; } 
        }

        public override bool Equals(object obj)
        {
            URLDataModel model = obj as URLDataModel;
            if (obj != null)
            {
                return true;
            }
            return false;
        }
    }
}
