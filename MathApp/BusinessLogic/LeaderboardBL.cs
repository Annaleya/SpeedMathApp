using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathApp.Models;
using DataLibrary.DTOs;
using DataLibrary.Repositories;

namespace MathApp.BusinessLogic
{
    public class LeaderboardBL
    {
        public void AddNewLeaderboard(LeaderboardModel leaderboardModel)
        {
            //Convert model to DTO
            LeaderboardDTO leaderboardDTO = ConvertLeaderboardToDTO(leaderboardModel);
            //Write new record to DB
            LeaderboardRepository leaderboardRepository = new LeaderboardRepository();
            leaderboardRepository.AddToLeaderboard(leaderboardDTO);
        }
        public List<LeaderboardModel> GetLeaderboard()
        {
            List<LeaderboardModel> leaderboardModels = new List<LeaderboardModel>();
            LeaderboardRepository leaderboardRepository = new LeaderboardRepository();

            List<LeaderboardDTO> leaderboardDTOs = leaderboardRepository.GetLeaderboard();
            if (leaderboardDTOs.Count > 0)
            {
                foreach (LeaderboardDTO leaderboardDTO in leaderboardDTOs)
                {
                    LeaderboardModel lm = new LeaderboardModel();
                    lm.Username = leaderboardDTO.Username;
                    lm.score = leaderboardDTO.Score;

                    leaderboardModels.Add(lm);
                }
            }
            return leaderboardModels;
        }
        public LeaderboardDTO ConvertLeaderboardToDTO(LeaderboardModel lm)
        {
            LeaderboardDTO leaderboardInformation = new LeaderboardDTO();
            leaderboardInformation.Username = lm.Username;
            leaderboardInformation.Score = lm.score;

            return leaderboardInformation;
        }
    }
}
