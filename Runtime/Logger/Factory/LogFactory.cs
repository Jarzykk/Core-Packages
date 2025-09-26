using System;
using StripedArts.Unity.Core.Logging.Core.Interfaces;

namespace StripedArts.Unity.Core.Logging.Core.Factory
{
    public static class LogFactory
    {
        public static ILogProvider Produce<TClass>(DChannel tag = null) where TClass : class =>
            Logger.Logger.CreateFor<TClass>(tag);

        public static ILogProvider Produce(Type type, DChannel tag = null) =>
            Logger.Logger.CreateFor(type, tag);
    }
}
