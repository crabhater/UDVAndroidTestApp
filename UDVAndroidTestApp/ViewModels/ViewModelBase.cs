using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Interfaces;

namespace UDVAndroidTestApp.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
        protected readonly IRepositoryManager repoMgr;
        protected ViewModelBase(IRepositoryManager repoMgr)
        {
             this.repoMgr = repoMgr;
        }
        public abstract void Init();
    }
}
