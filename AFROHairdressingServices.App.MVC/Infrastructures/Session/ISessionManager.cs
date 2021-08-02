using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.App.MVC.Infrastructures.Session
{
    public interface ISessionManager
    {
        UserSession User { get; set; }
        void Clear();
    }
}
