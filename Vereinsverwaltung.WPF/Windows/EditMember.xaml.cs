using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for EditMember.xaml
    /// </summary>
    public partial class EditMember : Window
    {
        Member _editMember;
        readonly Member _member;

        public EditMember(Member member)
        {
            InitializeComponent();
            _member = member;
            Loaded += EditMember_Loaded;
        }

        private void EditMember_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            _editMember = new Member
            {
                Firstname = _member.Firstname,
                Lastname = _member.Lastname,
                Birthdate = _member.Birthdate
            };

            grdMemberFields.DataContext = _editMember;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            _member.Firstname = _editMember.Firstname;
            _member.Lastname = _editMember.Lastname;
            _member.Birthdate = _editMember.Birthdate;

            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
