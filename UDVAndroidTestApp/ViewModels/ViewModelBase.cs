using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.Core.Interfaces;

namespace UDVAndroidTestApp.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
        protected readonly IRepositoryManager repoMgr;
        protected readonly IImpersonateMgr impersonateMgr;
        protected ViewModelBase(IRepositoryManager repoMgr, IImpersonateMgr mgr)
        {
             this.repoMgr = repoMgr;
            impersonateMgr = mgr;   
        }
        public abstract void EventsInit();
        public abstract void EventsDelete();
        public abstract Task LoadData();
    }
}
