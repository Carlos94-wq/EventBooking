﻿using System.Net;
using System.Text.Json;

namespace EventBooking.Application
{

    public class ErrorResponse
    {

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public string Message { get; set; }

        public string ToJsonString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
