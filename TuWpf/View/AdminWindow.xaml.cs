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
using TuWpf.Model;
using TuWpf.ViewModel;

namespace TuWpf.View
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private AdminViewModel _viewModel;
        public AdminWindow(UserRepositoryDb userRepository)
        {
            InitializeComponent();
            _viewModel = new AdminViewModel(userRepository);
            DataContext = _viewModel;
            ListBoxUserNames.ItemsSource = _viewModel.AllUserNames;
        }
    }
}
