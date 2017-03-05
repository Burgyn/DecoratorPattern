using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Helpers
{
    [DebuggerStepThrough]
    internal static class Check
    {
        /// <summary>
        /// Check if parameter is not null.
        /// </summary>
        /// <param name="param">The parameter which checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentNullException">if param is null.</exception>
        public static void NotNull(object param, string paramName)
        {
            if (param == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Check if parameter is not null.
        /// </summary>
        /// <param name="param">The parameter which checked.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <exception cref="System.ArgumentNullException">if param is null.</exception>
        public static void NotNullOrWhiteSpace(string param, string paramName)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
