using GataryLabs.SwfBox.Persistence.Abstractions.Models;
using System.Threading;
using System.Threading.Tasks;

namespace GataryLabs.SwfBox.Persistence.Abstractions
{
    public interface ILibraryDataService
    {
        public LibraryFileData LibraryData { get; set; }
        Task LoadAsync(CancellationToken cancellation);
        Task SaveAsync(CancellationToken cancellation);
    }
}
