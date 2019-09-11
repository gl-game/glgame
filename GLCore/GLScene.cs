using GLCore.Actions;
using GLCore.Actors;
using GLCore.DTO;
using GLCore.Locations;
using GLCore.Objects;
using GLCore.SupportObjects;
using GLHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GLCore
{
    public partial class GLScene : IDisposable
    {
        public SceneDTO sc { get; set; }
        public CallbackDTO LastCallBack { get; set; }
        public Exception Exception { get; set; }
        public GLData data { get; set; }
        public GLScene(Exception _e)
        {
            Exception = _e;
        }
        public GLScene(GLData _data)
        {
            this.data = _data;
            this.sc = new SceneDTO();
            this.sc.Description = "";
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            this.sc = new SceneDTO();
        }

        ~GLScene()
        {
            Dispose(true);
        }
        public Action GetAction(String saveDictionary)
        {
            if (GLTempData.CallBackSaveList.ContainsKey(saveDictionary))
            {
                return (Action)GLTempData.CallBackSaveList[saveDictionary];
            }
            return null;
        }

        public void AddActorAction(IActor Actor, Object callback = null, String saveDictionary = "", bool IsDynamic = false)
        {            
            String id = null;
            CallbackDTO cdo = new CallbackDTO();
            PropertyInfo Description = null;
            PropertyInfo Name = null;
            PropertyInfo Scene = null;
            if (callback != null)
            {
                Description = callback.GetType().GetProperty("Description");
                Name = callback.GetType().GetProperty("Name");
                Scene = callback.GetType().GetProperty("Scene");
                var t = callback.GetType().GetProperty("t");
                var c = callback.GetType().GetProperty("c");

                if (c != null)
                {
                    id = Guid.NewGuid().ToString("N");
                    cdo.c = (Action)c.GetValue(callback, null);
                    cdo.Scene = (Scene == null) ? data.CurrentScene : Scene.GetValue(callback, null).ToString();
                    cdo.CurrentScene = data.CurrentScene;
                    cdo.IsDynamicScene = IsDynamic;
                    if (saveDictionary != "")
                    {
                        if (!GLTempData.CallBackSaveList.ContainsKey(saveDictionary))
                        {
                            GLTempData.CallBackSaveList.Add(saveDictionary, cdo.c);
                        }
                        else
                        {
                            GLTempData.CallBackSaveList[saveDictionary] = cdo.c;
                        }
                    } 
                }
                if (t != null)
                {
                    id = Guid.NewGuid().ToString("N");
                    cdo.t = Convert.ToInt32(t.GetValue(callback, null).ToString());
                    cdo.Scene = (Scene == null) ? data.CurrentScene : Scene.GetValue(callback, null).ToString();
                    cdo.CurrentScene = data.CurrentScene;
                }
                if (id != null)
                {
                    sc.Callbacks.Add(id, cdo);
                }
            }
            ActorsDTO adt = new ActorsDTO()
            {
                id = id,
                Name = (Name == null) ? Actor.Name : Name.GetValue(callback, null).ToString(),
                Scene = (Scene == null) ? data.CurrentScene : Scene.GetValue(callback, null).ToString(),
                Description = (Description == null) ? "" : Description.GetValue(callback, null).ToString(),
                t = Actor.t,
                c = Actor.c
            };
            sc.Actors.Add(adt);
        }

        public void AddDynamicActorAction(IActor Actor, Object callback = null, String saveDictionary = "")
        {
            AddActorAction(Actor, callback, saveDictionary, true);
        }

        public void DropBag(IBagObject bagObj)
        {
            if (bagObj.GetType() == typeof(City) || bagObj.GetType() == typeof(Country) || bagObj.GetType() == typeof(District) || bagObj.GetType() == typeof(ObjectBuilding))
            {
                return;
            }
            var l = (Room)data.CurrentLocation;
            l.DropBag(GetPlayer(), bagObj);
        }

        public void AddDescriptionBefore(String s)
        {
            s = s.Replace("src=", "class='img-responsive' src=");
            sc.Description = s + "<br/>" + sc.Description;
        }

        public void ClearDescription()
        {
            sc.Description = "";
        }

        public void AddDescription(String s)
        {
            s = s.Replace("src=", "class='img-responsive' src=");
            sc.Description += s + "<br/>";
        }

        public void AddDirection(ILocation Location, Object callback = null, bool CopyToAction = false)
        {

            String id = null;
            CallbackDTO cdo = new CallbackDTO();
            PropertyInfo Name = null;
            PropertyInfo Description = null;
            if (callback != null)
            {
                Description = callback.GetType().GetProperty("Description");
                var t = callback.GetType().GetProperty("t");
                var c = callback.GetType().GetProperty("c");
                Name = callback.GetType().GetProperty("Name");

                if (c != null)
                {
                    id = Guid.NewGuid().ToString("N");
                    cdo.c = (Action)c.GetValue(callback, null);
                    cdo.Scene = Location.Scene;
                    cdo.CurrentScene = data.CurrentScene;
                }
                if (t != null)
                {
                    id = Guid.NewGuid().ToString("N");
                    cdo.t = Convert.ToInt32(t.GetValue(callback, null).ToString());
                    cdo.Scene = Location.Scene;
                    cdo.CurrentScene = data.CurrentScene;
                }
                if (id != null)
                {
                    sc.Callbacks.Add(id, cdo);
                }
            }

            DirectionDTO ddt = new DirectionDTO()
            {
                id = id,
                Name = (Name != null) ? Name.GetValue(callback, null).ToString() : Location.Name,
                Description = (Description != null) ? Description.GetValue(callback, null).ToString() : Location.Description,
                Scene = Location.Scene
            };
            sc.Directions.Add(ddt);
            if (CopyToAction)
            {
                ActionDTO adto = new ActionDTO()
                {
                    id = id,
                    Name = (Name != null) ? Name.GetValue(callback, null).ToString() : Location.Name,
                    Description = (Description != null) ? Description.GetValue(callback, null).ToString() : Location.Description,
                    Scene = Location.Scene
                };
                sc.Actions.Add(adto);
            }
        }

        public String RegisterEvent(Action ev, String Scene = "")
        {
            CallbackDTO cdo = new CallbackDTO();
            String id = Guid.NewGuid().ToString("N");
            cdo.c = ev;
            cdo.Scene = (!String.IsNullOrEmpty(Scene)) ? Scene : data.CurrentScene;
            cdo.CurrentScene = data.CurrentScene;
            sc.Callbacks.Add(id, cdo);
            return id;
        }

        public String RegisterInternalEvent(Action ev, String Scene = "")
        {
            CallbackDTO cdo = new CallbackDTO();
            String id = Guid.NewGuid().ToString("N");
            cdo.c = ev;
            cdo.Scene = (!String.IsNullOrEmpty(Scene)) ? Scene : data.CurrentScene;
            sc.InternalCallbacks.Add(id, cdo);
            return id;
        }

        public String RegisterHtmlEvent(Func<String> ev, String Scene = "")
        {
            CallbackDTO cdo = new CallbackDTO();
            String id = Guid.NewGuid().ToString("N");
            cdo.html = ev;
            cdo.Scene = (!String.IsNullOrEmpty(Scene)) ? Scene : data.CurrentScene;
            sc.InternalCallbacks.Add(id, cdo);
            return id;
        }

        public void AddAction(IAction Action)
        {
            ActionDTO adto = new ActionDTO()
            {
                Name = Action.Name,
                Scene = Action.Scene
            };
            sc.Actions.Add(adto);
        }

        public void AddDynamicScene(Object Action)
        {
            AddDynamicAction(Action, true);
        }

        public void AddDynamicAction(Object Action, bool IsDynamic = false)
        {
            var Description = Action.GetType().GetProperty("Description");//.GetValue(Action, null).ToString();
            var t = Action.GetType().GetProperty("t");
            var c = Action.GetType().GetProperty("c");
            var LoadLast = Action.GetType().GetProperty("LoadLast");
            String id = null;
            CallbackDTO cdo = new CallbackDTO();
            PropertyInfo Scene = Action.GetType().GetProperty("Scene");
            if (c != null)
            {
                id = Guid.NewGuid().ToString("N");
                cdo.c = (Action)c.GetValue(Action, null);
                cdo.Scene = (Scene == null) ? data.CurrentScene : Scene.GetValue(Action, null).ToString();
                cdo.CurrentScene = data.CurrentScene;
                cdo.IsDynamicScene = IsDynamic;
            }
            if (LoadLast != null && (Boolean)LoadLast.GetValue(Action, null) == true)
            {
                cdo.LoadLast = LastCallBack;
            }
            if (t != null)
            {
                id = Guid.NewGuid().ToString("N");
                cdo.t = Convert.ToInt32(t.GetValue(Action, null).ToString());
                cdo.Scene = (Scene == null) ? data.CurrentScene : Scene.GetValue(Action, null).ToString();
                cdo.CurrentScene = data.CurrentScene;
            }
            if (id != null)
            {
                sc.Callbacks.Add(id, cdo);
            }

            ActionDTO adto = new ActionDTO()
            {
                id = id,
                Name = Action.GetType().GetProperty("Name").GetValue(Action, null).ToString(),
                Scene = (Scene == null) ? data.CurrentScene : Scene.GetValue(Action, null).ToString(),
                Description = (Description == null) ? "" : Description.GetValue(Action, null).ToString()
            };
            sc.Actions.Add(adto);
        }


        public Player GetPlayer()
        {
            return data.player;
        }

        public Weather GetWeather()
        {
            return (data.CurrentLocationCity != null) ? data.CurrentLocationCity.weather : null;
        }
    }
}
