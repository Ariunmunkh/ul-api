using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseLibrary.LConnection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Systems.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public class MConnection
    {
        private readonly RequestDelegate requestDeletegate;
        private readonly IConfiguration configuration;

        /// <summary>Initializes a new instance of the <see cref="MConnection"/> class.</summary>
        /// <param name="_requestDelegate">The request delegate.</param>
        /// <param name="_configuration"></param>
        public MConnection(RequestDelegate _requestDelegate, IConfiguration _configuration)
        {
            requestDeletegate = _requestDelegate;
            configuration = _configuration;
        }

        /// <summary>Invokes the specified context.</summary>
        /// <param name="context">The context.</param>
        /// <param name="con">The connection object</param>
        public async Task Invoke(HttpContext context, DWConnector con)
        {
            string connectionString = "Server=db-mysql-ul-do-user-12660272-0.b.db.ondigitalocean.com;Port=25060;Database=defaultdb;Uid=doadmin;Pwd=AVNS_RRgxsGwqDhfkw2tTbPa;";


            con.ReloadConnectionString(connectionString);
            using (var c = con.Initialize())
            {
                c.Open();
                await requestDeletegate.Invoke(context);
            }

        }


    }
}
