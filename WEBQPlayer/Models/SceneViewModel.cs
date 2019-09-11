using GLCore.Actors;
using GLCore.DTO;
using GLCore.SupportObjects;
using System;
using System.Collections.Generic;

namespace WEBQPlayer.Models
{
    public class SceneViewModel
    {
        public List<ActionDTO> Actions { get; set; }
        public List<ActorsDTO> Actors { get; set; }
        public List<DirectionDTO> Directions { get; set; }
        public String Description { get; set; }
        public String DateTime { get; set; }
        public Player player { get; set; }
        public Weather weather { get; set; }
    }
}