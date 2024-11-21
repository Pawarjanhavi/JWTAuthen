using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class JobApplication
    {
        public int ApplicationID { get; set; }
        public int JobID { get; set; }
        public int ApplicantID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string CoverLetter { get; set; }

        public JobApplication(int applicationId, int jobId, int applicantId, DateTime applicationDate, string coverLetter)
        {
            ApplicationID = applicationId;
            JobID = jobId;
            ApplicantID = applicantId;
            ApplicationDate = applicationDate;
            CoverLetter = coverLetter;
        }
    }
}
