using NoteApp.ViewModels;
using System.Data.Entity;
using System.Windows;

namespace NoteApp.Views
{
    public partial class MainView : Window
    {
        NoteAppContext context;

        public MainView()
        {
            InitializeComponent();
            context = NoteAppContext.GetInstance();
            context.Notes.Load();
            NotesList.ItemsSource = context.Notes.Local.ToBindingList();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            context.Dispose();
        }
    }
}
