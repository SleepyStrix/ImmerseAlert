using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmerseAlert.Models
{
    public class JSON
    {
        public Devices devices;
    }

    public class Devices
    {
        public Dictionary<string, NestProtect> smoke_co_alarms;
    }

    public class NestProtect
    {
        public string name;
        public string local;
        public string structure_id;
        public string software_version;
        public string where_id;
        public string device_id;
        public string where_name;
        public string name_long;
        public bool is_online;
        public string battery_health;
        public string co_alarm_state;
        public string smoke_alarm_state;
        public string ui_color_state;
        public bool is_manual_test_active;
        public string last_manual_test_time;
    }
}
