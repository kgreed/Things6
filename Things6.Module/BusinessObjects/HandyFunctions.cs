using System;
using System.Linq;

namespace Things6.Module.BusinessObjects
{
    public static class HandyFunctions
    {
        public static void EnsureDatabaseIsCreated()
        {
            try
            {
                using (var db = new Things6DbContext())
                {
                    var thing= db.Things.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
     
        }
    }
}