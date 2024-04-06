using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniMVPNetCore
{
    /// <summary>
    /// Presenter for non-modal view
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPresent
    {
		void Show();

        DialogResult ShowDialog();
    }

	/// <summary>
	/// Presenter for modal view
	/// </summary>
    public interface IPresentDialog : IPresent
    {
        new DialogResult Show();
    }
}
