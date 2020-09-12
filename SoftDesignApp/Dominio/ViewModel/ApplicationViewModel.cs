using Dominio.Model;

namespace Dominio.ViewModel
{
    public class ApplicationViewModel
    {
        public string Id { get; set; }
        public int Application { get; set; }
        public string Url { get; set; }
        public string PathLocal { get; set; }
        public bool DebuggingMode { get; set; }

        public static explicit operator ApplicationViewModel(ApplicationModel model)
        {
            return new ApplicationViewModel
            {
                Id = model.Id,
                Application = model.Application,
                Url = model.Url,
                PathLocal = model.PathLocal,
                DebuggingMode = model.DebuggingMode
            };
        }
    }
}
