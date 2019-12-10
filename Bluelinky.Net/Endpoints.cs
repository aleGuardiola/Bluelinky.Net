using System;
using System.Collections.Generic;
using System.Text;

namespace Bluelinky.Net
{
    public static class Endpoints
    {
        public const string GetToken = "/etc/designs/ownercommon/us/token.json?reg=";
        public const string ValidateToken = "/libs/granite/csrf/token.json";
        public const string Auth = "/bin/common/connectCar";
        public const string RemoteAction = "/bin/common/remoteAction";
        public const string UsageStats = "/bin/common/usagestats";
        public const string Health = "/bin/common/VehicleHealthServlet";
        public const string MessageCenter = "/bin/common/MessageCenterServlet";
        public const string MyAccount = "/bin/common/MyAccountServlet";
        public const string Status = "/bin/common/enrollmentFeature";
        public const string EnrollmentStatus = "/bin/common/enrollmentStatus";
        public const string Subscriptions = "/bin/common/managesubscription";
    }
}
