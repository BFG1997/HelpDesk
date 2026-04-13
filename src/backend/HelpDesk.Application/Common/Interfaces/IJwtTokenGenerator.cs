using HelpDesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string Generate(User user);
    }
}
