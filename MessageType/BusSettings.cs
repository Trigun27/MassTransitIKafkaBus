using System;

namespace MessageType
{
    public class BusSettings
    {
        public const string SectionName = "Bus";

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ClusterName { get; set; } = "cluster";

        public ushort Port { get; set; } = 5672;

        public string[] Hosts { get; set; }

        public string VirtualHost { get; set; } = "/";

        public string Scheme { get; set; } = "rabbitmq";

        public Uri ClusterUri => new UriBuilder(Scheme, ClusterName) { Path = VirtualHost == "/" ? VirtualHost : VirtualHost + "/" }.Uri;
    }
}

