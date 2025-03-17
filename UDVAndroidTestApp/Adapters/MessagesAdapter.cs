using Android.Content;
using Android.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Data.Models;

namespace UDVAndroidTestApp.Adapters
{
    public class MessagesAdapter : BaseAdapter<Message>
    {
        private readonly ObservableCollection<Message> _messages;
        private readonly Context _context;
        public MessagesAdapter(Context context, ObservableCollection<Message> messages)
        {
            _context = context;
            _messages = messages;
        }
        public override Message this[int position] => _messages[position];

        public override int Count => _messages.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var message = _messages[position];

            var view = convertView ?? LayoutInflater.From(_context).Inflate(Resource.Layout.chat_message_item, parent, false);

            var senderTextView = view.FindViewById<TextView>(Resource.Id.senderTextView);
            var contentTextView = view.FindViewById<TextView>(Resource.Id.contentTextView);
            var dateTextView = view.FindViewById<TextView>(Resource.Id.dateTextView);

            senderTextView.Text = "sender"; //message.Sender;
            contentTextView.Text = message.Content;
            dateTextView.Text = message.Date.Value.ToString("HH:mm");

            return view;
        }
    }
}
