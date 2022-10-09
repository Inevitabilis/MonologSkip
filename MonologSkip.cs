using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BepInEx;
using AssemblyCSharp;

namespace MonologSkip
{
    [BepInPlugin("Inevitabilis.MonologSkip", "Monolog Skip", "0.0.1")]
    public class MonologSkip : BaseUnityPlugin
    {
        public static int cooldown;
        public void OnEnable()
        {
            On.HUD.DialogBox.Update += DialogBox_Update;
            cooldown.CounterReset();
        }
        private void DialogBox_Update(On.HUD.DialogBox.orig_Update orig, HUD.DialogBox self)
        {
            orig(self);
            cooldown.CounterUpdate();
            if (cooldown <= 0 && self.hud.owner is Player owner)
            {
                if (owner?.room?.game?.Players != null)
                {
                    foreach (var abstractPlayer in owner.room.game.Players)
                    {
                        var player = abstractPlayer.realizedObject as Player;
                        if (player.input[0].jmp)
                        {
                            if (self?.CurrentMessage?.text?.Length != null) self.showCharacter = self.CurrentMessage.text.Length;
                            self.lingerCounter = 10000;
                            cooldown.CounterReset();
                        }
                    }
                }
            }
        }
    }
}
