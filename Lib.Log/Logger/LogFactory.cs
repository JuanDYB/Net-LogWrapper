using Lib.Log.NLogLogger;
using System;

namespace Lib.Log.Logger
{
    class LogFactory
    {
        public static ILogging GetLogger(Type type)
        {
            return NLogLogging.GetLogService(type);
        }
    }
}
