using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinson.Core.Domain.Exceptions
{
    public class AlreadyExistsException() : Exception("L'élément existe déjà.")
    {
    }
}
