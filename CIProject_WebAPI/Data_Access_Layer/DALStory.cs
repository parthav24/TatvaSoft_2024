using Data_Access_Layer.Common;
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
    public class DALStory
    {
        private readonly AppDbContext _cIDbContext;

        public DALStory(AppDbContext ciDbContext)
        {
            _cIDbContext = ciDbContext;
        }
        public List<DropDown> GetMissionTitle()
        {
            try
            {
                var missionTitleList = _cIDbContext.Missions
                    .Where(m => !m.IsDeleted)
                    .Select(m => new DropDown
                    {
                        Text = m.MissionTitle,
                        Value = m.Id
                    })
                    .ToList();

                return missionTitleList;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch mission titles.", ex);
            }
        }

        public string AddStory(Story story)
        {
            string result = "";
            try
            {
                story.IsActive = false;

                int mID = _cIDbContext.Story.Max(u => u.Id) + 1;
                story.Id = mID;
                _cIDbContext.Story.Add(story);
                _cIDbContext.SaveChanges();

                result = "Story Added Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add story.", ex);
            }
            return result;
        }


        public List<Story> ClientSideStoryList()
        {
            try
            {
                List<Story> storyList = _cIDbContext.Story.Where(s => !s.IsDeleted).ToList();
                return storyList;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch story list.", ex);
            }
        }


        public Story StoryDetailById(int id)
        {
            Story storyById = new Story();
            try
            {
                storyById = _cIDbContext.Story.FirstOrDefault(m => m.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
            return storyById;
        }
    }
}