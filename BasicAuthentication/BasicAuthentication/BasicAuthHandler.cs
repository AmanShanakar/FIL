using System.Text; // It provides classes for encoding and decoding character sets, including the Encoding class used later in the code.

namespace BasicAuthentication
{
    public class BasicAuthHandler
    {
        //RequestDelegate is a delegate used to represent middleware in ASP.NET Core
        private readonly RequestDelegate next;
        private readonly string relm;
        public BasicAuthHandler(RequestDelegate next , string relm)
        {
            this.next = next;
            this.relm = relm;
        }

        public async Task InvokeAsync(HttpContext context)  // Used to handle HTTP requests
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            //Basic userid:password
            var header = context.Request.Headers["Authorization"].ToString();  //retrieves the "Authorization" header from the HTTP request
            //The "Authorization" header value often starts with the word "Basic," followed by a space and the Base64-encoded credentials
            var encoderdCreds = header.Substring(6);
            //It decodes the Base64-encoded credentials into a plain text string, containing the format "username:password"
            var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encoderdCreds)); 
            string[] uidpwd = creds.Split(':');
            var uid = uidpwd[0]; //extracted username to variables
            var password = uidpwd[1]; //extracted password to variables

            if (uid != "aman" || password != "password")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            await next(context);
        }
    }
}
