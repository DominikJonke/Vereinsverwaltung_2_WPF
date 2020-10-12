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
using Vereinsverwaltung.Model;
using Vereinsverwaltung.Wpf.Windows;

using MahApps.Metro.Controls;

namespace Vereinsverwaltung.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private List<Member> _member;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Repository repo = Repository.GetInstance();
            _member = repo.GetAllMembers();
            lbxMembers.ItemsSource = _member;

            btnNew.Click += BtnNew_Click;
            btnDelete.Click += BtnDelete_Click;
            btnEdit.Click += BtnEdit_Click;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            AddMember addMember = new AddMember();
            addMember.ShowDialog();

            _member = Repository.GetInstance().GetAllMembers();
            lbxMembers.ItemsSource = _member;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(!(lbxMembers.SelectedItem is Member selectedMember))
            {
                MessageBox.Show("Kein Mitglied ausgewählt!");
                return;
            }

            Repository.GetInstance().DeletMember(selectedMember);

            Repository repo = Repository.GetInstance();
            _member = repo.GetAllMembers();
            lbxMembers.ItemsSource = _member;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(lbxMembers.SelectedItem is Member memberToEdit)
            {
                EditMember editMember = new EditMember(memberToEdit);
                editMember.ShowDialog();

                Repository repo = Repository.GetInstance();
                _member = repo.GetAllMembers();
                lbxMembers.ItemsSource = _member;
            }

            else
            {
                MessageBox.Show("Kein Mitglied ausgewählt!");
            }
        }
    }
}
