using System.Windows.Forms;

namespace MiniMVPNetCore
{
  /// <summary>
  /// Interface to represent main host window. Useful for setting owner on dialogs/message boxes
  /// </summary>
  public interface IMainForm : IWin32Window
  {
  }
}
