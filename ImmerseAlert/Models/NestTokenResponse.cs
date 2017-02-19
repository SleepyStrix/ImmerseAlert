using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmerseAlert.Models
{
    /// <summary>
    /// model for response from oauth2 token request to Nest.
    /// </summary>
    public class NestTokenModel
    {
        //recieved from Nest
        public string access_token;
        public long expires_in;

        //written client-side
        public DateTimeOffset timestamp;

    }
}
