using GLCore.Actions;
using GLCore.Actors;
using GLCore.DTO;
using GLCore.Locations;
using GLCore.Scenes;
using GLCore.Extensions;
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

namespace GLCore
{
    public partial class GLGame
    {
        private GLScene RunClass(String className, bool newGame)
        {
            try
            {
                GameType = Type.GetType("GLCore.Scenes." + className);
                return CreateObject(newGame);
            }
            catch (TargetInvocationException)
            {
                return null;
            }
        }

        public GLScene CreateObject(bool newGame)
        {
            GameObject = Activator.CreateInstance(GameType);
            MethodInfo initMethod = GameType.GetMethod("InitEngine"); 
            try
            {
                initMethod.Invoke(GameObject, new object[] { gameData, game });
            }
            catch (TargetInvocationException e)
            {
                game.sc.Error = e.InnerException.InnerException.Message;
                return game;
            }
            MethodInfo methodInfo = GameType.GetMethod("GetView");
            MethodInfo setupGame = GameType.GetMethod("SetupGame");
            MethodInfo preActions = GameType.GetMethod("PreActions");
            MethodInfo postActions = GameType.GetMethod("PostActions");
            try
            {
                if (newGame)
                {
                    setupGame.Invoke(GameObject, null);
                }
                preActions.Invoke(GameObject, null);
                methodInfo.Invoke(GameObject, null);
                postActions.Invoke(GameObject, null);
            }
            catch (TargetInvocationException e)
            {

                if (e.InnerException.GetType() == typeof(RediredctException))
                {
                    game.sc.Redirect = e.InnerException.Message;
                    if (e.InnerException.InnerException != null && e.InnerException.InnerException.Message != null)
                    {
                        game.sc.Error = e.InnerException.InnerException.Message;
                    }
                }
                else if (e.InnerException.GetType() == typeof(MessageException))
                {
                    game.sc.Redirect = e.InnerException.Message;
                    if (e.InnerException.InnerException != null && e.InnerException.InnerException.Message != null)
                    {
                        game.sc.Message = e.InnerException.InnerException.Message;
                    }
                }
                else
                {
                    throw new Exception(e.Message, e);
                }
            }
            return game;
        }        
    }
}
