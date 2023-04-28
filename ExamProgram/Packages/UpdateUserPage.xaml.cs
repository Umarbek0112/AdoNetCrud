using ExamProgram.Domain.Configurations;
using ExamProgram.Domain.Entities.Hometowns;
using ExamProgram.Domain.Entities.Users;
using ExamProgram.Service.DTOs.Users;
using ExamProgram.Service.Interfaces.Hometowns;
using ExamProgram.Service.Interfaces.Users;
using ExamProgram.Service.Services.Hometowns;
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

namespace ExamProgram.Packages
{
    /// <summary>
    /// Interaction logic for UpdateUserPage.xaml
    /// </summary>
    public partial class UpdateUserPage : Page
    {
        private readonly IUserService _userService;
        private readonly IHometownService _hometownService;
        public int UserId { get; set; }
        public UpdateUserPage()
        {
            _userService = new UserService();
            _hometownService = new HometownsService();

            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItemCombox = (ComboBoxItem)Combox.SelectedItem;
            UserForUpdateDTO user = new UserForUpdateDTO()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Email = Email.Text,
                Password = PasswordBox.Password.ToString(),
                PhoneNumber = Phone.Text,
                UserName = Username.Text,
                HometownId = int.Parse((string)selectedItemCombox.Tag)
            };
            await _userService.UpdateAsync(UserId, user);

            NavigationService.Navigate(new SelectPage());
        }

        private async void LoadedPage(object sender, RoutedEventArgs e)
        {
            var user = await _userService.GetAsync(UserId);

            PaginationParams paginationParams = new PaginationParams();
            paginationParams.PageSize = 0;
            paginationParams.PageIndex = 0;

            if (user != null)
            {
                LastName.Text = user.LastName.ToString();
                FirstName.Text = user.FirstName.ToString();
                Email.Text = user.Email.ToString();
                PasswordBox.Password = user.Password.ToString();
                Phone.Text = user.PhoneNumber.ToString();
                Username.Text = user.UserName.ToString();
                Combox.Text = user.Hometown.Name.ToString();
            }

            foreach (var t in await _hometownService.GetAllAsync(paginationParams))
            {
                ComboBoxItem combox = new ComboBoxItem()
                {
                    Content = $"{t.Name}",
                    Tag = t.Id.ToString()
                };
                Combox.Items.Add(combox);
            }
        }
    }
}
