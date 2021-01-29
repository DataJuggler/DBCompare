

#region using statements

using System.Windows.Forms;

#endregion

namespace DBCompare.Util
{

    #region MessageBoxHelper
    /// <summary>
    /// This class is used to show a MessageBox with on a Message and a title.
    /// </summary>
    public class MessageBoxHelper
    {
    
        #region Methods

            #region GetUserResponse(string message, string title, MessageBoxButtons buttons = MessageBoxButtons.YesNo, MessageBoxIcon icon = MessageBoxIcon.Question)
            /// <summary>
            /// This method returns the users response (DialogResult) for the message given.
            /// </summary>
            /// <param name="message">The message text to show with the message box.</param>
            /// <param name="title">The title to show (caption) for the message box.</param>
            /// <param name="buttons">The buttons to show with the message. The default value is the 'Ok' button.</param>
            /// <param name="icon">The icon to show with the MessageBox. The default value is the Warning icon.</param>
            public static DialogResult GetUserResponse(string message, string title, MessageBoxButtons buttons = MessageBoxButtons.YesNo, MessageBoxIcon icon = MessageBoxIcon.Question)
            {
                // initial value
                DialogResult result = DialogResult.No;

                // Get the result
                result = MessageBox.Show(message, title, buttons, icon);

                // return value
                return result;
            }
            #endregion

            #region ShowMessage(string message, string title, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Warning)
            /// <summary>
            /// This method shows a MessageBox to the user.
            /// </summary>
            /// <param name="message">The message text to show with the message box.</param>
            /// <param name="title">The title to show (caption) for the message box.</param>
            /// <param name="buttons">The buttons to show with the message. The default value is the 'Ok' button.</param>
            /// <param name="icon">The icon to show with the MessageBox. The default value is the Warning icon.</param>
            public static void ShowMessage(string message, string title, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Warning)
            {
                // Show the message
                MessageBox.Show(message, title, buttons, icon);
            } 
            #endregion
            
        #endregion

    } 
    #endregion
    
}
