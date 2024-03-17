using YamlDotNet.Serialization;

namespace LAC.Models
{
    public class Client
    {
        [YamlMember(Alias = "install")]
        public Install Install { get; set; }
    }

    public class Install
    {
        [YamlMember(Alias = "globals")]
        public Globals Globals { get; set; }
    }

    public class Globals
    {
        [YamlMember(Alias = "locale")]
        public string Locale { get; set; }

        [YamlMember(Alias = "region")]
        public string Region { get; set; }
    }
}