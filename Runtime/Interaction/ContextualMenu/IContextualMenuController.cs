using System.Threading.Tasks;

namespace Virtuademy.SDK.Environments.Interaction
{
    public interface IContextualMenuController
    {
        Task Hide();
        void Setup(IContextualMenuManageable manageable);
        Task Show(IContextualMenuManageable manageable);
        void Unsetup();
    }
}
