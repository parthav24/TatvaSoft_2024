using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Common;
using Data_Access_Layer.Repository;
using Microsoft.EntityFrameworkCore;
using Data_Access_Layer.Migrations;
using Data_Access_Layer.Repository.Entities;

namespace Data_Access_Layer
{
    public class DALVolunteeringTimesheet
    {
        private readonly AppDbContext _cIDbContext;
        public DALVolunteeringTimesheet(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        public List<VolunteeringHours> GetVolunteeringHoursList(int userId)
        {
            List<VolunteeringHours> volunteeringHours = new List<VolunteeringHours>();
            try
            {
                volunteeringHours = _cIDbContext.VolunteeringHours
                .Where(mt => mt.UserId == userId && !mt.IsDeleted)
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return volunteeringHours;
        }
        public VolunteeringHours GetVolunteeringHoursListById(int id)
        {
            VolunteeringHours volunteeringHours = new VolunteeringHours();
            try
            {
                volunteeringHours = _cIDbContext.VolunteeringHours
                .FirstOrDefault(m => m.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
            return volunteeringHours;
        }
        public string AddVolunteeringHours(VolunteeringHours volunteeringHours)
        {
            string result = "";

            try
            {
                int mID = _cIDbContext.VolunteeringHours.Max(u => u.Id) + 1;
                volunteeringHours.Id = mID;
                volunteeringHours.CreatedDate = DateTime.Now.ToUniversalTime();
                volunteeringHours.IsDeleted = false;
                _cIDbContext.VolunteeringHours.Add(volunteeringHours);
                _cIDbContext.SaveChanges();
                result = "VolunteeringHours added successfully.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public List<DropDown> VolunteeringMissionList(int userId)
        {
            List<DropDown> missionTitleList = new List<DropDown>();
            try
            {
                missionTitleList = _cIDbContext.Missions
                    .Where(m => !m.IsDeleted)
                    .Join(_cIDbContext.MissionApplication.Where(ma => ma.Status && ma.UserId == userId),
                          m => m.Id,
                          ma => ma.MissionId,
                          (m, ma) => new DropDown
                          {
                              Text = m.MissionTitle,
                              Value = m.Id
                          })
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return missionTitleList;
        }
        public string UpdateVolunteeringHours(VolunteeringHours volunteeringHours)
        {
            string result = "";

            try
            {
                var volunteeringhourss = _cIDbContext.VolunteeringHours.FirstOrDefault(m => m.Id == volunteeringHours.Id);
                volunteeringhourss.ModifiedDate = DateTime.Now.ToUniversalTime();
                volunteeringhourss.Hours = volunteeringHours.Hours;
                volunteeringhourss.Minutes = volunteeringHours.Minutes;
                volunteeringhourss.Message = volunteeringHours.Message;
                volunteeringhourss.DateVolunteered = volunteeringHours.DateVolunteered;
                _cIDbContext.SaveChanges();
                result = "VolunteeringHours Updated successfully.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public string DeleteVolunteeringHours(int id)
        {
            try
            {
                string result = "";
                var volunteeringhours = _cIDbContext.VolunteeringHours.FirstOrDefault(m => m.Id == id);
                if (volunteeringhours != null)
                {
                    volunteeringhours.IsDeleted = true;
                    _cIDbContext.SaveChanges();
                    result = "Delete VolunteeringHours Detail Successfully.";
                }
                else
                {
                    result = "VolunteeringHours not found.";
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<VolunteeringGoals> GetVolunteeringGoalsList(int userId)
        {
            List<VolunteeringGoals> volunteeringGoals = new List<VolunteeringGoals>();
            try
            {
                volunteeringGoals = _cIDbContext.VolunteeringGoals
               .Where(mt => mt.UserId == userId && !mt.IsDeleted)
               .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return volunteeringGoals;
        }
        public VolunteeringGoals GetVolunteeringGoalsListById(int id)
        {
            VolunteeringGoals volunteeringGoals = new VolunteeringGoals();
            try
            {
                volunteeringGoals = _cIDbContext.VolunteeringGoals
                .FirstOrDefault(m => m.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
            return volunteeringGoals;
        }
        public string AddVolunteeringGoals(VolunteeringGoals volunteeringGoals)
        {
            string result = "";

            try
            {
                int mID = _cIDbContext.VolunteeringGoals.Max(u => u.Id) + 1;
                volunteeringGoals.Id = mID;
                volunteeringGoals.CreatedDate = DateTime.Now.ToUniversalTime();
                volunteeringGoals.IsDeleted = false;
                _cIDbContext.VolunteeringGoals.Add(volunteeringGoals);
                _cIDbContext.SaveChanges();
                result = "VolunteeringGoals added successfully.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public string UpdateVolunteeringGoals(VolunteeringGoals volunteeringGoals)
        {
            string result = "";

            try
            {
                var volunteeringGoalss = _cIDbContext.VolunteeringGoals.FirstOrDefault(m => m.Id == volunteeringGoals.Id);
                volunteeringGoalss.ModifiedDate = DateTime.Now.ToUniversalTime();
                volunteeringGoalss.Action = volunteeringGoals.Action;
                volunteeringGoalss.Date = volunteeringGoals.Date;
                volunteeringGoalss.Message = volunteeringGoals.Message;
                _cIDbContext.SaveChanges();
                result = "VolunteeringGoals Updated successfully.";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public string DeleteVolunteeringGoals(int id)
        {
            try
            {
                string result = "";
                var volunteeringgoals = _cIDbContext.VolunteeringGoals.FirstOrDefault(m => m.Id == id);
                if (volunteeringgoals != null)
                {
                    volunteeringgoals.IsDeleted = true;
                    _cIDbContext.SaveChanges();
                    result = "Delete VolunteeringGoals Detail Successfully.";
                }
                else
                {
                    result = "VolunteeringGoals not found.";
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}