using Org.W3c.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDVAndroidTestApp.Core.Interfaces;

namespace UDVAndroidTestApp.Services.Personality
{
    //За такое у меня во дворе в упор стреляют, но я зашиваюсь. Простите пожалуйста
    public static class ImpersonateMgr
    {
        public static IAccount CurrentUser { get; private set; }
        public static IEnumerable<IAccount> PhoneBook { get; private set; }
        public static void LoadData(IEnumerable<IAccount> book)
        {
            PhoneBook = book;
            CurrentUser = book.FirstOrDefault();
        }
    }
}
