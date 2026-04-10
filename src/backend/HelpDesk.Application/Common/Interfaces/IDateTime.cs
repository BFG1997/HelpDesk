using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
    }
}
