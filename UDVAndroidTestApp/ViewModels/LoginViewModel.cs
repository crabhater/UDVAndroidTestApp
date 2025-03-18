using CommunityToolkit.Mvvm.ComponentModel;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.Core.Servies.FluentBuilder;
using Microsoft.EntityFrameworkCore;
using UDVAndroidTestApp.Core.Interfaces;

namespace UDVAndroidTestApp.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string login;

        [ObservableProperty]
        private string password;

        public LoginViewModel(IRepositoryManager repoMgr, IImpersonateMgr impMgr) : base(repoMgr, impMgr) { }

        public override void EventsDelete()
        {
            throw new NotImplementedException();
        }

        public override void EventsInit()
        {
            throw new NotImplementedException();
        }

        public override Task LoadData()
        {
            throw new NotImplementedException();
        }

        public async Task LoginAsync()
        {
            var userBuilder = new UserBuilder();
            var user = userBuilder.SetName(this.login)
                                  .SetDescription(this.password)
                                  .Build();

            await repoMgr.UsersRepo.AddAsync(user, CancellationToken.None);

            var users = await repoMgr.UsersRepo.GetInstance().ToListAsync();

            impersonateMgr.CurrentUser = user;
            impersonateMgr.PhoneBook = users;
        }
    }
}
