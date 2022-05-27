using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;
public class HamsterNotFoundException : NotFoundException
{
    public HamsterNotFoundException(int hamsterId) 
        : base($"The hamster with id: {hamsterId} does not exist in the database.")
    {
    }
}
