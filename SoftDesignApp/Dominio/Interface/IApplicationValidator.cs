using Dominio.ViewModel;

namespace Dominio.Interface
{
    public interface IApplicationValidator
    {
        void ValidateAndThrow(ApplicationViewModel application);
    }
}
