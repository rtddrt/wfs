using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wfs.WebApi.Base
{
    public class ResponseMessage
    {
        public ResponseCode code { get; set; }

        public string message { get; set; }

        public dynamic data { get; set; }

        public string redirectUrl { get; set; }

        public ResponseMessage()
        {
            code=ResponseCode.OK;
        }
    }

    public enum ResponseCode
    {
        OK = 0,
        FAIL = 1,
        ISEXIST = 2,
        EXCEPTION = 3,
        UNKNOWN = 4,
        UNAUTHORIZE=5
    }
}