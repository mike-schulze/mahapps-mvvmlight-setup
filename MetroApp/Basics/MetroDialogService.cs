using System;
using System.Threading.Tasks;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace MetroApp.Basics
{

public class MetroDialogService : IDialogService
{
    public
    MetroDialogService
        (
        MetroWindow aDialog
        )
    {
        mMetroWindow = aDialog;
    }

    public string
    ShowFileOpenDialog
        (
        string aDescription,
        string aExtension
        )
    {
        var theDialog = new Microsoft.Win32.OpenFileDialog
        {
            Filter = String.Format( "{0}|{1}", aDescription, aExtension ),
            DefaultExt = aExtension,
            Multiselect = false
        };

        var theResult = theDialog.ShowDialog();
        if( theResult ?? false )
        {
            if( !String.IsNullOrWhiteSpace( theDialog.FileName ) )
            {
                return theDialog.FileName;
            }
        }

        return null;
    }

    public async Task ShowProgressDialog
        (
        string aTitle,
        string aMessage = null
        )
    {
        var theSettings = new MetroDialogSettings();
        theSettings.AnimateShow = true;
        theSettings.AnimateHide = false;

        mProgressController = await mMetroWindow.ShowProgressAsync( aTitle, aMessage != null ? aMessage : String.Empty, true, theSettings );
    }

    public bool
    UpdateProgress
        (
        double aProgress,
        string aMessage = null
        )
    {
        if( mProgressController == null )
        {
            return false;
        }

        if( mProgressController.IsCanceled )
        {
            return false;
        }

        if( aProgress >=0 && aProgress <= 1 )
        {
            mProgressController.SetProgress( aProgress );
        }
        else
        {
            mProgressController.SetIndeterminate();
        }
        
        if( aMessage != null )
        {
            mProgressController.SetMessage( aMessage );
        }

        return true;
    }

    public async Task
    CloseProgressDialog
        (
        )
    {
        if( mProgressController == null )
        {
            return;
        }

        await mProgressController.CloseAsync();
    }

    public async Task
    ShowMessageDialog
        (
        string aTitle,
        string aMessage
        )
    {
        var theSettings = new MetroDialogSettings();
        theSettings.AnimateShow = false;
        theSettings.AnimateHide = true;


        await mMetroWindow.ShowMessageAsync( aTitle, aMessage, MessageDialogStyle.Affirmative, theSettings );
    }

    public async Task<bool> ShowOkCancelDialog( string aTitle, string aMessage )
    {
        var theResult = await mMetroWindow.ShowMessageAsync( aTitle, aMessage, MessageDialogStyle.AffirmativeAndNegative );
        return theResult == MessageDialogResult.Affirmative;
    }


    private ProgressDialogController mProgressController;
    private readonly MetroWindow mMetroWindow;
}
}
