using System.ComponentModel.DataAnnotations;

namespace Grid.Domain.Database
{
    [MetadataType(typeof(StaffExtension))]
    public partial class Staff
    {
        private class StaffExtension
        {
            [Required(ErrorMessage = "Required")]
            public string Name { get; set; }
        }
    }
}
