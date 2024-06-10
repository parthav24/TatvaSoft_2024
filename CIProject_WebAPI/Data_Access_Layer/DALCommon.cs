using Data_Access_Layer.Common;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DALCommon
    {
        private readonly AppDbContext _cIDbContext;

        public DALCommon(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        public async Task<List<DropDown>> CountryListAsync()
        {
            return await _cIDbContext.Country
                .OrderBy(c => c.CountryName)
                .Select(c => new DropDown { Value = c.Id, Text = c.CountryName })
                .ToListAsync();
        }

        public async Task<List<DropDown>> CityListAsync(int countryId)
        {
            return await _cIDbContext.City
                .Where(c => c.CountryId == countryId)
                .OrderBy(c => c.CityName)
                .Select(c => new DropDown { Value = c.Id, Text = c.CityName })
                .ToListAsync();
        }

        public async Task<List<DropDown>> MissionCountryListAsync()
        {
            return await _cIDbContext.Missions
                .Join(
                    _cIDbContext.Country,
                    mission => mission.CountryId,
                    country => country.Id,
                    (mission, country) => new { mission, country.CountryName }
                )
                .Select(mc => new DropDown { Value = mc.mission.CountryId, Text = mc.CountryName })
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<DropDown>> MissionCityListAsync()
        {
            return await _cIDbContext.Missions
                .Join(
                    _cIDbContext.City,
                    mission => mission.CityId,
                    city => city.Id,
                    (mission, city) => new { mission, city.CityName }
                )
                .Select(mc => new DropDown { Value = mc.mission.CityId, Text = mc.CityName })
                .Distinct()
                .ToListAsync();
        }


        public async Task<List<DropDown>> MissionThemeListAsync()
        {
            return await _cIDbContext.MissionTheme
                .Where(mt => !mt.IsDeleted)
                .Select(mt => new DropDown { Value = mt.Id, Text = mt.ThemeName })
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<DropDown>> MissionSkillListAsync()
        {
            return await _cIDbContext.MissionSkill
                .Where(ms => !ms.IsDeleted)
                .Select(ms => new DropDown { Value = ms.Id, Text = ms.SkillName })
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<DropDown>> MissionTitleListAsync()
        {
            return await _cIDbContext.Missions
                .Where(m => !m.IsDeleted)
                .Select(m => new DropDown { Value = m.Id, Text = m.MissionTitle })
                .ToListAsync();
        }
        public string ContactUs(ContactUs contactUs)
        {
            string result = "";
            try
            {
                int mID = _cIDbContext.ContactUs.Max(u => u.Id) + 1;
                contactUs.Id = mID;
                contactUs.CreatedDate = DateTime.Now.ToUniversalTime();
                _cIDbContext.ContactUs.Add(contactUs);
                _cIDbContext.SaveChanges();
                return "We will Reach out you soon..";
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public string AddUserSkill(UserSkills userSkills)
        {
            try
            {               
                int mID = _cIDbContext.UserSkills.Max(u => u.Id) + 1;
                userSkills.Id = mID;
                userSkills.CreatedDate = DateTime.Now.ToUniversalTime();
                userSkills.IsDeleted = false;
                _cIDbContext.UserSkills.Add(userSkills);
                _cIDbContext.SaveChanges();
                return "Save Skill Successfully..";   
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<DropDown> GetUserSkill(int userId)
        {
            List<DropDown> userSkill = new List<DropDown>();
            try
            {
                userSkill = _cIDbContext.UserSkills
                                     .Where(ms => ms.UserId == userId && !ms.IsDeleted)
                                     .OrderByDescending(ms => ms.Id)
                                     .Select(ms => new DropDown
                                     {
                                         Value = ms.Id,
                                         Text = ms.Skill
                                     })
                                     .ToList();   
            }
            catch (Exception)
            {

                throw;
            }
            return userSkill;
        }
    }
}