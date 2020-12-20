using System;
using System.Collections.Generic;

namespace Stackoverflow.Website.ViewModels
{
    public class CompanyDetailViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortQuote { get; set; }
        public string LongDescription { get; set; }
        public string LogoFileName { get; set; }
        public string TechStack { get; set; }
        public string OfficeLocation { get; set; }
        public string WebsiteUrl { get; set; }
        public bool CanModifyCompany { get; set; }
        public int Size { get; set; }
        public string Industry { get; set; }
        public DateTime Founded { get; set; }
        public int OpenedJobs { get; set; }

        public IEnumerable<JobDetailsViewModel> JobOpenings { get; set; }
    }
}
