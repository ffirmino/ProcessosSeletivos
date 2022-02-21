using System;
using System.Reflection;

namespace Webmotors.Service.Services
{
    public abstract class BaseService
    {
        private readonly log4net.ILog _logger;
        protected abstract Type ConcreteType { get; }

        public BaseService()
        {
            _logger = log4net.LogManager.GetLogger(this.ConcreteType);
        }

        public void LogInfo(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                _logger.Info(message);
        }

        public string LogError(Exception ex)
        {
            string errorCode = Math.Abs(Guid.NewGuid().GetHashCode()).ToString();

            _logger.Error($"CODE: {errorCode} => {ex.Message}", ex);

            return errorCode;
        }

        public string LogError(Exception ex, MethodBase methodBase)
        {
            string errorCode = Math.Abs(Guid.NewGuid().GetHashCode()).ToString();

            string errorMethod = string.Empty;
            try
            {
                errorMethod = (methodBase == null ? "" : " - Method: " + methodBase.Name);
            }
            catch { }

            _logger.Error($"CODE: {errorCode} => {ex.Message}", ex);

            return $"{ex.Message} - Error Code: {errorCode} {errorMethod}";
        }

        public string LogError(string message, MethodBase methodBase)
        {
            string errorCode = Math.Abs(Guid.NewGuid().GetHashCode()).ToString();

            string errorMethod = string.Empty;
            try
            {
                errorMethod = (methodBase == null ? "" : " - Method: " + methodBase.Name);
            }
            catch { }

            _logger.Error($"CODE: {errorCode} => {message}");

            return $"{message} - Error Code: {errorCode} {errorMethod}";
        }
    }
}
