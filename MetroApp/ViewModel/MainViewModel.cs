using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MetroApp.Basics;

namespace MetroApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel( IDialogService aDialogs )
        {
            mDialogs = aDialogs;

            if( IsInDesignMode )
            {
                // Code runs in Blend / VS Designer --> create design time data.
                WelcomeText = "Hello Designer!";
            }
            else
            {
                // Code runs "for real"
                WelcomeText = "Hello World!";
            }

            ShowMessageCommand = new RelayCommand( ShowMessage );
        }

        private async void ShowMessage()
        {
            await mDialogs.ShowMessageDialog( "A simple dialog", "This is a profound message." );
        }

        public string WelcomeText
        {
            get
            {
                return mWelcomeText;
            }
            set
            {
                Set( nameof( WelcomeText ), ref mWelcomeText, value );
            }
        }
        private string mWelcomeText;


        public bool WelcomeTextVisible
        {
            get
            {
                return mWelcomeTextVisible;
            }
            set
            {
                Set( nameof( WelcomeTextVisible ), ref mWelcomeTextVisible, value );
            }
        }
        private bool mWelcomeTextVisible = true;

        public RelayCommand ShowMessageCommand { get; private set; }

        private readonly IDialogService mDialogs;
    }
}