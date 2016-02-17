namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Data;

    public class LikesController : BaseController
    {
        private ILikesService likes;

        public LikesController(ILikesService likes)
        {
            this.likes = likes;
        }

        [HttpPost]
        public ActionResult Like(int jokeId, int likeType)
        {
            if (likeType < -1)
            {
                likeType = -1;
            }

            if (likeType > 1)
            {
                likeType = 1;
            }

            var userId = this.User.Identity.GetUserId();

            var like = this.likes.GetByUserAndJoke(userId, jokeId);

            if (like == null)
            {
                this.likes.Create(userId, jokeId, likeType);
            }
            else
            {
                this.likes.Update(userId, jokeId, likeType);
            }

            var likesSum = this.likes.GetAllLikes(jokeId);

            return this.Json(new { Count = likesSum });
        }
    }
}
