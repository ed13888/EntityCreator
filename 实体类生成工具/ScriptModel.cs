using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 实体类生成工具
{
    public class ScriptModel
    {
        public string field { get; set; }
        public string type { get; set; }
        public int @byte { get; set; }
        public int precision { get; set; }
        public int scale { get; set; }
        public bool isnull { get; set; }
        public bool isidentity { get; set; }
        public bool ispk { get; set; }
        public string @default { get; set; }
        public string @value { get; set; }
    }
}
