using GalaSoft.MvvmLight;

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
        public MainViewModel()
        {
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
    }
}