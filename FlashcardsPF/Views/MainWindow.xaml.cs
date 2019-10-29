using Flashcards.Lib.Models;
using Flashcards.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlashcardsPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var dataContext = this.DataContext as MainWindowViewModel;
            dataContext.Initialize();
            dataContext.OnStartTest += DataContext_OnStartTest;
        }

        private void DataContext_OnStartTest(object obj)
        {
            var listOfWords = obj as List<Word>;
            var dialog = new TestWindow(listOfWords);
            dialog.Closing += delegate
            {

            };
            dialog.ShowDialog();
        }
    }
}
