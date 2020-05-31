using System;
using System.Collections.Generic;

namespace Lib.Log.Logger
{
    public interface ILogging
    {
        /// <summary>
        /// Set device property to log with this logger
        /// </summary>
        /// <param name="device"></param>
        /// <param name="oneTime">Use device property one time and delte after first log. Default: true</param>
        /// <returns></returns>
        ILogging WithDevice(string device, bool oneTime = true);

        /// <summary>
        /// Set devices property to log with this logger
        /// </summary>
        /// <param name="devices"></param>
        /// <param name="oneTime">Use device property one time and delte after first log. Default: true</param>
        /// <returns></returns>
        ILogging WithDevice(string[] devices, bool oneTime = true);

        /// <summary>
        /// Set properties to log with this logger
        /// </summary>
        /// <param name="props"></param>
        /// <param name="oneTime">Use properties one time and delte after first log. Default: true</param>
        /// <returns></returns>
        ILogging WithProperties(Dictionary<object, object> props, bool oneTime = true);

        void Debug(Exception exception);
        void Debug(string format, params object[] args);
        void Debug(Exception exception, string format, params object[] args);

        void Error(Exception exception);
        void Error(string format, params object[] args);
        void Error(Exception exception, string format, params object[] args);

        void Fatal(Exception exception);
        void Fatal(string format, params object[] args);
        void Fatal(Exception exception, string format, params object[] args);

        void Info(Exception exception);
        void Info(string format, params object[] args);
        void Info(Exception exception, string format, params object[] args);

        void Trace(Exception exception);
        void Trace(string format, params object[] args);
        void Trace(Exception exception, string format, params object[] args);

        void Warn(Exception exception);
        void Warn(string format, params object[] args);
        void Warn(Exception exception, string format, params object[] args);
    }
}
