//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyPortfolio.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Web;

	public partial class TblAbout
	{
		public int AboutId { get; set; }
		public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CvUrl { get; set; }
		[NotMapped]  // Bu alan veritabanưna kaydedilmez
		public HttpPostedFileBase ImageFile { get; set; }
		[NotMapped]  // Bu alan veritabanưna kaydedilmez
		public HttpPostedFileBase CvFile { get; set; }
	}
}
