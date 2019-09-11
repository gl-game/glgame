using GLCore.Actions;
using GLCore.Actors;
using GLCore.DTO;
using GLCore.Locations;
using GLCore.Scenes;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Web.Script.Serialization;
using GLCore.Data;
using System.Runtime.Serialization;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GLCore.Dynaimc;
using System.Runtime.Serialization.Formatters;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using System.Security.Cryptography;
using GLCore.Extensions;

namespace GLCore
{
    public partial class GLGame
    {
        private GameMode GameMode;
        private GLScene game;
        private GLData gameData;
        JsonSerializerSettings _jsonSettings;
        private Object GameObject;
        private Type GameType;
        Assembly asm;
        public GLGame(GameMode gm)
        {
            GameMode = gm;
            _jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Full
            };
            if (GameMode == GameMode.Game)
            {
                String DLL = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scenes.dll");
                asm = Assembly.LoadFile(DLL);
            }
        }

        public void Load(GLData gData)
        {
            gameData = gData;
            game = new GLScene(gameData);
            game.sc = new SceneDTO();
            game.sc.Description = "";
        }
        public GLData GetState()
        {
            return gameData;
        }

        public GLScene GetGameState()
        {
            return game;
        }

        public void LoadGame(String json)
        {
            game = null;
            gameData = null;
            gameData = JsonConvert.DeserializeObject<GLData>(json, _jsonSettings);
            gameData.time.minuteChange += ExternalMinuteChange;
            gameData.time.hourChange += ExternalHourChange;
            gameData.time.dayChange += ExternalDayChange;
            gameData.LoadEvents();
            Actor.CurrentTime = gameData.time;
            game = new GLScene(gameData);
            game.sc = new SceneDTO();
            game.sc.Description = "";
        }

        public String GetCurrentSceneId()
        {
            return gameData.CurrentScene;
        }

        private static void PreLoadAssembliesFromPath(string p)
        {
            FileInfo[] files = null;
            files = new DirectoryInfo(p).GetFiles("*.dll",
                SearchOption.AllDirectories);

            AssemblyName a = null;
            string s = null;
            foreach (var fi in files)
            {
                s = fi.FullName;
                a = AssemblyName.GetAssemblyName(s);
                if (!AppDomain.CurrentDomain.GetAssemblies().Any(assembly =>
                  AssemblyName.ReferenceMatchesDefinition(a, assembly.GetName())))
                {
                    Assembly.Load(a);
                }
            }
        }

        public void NewGame()
        {
            gameData = null;
            gameData = new GLData();
            gameData.LoadDynamicData();
            gameData.time.minuteChange += ExternalMinuteChange;
            gameData.time.hourChange += ExternalHourChange;
            gameData.time.dayChange += ExternalDayChange;
            gameData.LoadEvents();
            game = new GLScene(gameData);
            game.sc = new SceneDTO();
            game.sc.Description = "";
            /*if (Debug == 0)
            {
                PreLoadAssembliesFromPath("C:/http/assembles/");
            }
             */
        }

        public void LoadErrorMessage(String message)
        {
            game.AddDescriptionBefore("<div class='alert alert-info'>" + message + "</div>");
        }

        public void LoadInfoMessage(String message)
        {
            game.AddDescriptionBefore("<div class='alert alert-info'>" + message + "</div>");
        }

        public String SaveGame()
        {
            return JsonConvert.SerializeObject(gameData, Formatting.Indented, _jsonSettings);
        }

        private void ExternalMinuteChange(int mins)
        {
            MethodInfo methodInfo = GameType.GetMethod("MinuteChanged");
            methodInfo.Invoke(GameObject, new object[] { mins });
        }
        private void ExternalHourChange(int hours)
        {
            MethodInfo methodInfo = GameType.GetMethod("HourChanged");
            methodInfo.Invoke(GameObject, new object[] { hours });
        }
        private void ExternalDayChange(int days)
        {
            MethodInfo methodInfo = GameType.GetMethod("DayChanged");
            methodInfo.Invoke(GameObject, new object[] { days });
        }        

        private void CurrentScenes(String SceneID)
        {
            game.data.CurrentScene = SceneID;
            game.data.CurrentLocation = null;
            foreach (KeyValuePair<string, object> kvp in gameData.location)
            {
                if (((ILocation)kvp.Value).Scene == SceneID)
                {
                    game.data.CurrentLocation = (ILocation)kvp.Value;
                    if (game.data.CurrentLocation.GetType() == typeof(City))
                    {
                        game.data.CurrentLocationCity = (ICity)game.data.CurrentLocation;
                    }
                    break;
                }
            }
            if (game.data.CurrentLocationCity == null)
            {
                game.data.CurrentLocationCity = (ICity)game.data.location.gorodok;
            }
            if (game.data.CurrentLocationCity.weather == null)
            {
                game.data.CurrentLocationCity.weather = DataLocations.CreateWeather(game.data.time, (ICity)game.data.CurrentLocationCity);
            }
        }        

        public GLScene RunCallBack(CallbackDTO cb)
        {
            game.LastCallBack = cb;
            if (cb.c != null)
            {
                cb.c();
            }
            if (cb.t > 0)
            {
                game.data.time.AddTime(cb.t);
            }
            return game;
        }

        public GLScene RunCallBackTime(CallbackDTO cb)
        {
            if (cb.t > 0)
            {
                game.data.time.AddTime(cb.t);
            }
            return game;
        }

        public GLScene GetViewTest(String SceneID)
        {
            CurrentScenes(SceneID);
            TestMyRoom tr = new TestMyRoom(gameData, game);
            GameType = typeof(TestMyRoom);
            GameObject = tr;
            tr.GetView();
            return game;
        }

        public GLScene GetViewStatic()
        {
            return game;
        }
        
        public GLScene GetView(String SceneID, bool newGame = false)
        {
            CurrentScenes(SceneID);
            String className = SceneID.Replace("/", ".");
            var gameObject = RunClass(className, newGame);
            if (gameObject == null)
            {
                return new GLScene(new Exception("Game scene " + className + " not found"));
            }

            if (game.data.CurrentLocation != null && game.data.CurrentLocation.LocationBags != null && game.data.CurrentLocation.LocationBags.Count > 0)
            {
                foreach (var lb in game.data.CurrentLocation.LocationBags)
                {
                    CallbackDTO cdo = new CallbackDTO();
                    String id = Guid.NewGuid().ToString("N");
                    cdo.c = (Action)(() =>
                    {
                        ((Room)(game.data.CurrentLocation)).GetBag(game.data.player, lb);
                    });
                    cdo.Scene = game.data.CurrentLocation.Scene;
                    cdo.CurrentScene = game.data.CurrentScene;
                    game.sc.Callbacks.Add(id, cdo);

                    ActorsDTO adto = new ActorsDTO()
                    {
                        id = id,
                        Name = "Взять " + lb.Name,
                        Scene = game.data.CurrentLocation.Scene,
                        Description = "Забрать сумку " + lb.Name
                    };
                    game.sc.Actors.Add(adto);
                }
            }

            return game;

        }
    }
}
