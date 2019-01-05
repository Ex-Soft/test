using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestMasterDetail.Models
{
    [Serializable]
    public partial class Master
    {
        private readonly ObservableListSource<Detail> _details = new ObservableListSource<Detail>();

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Val { get; set; }

        public virtual ObservableListSource<Detail> Details { get { return _details; } }
    }
}
