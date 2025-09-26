using StripedArts.Unity.Core.Logging.Core.Extensions;

namespace StripedArts.Unity.Core.Logging.Core
{
    public static partial class DSenders
    {
        public static readonly DChannel System = new(name: "[System]".Red());
        public static readonly DChannel Application = new(name: "[Application]".Green());
        public static readonly DChannel Assets = new(name: "[Assets]".Green());
        public static readonly DChannel GameStateMachine = new(name: "[Game State Machine]".Green());
        public static readonly DChannel SceneData = new(name: "[Scene Data]".Yellow());
        public static readonly DChannel Localization = new(name: "[Localization]".Yellow());
        public static readonly DChannel Game = new(name: "[Game]".Green());
        public static readonly DChannel Analytics = new(name: "[Analytics]".Yellow());
    }
}
