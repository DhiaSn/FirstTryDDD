﻿using FirstTryDDD.SharedKernel.Enums;
using FirstTryDDD.SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FirstTryDDD.SharedKernel.Models
{
    public class Response
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ResponseResult Result { get; set; }
        public StatusCode Status { get; set; }

    }
    public class GlobalResponse: Response
    {
        public dynamic Object { get; set; }
    }

    public class SimpleErrorResponse : Response
    {
        public string MsgException { get; set; }
    }
    public class DetailedErrorResponse : Response
    {
        public ResponseException Exception { get; set; }
    }

    /*****************************************************************/
    public class ResponseException
    {
        public string Message { get; set; }
        public string AdditionalMessage { get; set; }
        public string[] Errors { get; set; }
    }
}
