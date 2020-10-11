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
using Vereinsverwaltung.Model;

namespace Vereinsverwaltung.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for AddMember.xaml
    /// </summary>
    public partial class AddMember : Window
    {
        public AddMember()
        {
            InitializeComponent();
            Loaded += AddMemberWindow_Loaded;
        }

        public void AddMemberWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            DataContext = new Member() { Firstname = "", Lastname = "", Birthdate = "" };
        }

        public void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Repository.GetInstance().AddMember(DataContext as Member);
            Close();
        }

        public void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
