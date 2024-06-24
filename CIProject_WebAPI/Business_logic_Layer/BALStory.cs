using Data_Access_Layer;
using Data_Access_Layer.Common;
using Data_Access_Layer.Repository.Entities;

namespace Business_logic_Layer
{
    public class BALStory
    {
        private readonly DALStory _dalStory;
        public BALStory(DALStory dalStory)
        {
            _dalStory = dalStory;
        }
        public List<DropDown> GetMissionTitle()
        {
            return _dalStory.GetMissionTitle();
        }
        public string AddStory(Story story)
        {
            return _dalStory.AddStory(story);
        }
        public List<Story> ClientSideStoryList()
        {
            return _dalStory.ClientSideStoryList();
        }
        public Story StoryDetailById(int id)
        {
            return _dalStory.StoryDetailById(id);
        }
        public List<Story> AdminSideStoryList()
        {
            return _dalStory.AdminSideStoryList();
        }

        public string StoryStatusActive(Story story)
        {
            return _dalStory.StoryStatusActive(story);
        }
        public string DeleteStory(int id)
        {
            return _dalStory.DeleteStory(id);
        }
        public Story StoryDetailByIdAdmin(int id)
        {
            return _dalStory.StoryDetailByIdAdmin(id);
        }
    }
}