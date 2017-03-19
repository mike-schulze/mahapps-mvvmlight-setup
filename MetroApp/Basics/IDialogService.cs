using System.Threading.Tasks;

namespace MetroApp.Basics
{

public interface IDialogService
{
    string ShowFileOpenDialog( string aDescription, string aExtension );

    Task ShowProgressDialog( string aTitle, string aMessage = null );

    /// <summary>
    /// Updates progress for current Progress dialog
    /// </summary>
    /// <param name="aProgress">Progress from 0 to 1, if outside of this range, progress dialog will show indeterminate progress</param>
    /// <param name="aMessage">Progress message</param>
    /// <returns>false if Cancel was pressed</returns>
    bool UpdateProgress( double aProgress, string aMessage = null );
    Task CloseProgressDialog();

    Task ShowMessageDialog( string aTitle, string aMessage );
    Task<bool> ShowOkCancelDialog( string aTitle, string aMessage );
}

}
