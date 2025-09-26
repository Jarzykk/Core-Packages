using System;
using System.Collections.Generic;
using System.Linq;

namespace StripedArts.Unity.Core.Logging.Core
{
    public static class LogExtensions
    {
        public static string ToLogString(this Exception exception) => ToFormattedString(exception);

        private static string ToFormattedString(this Exception exception) =>
            string.Join(Environment.NewLine, exception
                .GetAllExceptions()
                .Where(e => !string.IsNullOrWhiteSpace(e.Message))
                .Select(e => $"{e.Message.Trim()}\r\n\t{e.StackTrace}"));

        private static IEnumerable<Exception> GetAllExceptions(this Exception exception)
        {
            while (true)
            {
                yield return exception;

                if (exception is AggregateException aggregateException)
                {
                    foreach (var internalExtension in aggregateException.InnerExceptions.SelectMany(e => e.GetAllExceptions()))
                        yield return internalExtension;
                }
                else if (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                    continue;
                }

                break;
            }
        }
    }
}
