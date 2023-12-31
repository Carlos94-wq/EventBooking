﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EventBooking.Application.Error
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
