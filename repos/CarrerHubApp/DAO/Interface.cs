using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAO
{
    public interface Apply
    {
        void Apply(int applicantID, int jobID, string coverLetter);

    }
    public interface GetApplicants
    {
        List<Applicant> GetApplicants(int jobID);
    }


    public interface PostJob
    {
        void PostJob(string jobTitle, string jobDescription, string jobLocation, decimal salary, string jobType, int companyID);

    }

    public interface GetJobs
    {
        List<JobListing> GetJobs(int companyID);
    }
    public interface CreateProfile
    {
        void CreateProfile(string email, string firstName, string lastName, string phone);
    }

    public interface ApplyForJob
    {
        void ApplyForJob(int jobID, string coverLetter);
    }



}
