using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevices.Entities
{   
    public class MobileDevice
    {
        public int Id { get; set; }
        public string Model { get; set; } = string.Empty;
        public string ClientPhone { get; set; } = string.Empty;
    }
}
