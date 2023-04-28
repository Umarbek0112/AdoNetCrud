using ExamProgram.Domain.Configurations;
using ExamProgram.Domain.Entities.Users;
using ExamProgram.Service.Interfaces.Users;
using ExamProgram.Service.Services.Users;
using ExamProgram.UserControlle;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ExamProgram.Packages
{
    /// <summary>
    /// Interaction logic for SelectPage.xaml
    /// </summary>
    public partial class SelectPage : Page
    {
        private readonly IUserService _userService;
        public SelectPage()
        {
            _userService = new UserService();

            InitializeComponent();
        }

        private async void PageLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            PaginationParams paginationParams = new PaginationParams();
            paginationParams.PageSize = 10;
            paginationParams.PageIndex = 0;

            UsercontrolofSet.Items.Clear();
            var get = await _userService.GetAllAsync(paginationParams);

            foreach (var user in get)
            {
                UpdateUserPage update = new UpdateUserPage();
                UserController Control = new UserController();
                Control.UserId = user.Id;
               // Control.UpdateBtn.Content = user.Id;
                Control.UpdateBtn.CommandParameter = user.Id.ToString();
                Control.TextBlockUsername.Text = $"{user.FirstName} {user.LastName}";
                Control.UpdateBtn.Click += UpdateBtn_Click;

                UsercontrolofSet.Items.Add(Control);
            }
        }

        private async void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
           UpdateUserPage updateUserPage = new UpdateUserPage()
            {
                UserId = int.Parse((sender as Button).CommandParameter.ToString()),
            };

            MainFrame.Content = updateUserPage;           
         }
    }
}
