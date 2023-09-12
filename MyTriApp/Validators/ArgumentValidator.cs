using MyTriApp.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace MyTriApp.Validators
{
    public static class ArgumentValidator
    {
        public static T NotNull<T>([NotNull] this T value, string name)
            where T : class
        {
            if (value != null)
            {
                return value;
            }

            throw new ArgumentNullException(name);
        }

        public static T NotFound<T>([NotNull] this T value, string name)
            where T : class
        {
            if (value != null)
            {
                return value;
            }

            throw new NotFoundException(name);
        }
    }
}
