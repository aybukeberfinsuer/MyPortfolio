﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyPortfolioEntities : DbContext
    {
        public MyPortfolioEntities()
            : base("name=MyPortfolioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TblAbout> TblAbouts { get; set; }
        public virtual DbSet<TblBanner> TblBanners { get; set; }
        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblContact> TblContacts { get; set; }
        public virtual DbSet<TblExperience> TblExperiences { get; set; }
        public virtual DbSet<TblExpertis> TblExpertises { get; set; }
        public virtual DbSet<TblMessage> TblMessages { get; set; }
        public virtual DbSet<TblProject> TblProjects { get; set; }
        public virtual DbSet<TblSocialMedia> TblSocialMedias { get; set; }
        public virtual DbSet<TblTestimonial> TblTestimonials { get; set; }
        public virtual DbSet<TblEducation> TblEducations { get; set; }
    }
}
