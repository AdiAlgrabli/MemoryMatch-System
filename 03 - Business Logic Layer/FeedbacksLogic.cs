using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBryce
{
    public class FeedbacksLogic : BaseLogic
    {
        public UsersLogic usersLogic = new UsersLogic();

        public FeedbackModel AddFeedback(FeedbackModel feedbackModel)
        {
            feedbackModel.dateAdded = DateTime.Now;

            Feedback feedback = new Feedback()
            {
                UserID = feedbackModel.userId,
                FeedbackDateAdded = feedbackModel.dateAdded,
                FeedbackText = feedbackModel.fbText
            };

            DB.Feedbacks.Add(feedback);
            DB.SaveChanges();

            feedbackModel.id = feedback.FeedbackID;
            return feedbackModel;
        }

        public List<FeedbackModel> GetAllFeedbacks()
        {
            var query = from fb in DB.Feedbacks
                        join user in DB.Users
                        on fb.UserID equals user.UserID
                        select new FeedbackModel
                        {
                            id = fb.FeedbackID,
                            userId = fb.UserID,
                            username = user.Username,
                            dateAdded = fb.FeedbackDateAdded,                                               
                            fbText = fb.FeedbackText
                        };

            return query.ToList();
        }
    }
}
