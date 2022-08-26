using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogProject.Enums
{
    public enum ReadyStatus
    {
        [Display(Name = "Incomplete")]
        Incomplete,
        [Display(Name = "Production Ready")]
        ProductionReady,
        [Display(Name = "Preview Ready")]
        PreviewReady
    }
}
