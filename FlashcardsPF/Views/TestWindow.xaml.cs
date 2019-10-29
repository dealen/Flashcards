using Flashcards.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlashcardsPF.Views
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow(List<Flashcards.Lib.Models.Word> listOfWords)
        {
            InitializeComponent();
            var dataContext = this.DataContext as TestViewModel;
            dataContext.Initialzie(listOfWords);
        }
    }
}
