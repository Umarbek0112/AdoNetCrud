using ExamProgram.Service.DTOs.Users;
using ExamProgram.Service.Interfaces.Users;
using ExamProgram.Service.Services.Users;
using ExamProgram.Service.Extensions;
using System;
using System.Windows;
using System.Windows.Controls;
using ExamProgram.Domain.Configurations;
using ExamProgram.Service.Interfaces.Hometowns;
using ExamProgram.Service.Services.Hometowns;
using System.Threading.Tasks;

namespace ExamProgram.Packages
{
    /// <summary>
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        IUserService _userService;
        IHometownService _hometownService;
        public AddPage()
        {
            _userService = new UserService();
            _hometownService = new HometownsService();

            InitializeComponent();
        }

        private async void Button_Click_AddUser(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItemCombox = (ComboBoxItem)Combox.SelectedItem;
            UserForCreateDTO user = new UserForCreateDTO()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Email = Email.Text,
                Password = PasswordBox.Password.ToString(),
                PhoneNumber = Phone.Text,
                UserName = Username.Text,
                HometownId = int.Parse((string)selectedItemCombox.Tag)
            };
            await _userService.CreateAsync(user);

            NavigationService.Navigate(new SelectPage());
        }

        private async void LoadedPage(object sender, RoutedEventArgs e)
        {
            PaginationParams paginationParams = new PaginationParams();
            paginationParams.PageSize = 0;
            paginationParams.PageIndex = 0;

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
