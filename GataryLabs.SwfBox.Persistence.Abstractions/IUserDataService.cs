using GataryLabs.SwfBox.Configuration.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace GataryLabs.SwfBox.Persistence.Abstractions
{
    public interface IUserDataService
    {
        UserSettings Settings { get; set; }
        Task LoadAsync(CancellationToken cancellation);
        Task SaveAsync(CancellationToken cancellation);
    }
}
