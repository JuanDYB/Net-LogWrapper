using Lib.Log.Logger;
using NLog;
using System;
using System.Collections.Generic;

namespace Lib.Log.NLogLogger
{
    class NLogLogging : ILogging
    {
        private readonly Type type;
        private readonly NLog.Logger logger;

        private string _device;
        private bool _deviceReset = true;

        private Dictionary<object, object> _props;
        private bool _propsReset;

        public static ILogging GetLogService(Type type)
        {
            NLogLogging logger = new NLogLogging(type);
            return logger;
        }

        private NLogLogging(Type type)
        {
            this.logger = NLog.LogManager.GetLogger(type.FullName);
            this.type = type;
        }

        #region Debug
        public void Debug(Exception exception, string format, params object[] args)
        {
            LogEventInfo _lovEvt = this.GetLogEvent(type.FullName, LogLevel.Debug, exception, format, args);
            logger.Log(typeof(NLogLogging), _lovEvt);
        }

        public void Debug(string format, params object[] args)
        {
            Debug(null, format, args);
        }

        public void Debug(Exception exception)
        {
            Debug(exception, String.Empty);
        }
        #endregion

        #region Error
        public void Error(Exception exception, string format, params object[] args)
        {
            LogEventInfo _lovEvt = this.GetLogEvent(type.FullName, LogLevel.Error, exception, format, args);
            logger.Log(typeof(NLogLogging), _lovEvt);
        }

        public void Error(string format, params object[] args)
        {
            Error(null, format, args);
        }

        public void Error(Exception exception)
        {
            Error(exception, String.Empty);
        }
        #endregion

        #region Fatal
        public void Fatal(Exception exception, string format, params object[] args)
        {
            LogEventInfo _lovEvt = this.GetLogEvent(type.FullName, LogLevel.Fatal, exception, format, args);
            logger.Log(typeof(NLogLogging), _lovEvt);
        }

        public void Fatal(string format, params object[] args)
        {
            Fatal(null, format, args);
        }

        public void Fatal(Exception exception)
        {
            Fatal(exception, String.Empty);
        }
        #endregion

        #region Info
        public void Info(Exception exception, string format, params object[] args)
        {
            LogEventInfo _lovEvt = this.GetLogEvent(type.FullName, LogLevel.Info, exception, format, args);
            logger.Log(typeof(NLogLogging), _lovEvt);
        }

        public void Info(string format, params object[] args)
        {
            Info(null, format, args);
        }

        public void Info(Exception exception)
        {
            Info(exception, String.Empty);
        }
        #endregion

        #region Trace
        public void Trace(Exception exception, string format, params object[] args)
        {
            LogEventInfo _lovEvt = this.GetLogEvent(type.FullName, LogLevel.Trace, exception, format, args);
            logger.Log(typeof(NLogLogging), _lovEvt);
        }
        public void Trace(string format, params object[] args)
        {
            Trace(null, format, args);
        }
        public void Trace(Exception exception)
        {
            Trace(exception, String.Empty);
        }
        #endregion

        #region Warn
        public void Warn(Exception exception, string format, params object[] args)
        {
            LogEventInfo _lovEvt = this.GetLogEvent(type.FullName, LogLevel.Warn, exception, format, args);
            logger.Log(typeof(NLogLogging), _lovEvt);
        }
        public void Warn(string format, params object[] args)
        {
            Warn(null, format, args);
        }

        public void Warn(Exception exception)
        {
            Warn(exception, String.Empty);
        }
        #endregion

        public ILogging WithDevice(string device, bool oneTime = true)
        {
            this._device = device;
            _deviceReset = oneTime;
            return this;
        }

        public ILogging WithDevice(string[] devices, bool oneTime = true)
        {
            this._device = String.Join("#", devices);
            _deviceReset = oneTime;
            return this;
        }

        public ILogging WithProperties(Dictionary<object, object> props, bool oneTime = true)
        {
            this._props = props;
            _propsReset = oneTime;
            return this;
        }

        public LogEventInfo GetLogEvent(string loggerName, LogLevel level, Exception exception, string format, object[] args)
        {
            LogEventInfo _logEvent = new LogEventInfo(level, loggerName, format);
            _logEvent.Exception = exception;
            _logEvent.Parameters = args;

            if (!String.IsNullOrEmpty(_device))
            {
                _logEvent.Properties["Device"] = _device;
                if (_deviceReset) _device = null;
            }

            if (_props != null && _props.Count > 0)
            {
                foreach (KeyValuePair<object, object> _prop in _props)
                {
                    _logEvent.Properties[_prop.Key] = _prop.Value;
                }
                if (_propsReset) _props = null;
            }

            return _logEvent;
        }
    }
}
