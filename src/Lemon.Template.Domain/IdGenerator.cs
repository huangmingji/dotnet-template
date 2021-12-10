using Lemon.Common.Snowflake;

namespace Lemon.Template.Domain
{
    public class IdGenerator
    {
        private static IdWorker idWorker => new IdWorker(1, 1);

        public static long Create()
        {
            return idWorker.NextId();
        }
    }
}
