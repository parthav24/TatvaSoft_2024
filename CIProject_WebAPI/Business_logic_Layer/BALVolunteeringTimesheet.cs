using Data_Access_Layer;
using Data_Access_Layer.Common;
using Data_Access_Layer.Repository.Entities;


namespace Business_logic_Layer
{
    public class BALVolunteeringTimesheet
    {
        private readonly DALVolunteeringTimesheet _dalVolunteeringTimesheet;
        public BALVolunteeringTimesheet(DALVolunteeringTimesheet dalVolunteeringTimesheet)
        {
            _dalVolunteeringTimesheet = dalVolunteeringTimesheet;
        }
        public List<VolunteeringHours> GetVolunteeringHoursList(int userId)
        {
            return _dalVolunteeringTimesheet.GetVolunteeringHoursList(userId);
        }
        public VolunteeringHours GetVolunteeringHoursListById(int id)
        {
            return _dalVolunteeringTimesheet.GetVolunteeringHoursListById(id);
        }
        public string AddVolunteeringHours(VolunteeringHours volunteeringHours)
        {
            return _dalVolunteeringTimesheet.AddVolunteeringHours(volunteeringHours);
        }

        public string UpdateVolunteeringHours(VolunteeringHours volunteeringHours)
        {
            return _dalVolunteeringTimesheet.UpdateVolunteeringHours(volunteeringHours);
        }
        public List<DropDown> VolunteeringMissionList(int userId)
        {
            return _dalVolunteeringTimesheet.VolunteeringMissionList(userId);
        }
        public string DeleteVolunteeringHours(int id)
        {
            return _dalVolunteeringTimesheet.DeleteVolunteeringHours(id);
        }
        public List<VolunteeringGoals> GetVolunteeringGoalsList(int userId)
        {
            return _dalVolunteeringTimesheet.GetVolunteeringGoalsList(userId);
        }
        public VolunteeringGoals GetVolunteeringGoalsListById(int id)
        {
            return _dalVolunteeringTimesheet.GetVolunteeringGoalsListById(id);
        }
        public string AddVolunteeringGoals(VolunteeringGoals volunteeringGoals)
        {
            return _dalVolunteeringTimesheet.AddVolunteeringGoals(volunteeringGoals);
        }

        public string UpdateVolunteeringGoals(VolunteeringGoals volunteeringGoals)
        {
            return _dalVolunteeringTimesheet.UpdateVolunteeringGoals(volunteeringGoals);
        }
        public string DeleteVolunteeringGoals(int id)
        {
            return _dalVolunteeringTimesheet.DeleteVolunteeringGoals(id);
        }
    }
}