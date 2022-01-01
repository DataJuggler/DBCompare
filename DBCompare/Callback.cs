using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCompare
{

    #region delegate void Callback(string message, int value);
    /// <summary>
    /// This delegate is used to send messages back to the MainForm
    /// about progress during a Comparison.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="value"></param>
    public delegate void Callback(string message, int value);
    #endregion

}
