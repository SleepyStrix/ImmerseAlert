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
        public Dictionary<string, NestCam> cameras;
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

    public class NestCam
    {
        public string device_id;
        public string software_version;
        public string structure_id;
        public string where_id;
        public string where_name;
        public string name;
        public string name_long;
        public bool is_online;
        public bool is_streaming;
        public bool is_audio_input_enabled;
        public string last_is_online_change;
        public bool is_video_history_enabled;
        public string web_url;
        public string app_url;
        public CamEvent last_event;
    }

    public class CamEvent
    {
        public bool has_sound;
        public bool has_motion;
        public bool has_person;
        public string start_time;
        public string end_time;
        public string urls_expire_time;
        public string web_url;
        public string app_url;
    }
}
