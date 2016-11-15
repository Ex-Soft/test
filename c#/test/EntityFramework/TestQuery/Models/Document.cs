using System;
using System.ComponentModel.DataAnnotations;

namespace TestQuery.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public int JobId { get; set; }
        public int DocumentTypeId { get; set; }
        public int DocumentStatus { get; set; }

        public virtual Job Job { get; set; }

        public override string ToString()
        {
            return string.Format("{{DocumentId: {0}, DocumentTypeId: {1}, DocumentStatus: {2}}}", DocumentId, DocumentTypeId, DocumentStatus);
        }
    }
}
