using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#if WITH_DOCUMENTS
    using System.Text;
#endif

namespace TestQuery.Models
{
    public class Job
    {
        [Key]
        public int JobID { get; set; }
        public string Name { get; set; }

        public virtual IList<Document> Documents { get; set; }

        public override string ToString()
        {
            #if WITH_DOCUMENTS

            var documents = new StringBuilder("Documents: {");

            for (var i = 0; i < Documents.Count; ++i)
            {
                documents.Append(Documents[i]);

                if (i < Documents.Count)
                    documents.Append(", ");
            }

            documents.Append("}");
            #endif

            return string.Format(
                #if WITH_DOCUMENTS
                    "{{JobID: {0}, {1}}}"
                #else
                    "{{JobID: {0}}}"
                #endif
                ,JobID
                #if WITH_DOCUMENTS
                    ,documents
                #endif
            );
        }
    }
}
