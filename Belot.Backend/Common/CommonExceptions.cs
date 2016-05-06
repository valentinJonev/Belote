using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belot.Backend.Common
{
    public class EntityNotFoundException : Exception
    {
    }

    public class ValidationFailedException : InvalidOperationException
    {
        public ValidationFailedException(IList<string> validationErrors)
            : base()
        {
            ValidationErrors = validationErrors;
        }

        public IList<string> ValidationErrors { get; private set; }
    }

    public class ResourceForbiddenException : Exception
    {
    }
}
