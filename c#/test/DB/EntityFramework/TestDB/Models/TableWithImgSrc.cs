using System;
using System.Collections.Generic;

namespace TestDB.Models
{
    public partial class TableWithImgSrc
    {
        public int Id { get; set; }
        public byte[] Img { get; set; }
        public byte[] ImgOut { get; set; }
    }
}
