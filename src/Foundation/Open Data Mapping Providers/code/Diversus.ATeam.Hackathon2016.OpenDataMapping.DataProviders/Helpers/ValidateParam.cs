using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Diversus.ATeam.Hackathon2016.OpenDataMapping.DataProviders.Helpers
{
    public static class ValidateParam
    {
        /// <summary>
        /// Check a string value is null or empty.
        /// </summary>
        /// <typeparam name="T">The type as defined by the function.</typeparam>
        /// <param name="expr">The expression to verify.</param>
        public static void IsNotNullOrEmpty<T>(Expression<Func<T>> expr)
        {
            object result = expr.Compile().Invoke();
            var parameterName = (GetName(expr));
            if (result == null || result.ToString() == string.Empty) { throw new ArgumentException(parameterName, string.Format("{0} must not be empty or null", parameterName)); }
        }

        /// <summary>
        /// Helper method to get the name from and expression.
        /// </summary>
        /// <typeparam name="T">The type as defined by the function.</typeparam>
        /// <param name="expr">The expression to extract the param name from.</param>
        /// <returns>The string name of the field.</returns>
        private static string GetName<T>(Expression<Func<T>> expr)
        {
            var body = expr.Body as MemberExpression;

            return body != null ? body.Member.Name : string.Empty;
        }
    }
}
