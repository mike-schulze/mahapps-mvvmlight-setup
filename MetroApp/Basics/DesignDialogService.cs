using System;
using System.Threading.Tasks;

namespace MetroApp.Basics
{
    public sealed class DesignDialogService : IDialogService
    {
        public Task CloseProgressDialog()
        {
            throw new NotImplementedException();
        }

        public string ShowFileOpenDialog( string aDescription, string aExtension )
        {
            throw new NotImplementedException();
        }

        public Task ShowMessageDialog( string aTitle, string aMessage )
        {
            throw new NotImplementedException();
        }

        public Task<bool> ShowOkCancelDialog( string aTitle, string aMessage )
        {
            throw new NotImplementedException();
        }

        public Task ShowProgressDialog( string aTitle, string aMessage = null )
        {
            throw new NotImplementedException();
        }

        public bool UpdateProgress( double aProgress, string aMessage = null )
        {
            throw new NotImplementedException();
        }
    }
}
