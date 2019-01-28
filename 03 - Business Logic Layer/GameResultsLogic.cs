using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBryce
{
    public class GameResultsLogic : BaseLogic
    {
        public GameResultModel AddResult(GameResultModel gameResultModel)
        {
            gameResultModel.dateAdded = DateTime.Now;

            GameResult gameResult = new GameResult
            {
                UserID = gameResultModel.userId,
                DateAdded = gameResultModel.dateAdded,
                TimeSpan = gameResultModel.timeSpan,
                StepsNumber = gameResultModel.steps
            };

            DB.GameResults.Add(gameResult);
            DB.SaveChanges();

            gameResultModel.id = gameResult.GameResultID;
            return gameResultModel;
        }

        // The data ordered by steps number (== winner (: )
        public List<GameResultModel> GetAllResults()
        {
            var query = from gr in DB.GameResults
                        join user in DB.Users
                        on gr.UserID equals user.UserID
                        orderby gr.StepsNumber
                        select new GameResultModel
                        {
                            id = gr.GameResultID,
                            userId = gr.UserID,
                            fullName = user.FullName,
                            username = user.Username,
                            dateAdded = gr.DateAdded,
                            timeSpan = gr.TimeSpan,
                            steps = gr.StepsNumber
                        };

            return query.ToList();
        }
    }
}
