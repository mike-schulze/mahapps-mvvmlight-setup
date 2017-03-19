using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using MahApps.Metro.Controls;

namespace MetroApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            // need to register ourselves as default MetroWindow for dialogs
            SimpleIoc.Default.Register<MetroWindow>( () => this );

            InitializeComponent();
        }
    }
}
