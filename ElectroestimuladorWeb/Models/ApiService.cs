using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectroestimuladorWeb
{
    public class ApiService
    {   
        public string usr { get; set; }
        public string pwd { get; set; }
        public string usrName { get; set; }
        public JArray jsonUsuario { get; set; }

    }
}