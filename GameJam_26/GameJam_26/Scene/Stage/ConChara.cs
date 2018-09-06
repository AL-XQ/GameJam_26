using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using Microsoft.Xna.Framework.Graphics;
using InfinityGame.Stage.StageObject;
using InfinityGame.Device;
using InfinityGame.Element;
using Microsoft.Xna.Framework;

namespace GameJam_26.Scene.Stage
{
    public class ConChara : Base_Chara, ICircle
    {
        private Player player;
        private Circle circle;
        private Base_Stage st;
        private Item item;
        private Vector2 speed = Vector2.Zero;
        public Circle Circle { get => circle; set => circle = value; }
        public Item Item { get => item; set => item = value; }
        public Vector2 Speed { get => speed; }
        public Player Player { get => player; }
        public ConChara(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName, Player player) : base(aGraphicsDevice, aParent, aName)
        {
            this.player = player;
            IsCrimp = true;
            st = (Base_Stage)Stage;
            st.charas.Add(this);
        }

        public override void LoadContent()
        {
            Image = ImageManage.GetSImage("conchara.png");
            Size = Size.Parse(image.Image.Size);
            circle = new Circle(this, 50);
            base.LoadContent();
        }

        public override void CalCrimpColl(Dictionary<string, StageObj> tempSO)
        {
            var keys = tempSO.Keys.ToArray();
            foreach (var l in keys)
            {
                if (!tempSO.ContainsKey(l) || !(tempSO[l] is ConChara) ||
                    ((ConChara)tempSO[l]).player.Index == player.Index ||
                    st.Pl_Index != (int)player.Index || ((ConChara)tempSO[l]).item == null)
                    continue;

                var it = ((ConChara)tempSO[l]).item;
                it.SetOwner(null);
                it.RollDown(speed);
            }
            base.CalCrimpColl(tempSO);
        }
    }
}
