using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taste.Utility
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Status { get; set; }
        public StatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public int PageNo { get; set; }
        public int ItemPerPage { get; set; }

    }

    public enum StatusCode
    {
        Ok = 200,
        Created = 201,
        UnAuthorized = 401,
        NotFound = 404,
        Confilict = 409,
        InternalServerError = 500
    }
}
