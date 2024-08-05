using System.Reflection;

namespace DocplannerTechTest.Application.Utils
{
    public static class AssemblyUtils
    {
        public static Assembly GetApplicationAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
