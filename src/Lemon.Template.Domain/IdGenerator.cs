using Lemon.Common.Snowflake;

namespace Lemon.Template.Domain
{
    public class IdGenerator
    {
        private static IdWorker IdWorker => new(1, 1);

        public static long Create()
        {
            return IdWorker.NextId();
        }
    }
}
