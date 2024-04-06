using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniMVPNetCore
{
    public interface IBackgroundTaskView : IDisposable
    {
        void Show(IWin32Window owner);
    }
}
