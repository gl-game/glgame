using GLCore.Actions;
using GLCore.Actors;
using GLCore.Locations;
using GLCore.Scenes;
using GLCore.Objects;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Linq;

namespace GLCore.Scenes
{
    public partial class BaseScene
    {

        public virtual void SetupGame()
        {
            ((Shop)(game.location.magazinalkogolja)).DefineStuff(() =>
            {
                game.location.magazinalkogolja.AddStuff(game.stuff.vodka02, 10);
                game.location.magazinalkogolja.AddStuff(game.stuff.vodka05, 10);
                game.location.magazinalkogolja.AddStuff(game.stuff.vine7gr02, 10);
                game.location.magazinalkogolja.AddStuff(game.stuff.vine7gr07, 10);
                game.location.magazinalkogolja.AddStuff(game.stuff.vine14gr07, 10);
                game.location.magazinalkogolja.AddStuff(game.stuff.lightbear03l, 10);
                game.location.magazinalkogolja.AddStuff(game.stuff.lightbear05l, 10);
                game.location.magazinalkogolja.AddStuff(game.stuff.lightbear1l, 10);
                game.location.magazinalkogolja.AddStuff(game.stuff.blackbear03l, 10);
                game.location.magazinalkogolja.AddStuff(game.stuff.blackbear05l, 10);
                game.location.magazinalkogolja.AddStuff(game.stuff.blackbear1l, 10);
            });

            ((Shop)(game.location.larjokmelochej)).DefineStuff(() =>
            {
                game.location.larjokmelochej.AddStuff(game.stuff.smallbag1, 1);
                game.location.larjokmelochej.AddStuff(game.stuff.avosjka1, 1);
            });

            ((Box)(game.location.mojatumbochkaroditeli)).DefineStuff(() =>
            {
                game.location.mojatumbochkaroditeli.AddStuff(game.stuff.tualetnajavoda1, 1);
                game.location.mojatumbochkaroditeli.AddStuff(game.stuff.pomada1, 1);
                game.location.mojatumbochkaroditeli.AddStuff(game.stuff.teni1, 1);
                game.location.mojatumbochkaroditeli.AddStuff(game.stuff.rascheska1, 1);

            });

            ((BathRoom)(game.location.shkoladushfemale)).DefineStuff(() =>
            {
                game.location.shkoladushfemale.AddStuff(game.stuff.shampunj1, 1);

            });

            ((BathRoom)(game.location.vannaja)).DefineStuff(() =>
            {
                game.location.vannaja.AddStuff(game.stuff.shampunj1, 1);
                game.location.vannaja.AddStuff(game.stuff.britva1, 1);

            });


            ((Wardrobe)(game.location.shkafroditeli)).DefineStuff(() =>
            {
                game.location.shkafroditeli.AddStuff(game.stuff.zimnajakurtka, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.bant1, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.schooldress1, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.schoolshoes1, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.bra6, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.panties3, 1);
                //game.location.shkafroditeli.AddStuff(game.stuff.schoolbag1, 1);
                game.location.shkafroditeli.AddStuff(game.stuff.avosjka1, 1);
                //game.location.shkafroditeli.AddStuff(game.stuff.sportpants1, 1);
                //game.location.shkafroditeli.AddStuff(game.stuff.sportshirt1, 1);

            });
        } 
    }
}
