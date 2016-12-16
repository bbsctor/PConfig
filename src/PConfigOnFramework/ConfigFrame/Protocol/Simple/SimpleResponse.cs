﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConfigFrame.Protocol.Simple
{
    public class SimpleResponse:SimpleFrame, IResponse
    {
        private IRequest request;
        public IRequest Request
        {
            get { return request; }
            set { this.request = value; }
        }

        public void parse(byte[] inData)
        {
            Data = inData;
        }
    }
}
