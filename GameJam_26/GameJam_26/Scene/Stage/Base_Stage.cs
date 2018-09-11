using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityGame.GameGraphics;
using InfinityGame.Stage;
using InfinityGame.Stage.StageObject;
using InfinityGame.Stage.StageObject.Block;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using InfinityGame.Def;

using InfinityGame.Device;
using InfinityGame.Element;

namespace GameJam_26.Scene.Stage
{
    public class Base_Stage : BaseStage
    {
        private int turn = 12;
        private int turnstate = 0;
        private List<Player> players = new List<Player>();
        private int pl_index = 0;
        private Random rnd = new Random();
        private int timedown = 15 * 120;
        private int t_timedown = 15 * 120;
        private float resistance = 0.004f;
        private float g_v = 1f;
        private bool gameOver = false;

        public List<ConChara> charas = new List<ConChara>();
        public List<Item> items = new List<Item>();
        public bool run = false;
        public int Pl_Index { get => pl_index; set => pl_index = value; }
        public int Turn { get => turn; }
        public int Timedown { get => timedown; }
        /// <summary>
        /// 抵抗力
        /// </summary>
        public float Resistance { get => resistance; }
        /// <summary>
        /// GameJam専用重力
        /// </summary>
        public float G_V { get => g_v; }
        public Base_Stage(GraphicsDevice aGraphicsDevice, BaseDisplay aParent, string aName) : base(aGraphicsDevice, aParent, aName)
        {
            EndOfLeftUp = new Point(0, 0);
            EndOfRightDown = IGConfig.screen.ToPoint();
        }
        public override void Initialize()
        {
            run = false;
            turn = 12;
            turnstate = 0;
            gameOver = false;
            pl_index = rnd.Next(2);
            timedown = t_timedown;
            foreach (var l in players)
            {
                l.Initialize();
            }
            base.Initialize();
        }
        public override void PreLoadContent()
        {
            var sf = new StageField(graphicsDevice, this, "field");
            new StageBorder(graphicsDevice, this, "border_top");
            new StageBorder(graphicsDevice, this, "border_left");
            new StageBorder(graphicsDevice, this, "border_right");
            new StageBorder(graphicsDevice, this, "border_bottom");
            sf.Size = IGConfig.screen;
            sf.DrawOrder = -1;
            stageObjs["border_top"].Size = new Size(sf.Size.Width, sf.Size.Height / 25);
            stageObjs["border_left"].Size = new Size(sf.Size.Height / 25, sf.Size.Height - sf.Size.Height * 2 / 25);//WidthをHeightのままにデザイン
            stageObjs["border_bottom"].Size = stageObjs["border_top"].Size;
            stageObjs["border_right"].Size = stageObjs["border_left"].Size;

            stageObjs["border_left"].Coordinate = new Vector2(0, sf.Size.Height / 25);
            stageObjs["border_right"].Coordinate = new Vector2(sf.Size.Width - sf.Size.Height / 25, sf.Size.Height / 25);
            stageObjs["border_bottom"].Coordinate = new Vector2(0, sf.Size.Height - sf.Size.Height / 25);

            players.Add(new Player(PlayerIndex.One, this));
            players.Add(new Player(PlayerIndex.Two, this));
            foreach (var l in players)
            {
                l.PreLoadContent();
            }
            base.PreLoadContent();
        }
        public override void LoadContent()
        {
            foreach (var l in players)
            {
                l.LoadContent();
            }
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (StageScene.ShowStage.Name != Name)
                return;
            if (!gameOver)
            {
                run = false;
                foreach (var l in charas)
                {
                    if (l.Run)
                    {
                        run = true;
                        break;
                    }
                }
                if (!run)
                {
                    foreach (var l in items)
                    {
                        if (l.Run)
                        {
                            run = true;
                            break;
                        }
                    }
                }
                if (turnstate == 0)
                {
                    if (timedown > 0)
                        timedown--;
                    if (players[pl_index].Update(gameTime) || timedown == 0)
                    {
                        players[pl_index].TrunReset();
                        turnstate = 1;
                    }
                }
                else if (turnstate == 1 && !run)
                {
                    ChangeTurn();
                }
                if (turn <= 0)
                    gameOver = true;
            }
            foreach (var l in players)
            {
                l.FreeUpdate(gameTime);
            }
            base.Update(gameTime);
        }

        private void ChangeTurn()
        {
            timedown = t_timedown;
            ChangePlayer();
            turn--;
            turnstate = 0;
            if (turn > 0)
                ((PlayScene)StageScene).ChangeTrun(pl_index);
        }

        public void ChangePlayer()
        {
            players[pl_index % 2].ResetV();
            players[pl_index % 2].CheckFoucs();
            pl_index = (pl_index % 2 + 1) % 2;
        }
    }
}
