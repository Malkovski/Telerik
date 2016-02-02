namespace YouTubePlaylist.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public class Playlist
    {
        private ICollection<Video> videos;
        private ICollection<Rating> ratings;

        public Playlist()
        {
            this.videos = new HashSet<Video>();
            this.ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }


        public DateTime CreationDate { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }

        public virtual ICollection<Video> Videos
        {
            get { return this.videos; }
            set { this.videos = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}