using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDVAndroidTestApp.Core.Interfaces
{
    public interface IObservable
    {
        Task AddObserver(IObserver o);
        Task RemoveObserver(IObserver o);
        Task NotifyObservers();
    }
}
