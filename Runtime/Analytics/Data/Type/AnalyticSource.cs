namespace Infrastructure.Services.Analytics.Data
{
    public enum AnalyticSource
    {
        ///<summary>
        /// Error case
        /// </summary>
        None = 0,

        ///<summary>
        /// For sending events to all sources
        /// </summary>
        All = 1,

        ///<summary>
        /// This is a custom source for testing purposes
        /// </summary>
        Simulated = 2,

        Firebase = 3,
        Facebook = 4,
        AppFlyer = 5,
    }
}
