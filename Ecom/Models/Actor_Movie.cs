﻿namespace Ecom.Models
{
    public class Actor_Movie
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }    
        public int MovieId { get; set; }
        public Movie Movie  { get; set; }
    }
}
