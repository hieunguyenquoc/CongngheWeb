namespace WebLinhPhuKienMayTinh.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class NEWS
    {
        public int newsID { get; set; }

        [StringLength(255)]
        public string newsTitle { get; set; }

        [StringLength(255)]
        public string newsImg { get; set; }

        [Column(TypeName = "ntext")]
        [AllowHtml]
        public string newsContent { get; set; }

        [StringLength(255)]
        public string newsType { get; set; }
    }
}
