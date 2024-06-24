using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DALCMS
    {
        private readonly AppDbContext _cIDbContext;
        public DALCMS(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        public List<CMS> CMSList()
        {
            List<CMS> cmsList = new List<CMS>();
            try
            {
                cmsList = _cIDbContext.CMS
                    .Where(mt => !mt.IsDeleted)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return cmsList;
        }
        public CMS CMSDetailById(int id)
        {
            CMS cmsDetail = new CMS();
            try
            {
                cmsDetail = _cIDbContext.CMS
                    .FirstOrDefault(m => m.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
            return cmsDetail;
        }
        public string AddCMS(CMS cms)
        {
            string result = "";
            try
            {
                int mID = _cIDbContext.CMS.Max(u => u.Id) + 1;
                cms.Id = mID;
                cms.CreatedDate = DateTime.Now.ToUniversalTime();
                cms.IsDeleted = false;
                _cIDbContext.CMS.Add(cms);
                _cIDbContext.SaveChanges();
                result = "CMS added successfully.";
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public string UpdateCMS(CMS cms)
        {
            string result = "";
            try
            {
                var cmss = _cIDbContext.CMS.FirstOrDefault(m => m.Id == cms.Id);
                cmss.ModifiedDate = DateTime.Now.ToUniversalTime();
                cmss.Status = cms.Status;
                cmss.Slug = cms.Slug;
                cmss.Description = cms.Description;
                cmss.Title = cms.Title;
                _cIDbContext.SaveChanges();
                result = "CMS Updated successfully.";
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public string DeleteCMS(int id)
        {
            try
            {
                var cmsToDelete = _cIDbContext.CMS.FirstOrDefault(s => s.Id == id);
                if (cmsToDelete != null)
                {
                    _cIDbContext.CMS.Remove(cmsToDelete);
                    _cIDbContext.SaveChanges();
                    return "CMS Deleted Successfully";
                }
                else
                {
                    return "CMS not found";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}