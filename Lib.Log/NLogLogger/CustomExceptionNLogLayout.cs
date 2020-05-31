using NLog;
using NLog.LayoutRenderers;
using System.Text;

namespace Lib.Log.NLogLogger
{
    [LayoutRenderer("customException")]
    internal class CustomExceptionNLogLayout : ExceptionLayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            base.Append(builder, logEvent);

            if (builder.Length >= 4000)
            {
                builder.Replace("   ", "");
                builder.Replace("en ", "@");
                builder.Replace("System.Data.Entity", "EF");
                builder.Replace("--- Fin del seguimiento de la pila de la excepción interna ---", "-EndInnerEx-");
                builder.Replace("--->", ">");

                if (builder.Length >= 4000)
                {
                    builder.Length = 3999;
                }
            }

        }
    }
}
