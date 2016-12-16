﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigFrame.Protocol.Simple
{
    public class SimpleRequest:SimpleFrame,IRequest
    {
        private SimpleRequest request;
        public SimpleRequest Request
        {
            get { return request; }
            set { this.request = value;}
        }

        public SimpleRequest(byte[] data)
        {
            Data = data;
        }

        public IResponse genResponse()
        {
            return new SimpleResponse();
        }

        public byte[] genBytes()
        {
            return Data;
        }
    }
}
