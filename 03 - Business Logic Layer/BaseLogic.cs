using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBryce
{
    public class BaseLogic : IDisposable
    {
        protected MemoryMatchEntities DB = new MemoryMatchEntities();

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
