using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.Core.Interfaces;
using UDVAndroidTestApp.Core.Servies.FluentBuilder;

namespace UDVAndroidTestApp.ViewModels
{
    public partial class UserCreationViewModel : ViewModelBase
    {
        public UserCreationViewModel(IRepositoryManager repoMgr, IImpersonateMgr impMgr) : base(repoMgr, impMgr)
        {
        }

        [ObservableProperty]
        public string userName;

        [ObservableProperty]
        public string userDescr;

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

        [RelayCommand]
        public async Task CreateUser()
        {
            if (string.IsNullOrEmpty(userName))
            {
                return;
            }

            var builder = new UserBuilder();
            var user = builder.SetName(userName)
                              .SetDescription(userDescr)
                              .Build(); 

            await repoMgr.UsersRepo.AddAsync(user, CancellationToken.None);
        }
    }
}
