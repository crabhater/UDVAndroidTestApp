using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.App.Interfaces;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.ViewModels
{
    public partial class ChatViewModel : ViewModelBase
    {
        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();

        [ObservableProperty]
        private string inputMessage;

        public ChatViewModel(IRepositoryManager repoMgr) : base(repoMgr) 
        {
            // Пример начального сообщения
            Messages.Add(new Message { Content = "Привет! Я ваш робот.", Date = DateTime.Now});
        }
    }
}
