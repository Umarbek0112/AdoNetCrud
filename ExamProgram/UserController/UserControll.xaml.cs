using ExamProgram.Domain.Entities.Users;
using ExamProgram.Service.Interfaces.Users;
using ExamProgram.Service.Services.Users;
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

namespace ExamProgram.UserControlle
{
    /// <summary>
    /// Interaction logic for UserController.xaml
    /// </summary>
    public partial class UserController : UserControl
    {
        private readonly IUserService _userService;
        public int UserId { get; set; }
        public UserController()
        {
            _userService = new UserService();
            InitializeComponent();
        }

        private void Button_Click_Delette(object sender, RoutedEventArgs e)
        {

            _userService.DeleteAsync(UserId);
            var nextAction = MessageBox.Show("O'chirildi");
        }

        private void MyCommandExecute(object parameter)
        {
            int id = (int)UserId;
        }
    }
}
