﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniMVPNetCore
{
    public interface IDialog : IView
    {
        //DialogResult ShowDialog(IWin32Window owner);

        DialogResult DialogResult { get; }
    }
}
