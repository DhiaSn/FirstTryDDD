namespace FirstTryDDD.SharedKarnel.Models
{
    #region StatusCode
    public class StatusCode
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
    #endregion

    #region StatusCodes
    /// <summary>
    /// For more Info check this link below 
    /// https://www.restapitutorial.com/httpstatuscodes.html
    /// </summary>
    public static class StatusCodes
    {
        #region 1.X.X
        public static StatusCode Status100Continue { get; private set; } = new StatusCode { Code = 100, Message = "Continue" };
        public static StatusCode Status101SwitchingProtocols { get; private set; } = new StatusCode { Code = 101, Message = "Switching Protocols" };
        public static StatusCode Status102Processing { get; private set; } = new StatusCode { Code = 102, Message = "Processing (WebDAV)" };
        #endregion

        #region 2.X.X
        public static StatusCode Status200OK { get; private set; } = new StatusCode { Code = 200, Message = "OK" };
        public static StatusCode Status201Created { get; private set; } = new StatusCode { Code = 201, Message = "Created" };
        public static StatusCode Status202Accepted { get; private set; } = new StatusCode { Code = 202, Message = "Accepted" };
        public static StatusCode Status203NonAuthoritative { get; private set; } = new StatusCode { Code = 203, Message = "Non-Authoritative Information" };
        public static StatusCode Status204NoContent { get; private set; } = new StatusCode { Code = 204, Message = "No Content" };
        public static StatusCode Status205ResetContent { get; private set; } = new StatusCode { Code = 205, Message = "Reset Content" };
        public static StatusCode Status206PartialContent { get; private set; } = new StatusCode { Code = 206, Message = "Partial Content" };
        public static StatusCode Status207MultiStatus { get; private set; } = new StatusCode { Code = 207, Message = "Multi-Status (WebDAV)" };
        public static StatusCode Status208AlreadyReported { get; private set; } = new StatusCode { Code = 208, Message = "Already Reported (WebDAV)" };
        public static StatusCode Status226IMUsed { get; private set; } = new StatusCode { Code = 226, Message = "IM Used" };
        #endregion

        #region 3.X.X
        public static StatusCode Status300MultipleChoices { get; private set; } = new StatusCode { Code = 300, Message = "Multiple Choices" };
        public static StatusCode Status301MovedPermanently { get; private set; } = new StatusCode { Code = 301, Message = "Moved Permanently" };
        public static StatusCode Status302Found { get; private set; } = new StatusCode { Code = 302, Message = "Found" };
        public static StatusCode Status303SeeOther { get; private set; } = new StatusCode { Code = 303, Message = "See Other" };
        public static StatusCode Status304NotModified { get; private set; } = new StatusCode { Code = 304, Message = "Not Modified" };
        public static StatusCode Status305UseProxy { get; private set; } = new StatusCode { Code = 305, Message = "Use Proxy" };
        public static StatusCode Status306SwitchProxy { get; private set; } = new StatusCode { Code = 306, Message = "Switch Proxy" };
        public static StatusCode Status307TemporaryRedirect { get; private set; } = new StatusCode { Code = 307, Message = "Temporary Redirect" };
        public static StatusCode Status308PermanentRedirect { get; private set; } = new StatusCode { Code = 308, Message = "Permanent Redirect (experimental)" };
        #endregion

        #region 4.X.X
        public static StatusCode Status400BadRequest { get; private set; } = new StatusCode { Code = 400, Message = "Bad Request" };
        public static StatusCode Status401Unauthorized { get; private set; } = new StatusCode { Code = 401, Message = "Unauthorized" };
        public static StatusCode Status402PaymentRequired { get; private set; } = new StatusCode { Code = 402, Message = "Payment Required" };
        public static StatusCode Status403Forbidden { get; private set; } = new StatusCode { Code = 403, Message = "Forbidden" };
        public static StatusCode Status404NotFound { get; private set; } = new StatusCode { Code = 404, Message = "Not Found" };
        public static StatusCode Status405MethodNotAllowed { get; private set; } = new StatusCode { Code = 405, Message = "Method Not Allowed" };
        public static StatusCode Status406NotAcceptable { get; private set; } = new StatusCode { Code = 406, Message = "Not Acceptable" };
        public static StatusCode Status407ProxyAuthenticationRequired { get; private set; } = new StatusCode { Code = 407, Message = "Proxy Authentication Required" };
        public static StatusCode Status408RequestTimeout { get; private set; } = new StatusCode { Code = 408, Message = "Request Timeout" };
        public static StatusCode Status409Conflict { get; private set; } = new StatusCode { Code = 409, Message = "Conflict" };
        public static StatusCode Status410Gone { get; private set; } = new StatusCode { Code = 410, Message = "Gone" };
        public static StatusCode Status411LengthRequired { get; private set; } = new StatusCode { Code = 411, Message = "Length Required" };
        public static StatusCode Status412PreconditionFailed { get; private set; } = new StatusCode { Code = 412, Message = "Precondition Failed" };
        public static StatusCode Status413PayloadTooLarge { get; private set; } = new StatusCode { Code = 413, Message = "Payload Too Large" };
        public static StatusCode Status413RequestEntityTooLarge { get; private set; } = new StatusCode { Code = 413, Message = "Request Entity Too Large" };
        public static StatusCode Status414RequestUriTooLong { get; private set; } = new StatusCode { Code = 414, Message = "Request Uri Too Long" };
        public static StatusCode Status414UriTooLong { get; private set; } = new StatusCode { Code = 414, Message = "Uri Too Long" };
        public static StatusCode Status415UnsupportedMediaType { get; private set; } = new StatusCode { Code = 415, Message = "Unsupported Media Type" };
        public static StatusCode Status416RangeNotSatisfiable { get; private set; } = new StatusCode { Code = 416, Message = "Range Not Satisfiable" };
        public static StatusCode Status416RequestedRangeNotSatisfiable { get; private set; } = new StatusCode { Code = 416, Message = "Requested Range Not Satisfiable" };
        public static StatusCode Status417ExpectationFailed { get; private set; } = new StatusCode { Code = 417, Message = "Expectation Failed" };
        public static StatusCode Status418ImATeapot { get; private set; } = new StatusCode { Code = 418, Message = "Im A Teapot" };
        public static StatusCode Status419AuthenticationTimeout { get; private set; } = new StatusCode { Code = 419, Message = "Authentication Timeout" };
        public static StatusCode Status421MisdirectedRequest { get; private set; } = new StatusCode { Code = 421, Message = "Misdirected Request" };
        public static StatusCode Status422UnprocessableEntity { get; private set; } = new StatusCode { Code = 422, Message = "Unprocessable Entity" };
        public static StatusCode Status423Locked { get; private set; } = new StatusCode { Code = 423, Message = "Locked" };
        public static StatusCode Status424FailedDependency { get; private set; } = new StatusCode { Code = 424, Message = "Failed Dependency" };
        public static StatusCode Status426UpgradeRequired { get; private set; } = new StatusCode { Code = 426, Message = "Upgrade Required" };
        public static StatusCode Status428PreconditionRequired { get; private set; } = new StatusCode { Code = 428, Message = "Precondition Required" };
        public static StatusCode Status429TooManyRequests { get; private set; } = new StatusCode { Code = 429, Message = "Too Many Requests" };
        public static StatusCode Status431RequestHeaderFieldsTooLarge { get; private set; } = new StatusCode { Code = 431, Message = "Request Header Fields Too Large" };
        public static StatusCode Status451UnavailableForLegalReasons { get; private set; } = new StatusCode { Code = 451, Message = "Unavailable For Legal Reasons" };
        #endregion

        #region 5.X.X
        public static StatusCode Status500InternalServerError { get; private set; } = new StatusCode { Code = 500, Message = "Internal Server Error" };
        public static StatusCode Status501NotImplemented { get; private set; } = new StatusCode { Code = 501, Message = "Not Implemented" };
        public static StatusCode Status502BadGateway { get; private set; } = new StatusCode { Code = 502, Message = "Bad Gateway" };
        public static StatusCode Status503ServiceUnavailable { get; private set; } = new StatusCode { Code = 503, Message = "Service Unavailable" };
        public static StatusCode Status504GatewayTimeout { get; private set; } = new StatusCode { Code = 504, Message = "Gateway Timeout" };
        public static StatusCode Status505HttpVersionNotsupported { get; private set; } = new StatusCode { Code = 505, Message = "Http Version Not supported" };
        public static StatusCode Status506VariantAlsoNegotiates { get; private set; } = new StatusCode { Code = 506, Message = "Variant Also Negotiates" };
        public static StatusCode Status507InsufficientStorage { get; private set; } = new StatusCode { Code = 507, Message = "Insufficient Storage" };
        public static StatusCode Status508LoopDetected { get; private set; } = new StatusCode { Code = 508, Message = "Loop Detected" };
        public static StatusCode Status510NotExtended { get; private set; } = new StatusCode { Code = 510, Message = "Not Extended" };
        public static StatusCode Status511NetworkAuthenticationRequired { get; private set; } = new StatusCode { Code = 511, Message = "Network Authentication Required" };
        #endregion

    }
    #endregion
}
