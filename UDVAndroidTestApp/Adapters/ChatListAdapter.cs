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


namespace UDVAndroidTestApp.Adapters
{
    public class ChatListAdapter : BaseAdapter<Chat>
    {
        private readonly ObservableCollection<Chat> _chats;
        private readonly Context _context;

        public ChatListAdapter(Context context, ObservableCollection<Chat> chats)
        {
            _context = context;
            _chats = chats;
        }

        public override Chat this[int position] => _chats[position];

        public override int Count => _chats.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var chat = _chats[position];

            // Создаем/переиспользуем элемент списка
            View view = convertView ?? LayoutInflater.From(_context).Inflate(Android.Resource.Layout.SimpleListItem2, parent, false);

            // Устанавливаем текст для названия чата и последнего сообщения
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = chat.Title;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = $"{chat} ({chat.Id})";

            return view;
        }
    }

}
