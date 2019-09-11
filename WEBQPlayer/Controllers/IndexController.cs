using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GLCore;
using GLCore.DTO;
using WEBQPlayer.Models;
using System.IO;
using System.Reflection;
using GLCore.Extensions;

namespace WEBQPlayer.Controllers
{
    public class IndexController : Controller
    {
        private void GenerateScene(String array, out String folder1, out String folder2, out String folder3, out String folder4) {
            String[] actions = array.Split('/');
            folder1 = "";
            folder2 = "";
            folder3 = "";
            folder4 = "";
            switch (actions.Length)
            {
                case 1:
                    folder1 = actions[0];
                    break;
                case 2:
                    folder1 = actions[0];
                    folder2 = actions[1];
                    break;
                case 3:
                    folder1 = actions[0];
                    folder2 = actions[1];
                    folder3 = actions[2];
                    break;
                case 4:
                    folder1 = actions[0];
                    folder2 = actions[1];
                    folder3 = actions[2];
                    folder4 = actions[3];
                    break;
            }
        }
        public ActionResult TestCPU()
        {
            return View();
        }
        public ActionResult Stats()
        {

            return View();
        }
        public ActionResult Processor(String id)
        {
            var cbs = (Dictionary<String, CallbackDTO>)Session["callbacks"];
            var cb = cbs.FirstOrDefault(x => x.Key == id).Value;

            GLGame gl = new GLGame(GameMode.VisualStudio);
            if (Session["savegame"] != null)
            {
                gl.Load((GLData)Session["savegame"]);
            }

            GLScene game = gl.RunCallBack(cb);
            Session["savegame"] = gl.GetState();
            String folder1 = null;
            String folder2 = null;
            String folder3 = null;
            String folder4 = null;
            if (!String.IsNullOrEmpty(game.sc.Redirect))
            {
                if (!String.IsNullOrEmpty(game.sc.Error))
                {
                    Session["showMessageError"] = game.sc.Error;
                }
                GenerateScene(game.sc.Redirect, out folder1, out folder2, out folder3, out folder4);
                return RedirectToAction("Game", "Index", new { folder1 = folder1, folder2 = folder2, folder3 = folder3, folder4 = folder4 });
            }

            if (!String.IsNullOrEmpty(game.sc.Message))
            {
                Session["showMessageInfo"] = game.sc.Message.Replace("\n", "<br />"); ;
            }
            GenerateScene(cb.Scene, out folder1, out folder2, out folder3, out folder4);
            return RedirectToAction("Game", "Index", new { folder1 = folder1, folder2 = folder2, folder3 = folder3, folder4 = folder4 });
        }
        public ActionResult Home()
        {
            return RedirectToAction("Game", "Index");
        }
        public ActionResult Game(String folder1, String folder2, String folder3, String folder4)
        {
            Session["callbacks"] = null;
            String folder = "";
            if (!String.IsNullOrEmpty(folder1))
            {
                folder += folder1;
            }
            if (!String.IsNullOrEmpty(folder2))
            {
                folder += "/" + folder2;
            }
            if (!String.IsNullOrEmpty(folder3))
            {
                folder += "/" + folder3;
            }
            if (!String.IsNullOrEmpty(folder4))
            {
                folder += "/" + folder4;
            }
            if (String.IsNullOrEmpty(folder2))
            {
                folder = "gorodok/vokzal/larjokmelochej";
            }
            String path = Path.Combine(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath), @"Saves\save1.glgame");
            String contents = System.IO.File.ReadAllText(path);
            GLGame gl = new GLGame(GameMode.VisualStudio);
            if (Session["savegame"] != null)
            {
                gl.Load((GLData)Session["savegame"]);
            }
            else
            {
                gl.NewGame();
            }
            GLScene game = gl.GetView(folder);
            Session["savegame"] = gl.GetState();

            if (!String.IsNullOrEmpty(game.sc.Redirect))
            {
                if (!String.IsNullOrEmpty(game.sc.Error))
                {
                    Session["showMessageError"] = game.sc.Error;
                }
                GenerateScene(game.sc.Redirect, out folder1, out folder2, out folder3, out folder4);
                return RedirectToAction("Game", "Index", new { folder1 = folder1, folder2 = folder2, folder3 = folder3, folder4 = folder4 });
            }

            if (!String.IsNullOrEmpty(game.sc.Message))
            {
                Session["showMessageInfo"] = game.sc.Message;
            }

            if (Session["showMessageError"] != null)
            {
                gl.LoadErrorMessage((String)Session["showMessageError"]);
                Session["showMessageError"] = null;
            }

            if (Session["showMessageInfo"] != null)
            {
                gl.LoadInfoMessage((String)Session["showMessageInfo"]);
                Session["showMessageInfo"] = null;
            }

            SceneViewModel model = new SceneViewModel();
            Session["callbacks"] = game.sc.Callbacks;
            model.Actions = game.sc.Actions;
            model.Actors = game.sc.Actors;
            model.Directions = game.sc.Directions;
            model.Description = game.sc.Description.Replace("callback:", "/callback/").Replace("scene:", "/scene/");
            model.DateTime = game.data.time.GetTime();
            model.player = game.GetPlayer();
            model.weather = game.GetWeather();
            return View(model);
        }
    }
}