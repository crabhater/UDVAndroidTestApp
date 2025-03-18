using Android.Content;
using Android.Views;
using Android;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Data.Models;
using UDVAndroidTestApp.ViewModels;


namespace UDVAndroidTestApp.Adapters
{
    public class ChatListAdapter : BaseAdapter<ChatListItemViewModel>
    {
        private readonly ObservableCollection<ChatListItemViewModel> _chats;
        private readonly Message _lastMessage;
        private readonly Context _context;

        public ChatListAdapter(Context context, ObservableCollection<ChatListItemViewModel> chats)
        {
            _context = context;
            _chats = chats;

            // Подписываемся на изменения коллекции
            _chats.CollectionChanged += (sender, args) =>
            {
                NotifyDataSetChanged(); // Перерисовка UI при изменениях
            };
        }

        public override ChatListItemViewModel this[int position] => _chats[position];

        public override int Count => _chats.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var chat = _chats[position];

            View view = convertView ?? LayoutInflater.From(_context).Inflate(Android.Resource.Layout.SimpleListItem2, parent, false);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = chat.Chat.Title;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text =$"{chat.LastMessage.Sender.User.Name}: { chat.LastMessage.Content} - {chat.LastMessage.Date.Value.ToString("HH:mm")}";

            return view;
        }
    }

}
