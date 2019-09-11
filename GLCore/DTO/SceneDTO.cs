using GLCore.Actors;
using GLCore.Locations;
using System;
using System.Collections.Generic;

namespace GLCore.DTO
{
    public class SceneDTO
    {
        public SceneDTO()
        {
            Actors = new List<ActorsDTO>();
            Directions = new List<DirectionDTO>();
            Actions = new List<ActionDTO>();
            Callbacks = new Dictionary<String, CallbackDTO>();
            InternalCallbacks = new Dictionary<String, CallbackDTO>();
            Description = "";
        }
        public List<ActionDTO> Actions { get; set; }
        public List<DirectionDTO> Directions { get; set; }
        public List<ActorsDTO> Actors { get; set; }
        public Dictionary<String, CallbackDTO> Callbacks { get; set; }
        public Dictionary<String, CallbackDTO> InternalCallbacks { get; set; }
        public String Description { get; set; }
        public String Error { get; set; }
        public String Message { get; set; }
        public String InternalMesage { get; set; }
        public String Redirect { get; set; }
    }
    public class CallbackDTO
    {
        public String id { get; set; }
        public String Name { get; set; }
        public String Scene { get; set; }
        public String Description { get; set; }
        public int t { get; set; }
        public Action c { get; set; }
        public CallbackDTO LoadLast { get; set; }
        public Func<String> html { get; set; }
        public String CurrentScene { get; set; }
        public bool IsDynamicScene { get; set; }
    }
/*
    public class CallbackDTOWeb
    {
        public String id { get; set; }
        public String Name { get; set; }
        public String Scene { get; set; }
        public String Description { get; set; }
        public int t { get; set; }
        public Action c { get; set; }
        public String CurrentScene { get; set; }
    }
*/
    public class TextDTO
    {
        public String Name { get; set; }
        public int Font { get; set; }
        public String color { get; set; }
    }
    public class ActionDTO
    {
        public String id { get; set; }
        public String Name { get; set; }
        public String Scene { get; set; }
        public String Description { get; set; }
        public int t { get; set; }
        public String c { get; set; }
    }
    public class DirectionDTO
    {
        public String id { get; set; }
        public String Name { get; set; }
        public String Scene { get; set; }
        public String Description { get; set; }
        public int t { get; set; }
        public String c { get; set; }
    }
    public class ActorsDTO
    {
        public String id { get; set; }
        public String Name { get; set; }
        public String Scene { get; set; }
        public String Description { get; set; }
        public int t { get; set; }
        public String c { get; set; }
    }
}
