using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ictshop.DesignPattern.State
{
    public interface IDonhangState
    {
        void Process(Models.Donhang donhang);
    }
}