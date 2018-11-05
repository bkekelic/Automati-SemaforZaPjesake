using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaforZaPjesake
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics graph;
        bool stateCounter = false;
        int timeBlinkCounter = 0;
        string mode = "";
        int timeCounter;
        bool pressPedButton = false;
        bool sceneIsOn = false;

        List<SolidBrush> brushList = new List<SolidBrush>();
        List<Point> pointLightsList = new List<Point>();
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pb_Scene.Size.Width, pb_Scene.Size.Height);
            graph = Graphics.FromImage(bmp);
            timeCounter = 0;


            AddPointsToList();
            AddBrushesToList();
            ShowTrafficLights();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timerForAll.Interval = 500;
            mode = "OrangeBlinkAllTheTime";
            TrafficLightsChange();
        }
        private void AddPointsToList()
        {
            //car lights
            pointLightsList.Add(new Point(800, 20));
            pointLightsList.Add(new Point(800, 60));
            pointLightsList.Add(new Point(800, 100));
            pointLightsList.Add(new Point(200, 390));
            pointLightsList.Add(new Point(200, 430));
            pointLightsList.Add(new Point(200, 470));

            //pedestrial lights
            pointLightsList.Add(new Point(700, 20));//crveno 6
            pointLightsList.Add(new Point(700, 60));//zeleno 7
            pointLightsList.Add(new Point(300, 390));//crveno 8 
            pointLightsList.Add(new Point(300, 430));//zeleno 9


        }
        private void AddBrushesToList()
        {
            brushList.Add(new SolidBrush(Color.Black));
            brushList.Add(new SolidBrush(Color.Black));
            brushList.Add(new SolidBrush(Color.Black));
            brushList.Add(new SolidBrush(Color.Red));
            brushList.Add(new SolidBrush(Color.Orange));
            brushList.Add(new SolidBrush(Color.FromArgb(0,192,0)));
        }
        private void ShowTrafficLights()
        {
            TurnOFFCarRed();
            TurnOFFCarOrange();
            TurnOFFCarGreen();

            TurnOFFPedestrianRed();
            TurnOFFPedestrianGreen();
        }

        private void DrawCircle(SolidBrush b, Point p)
        {
            graph = Graphics.FromImage(bmp);
            graph.FillEllipse(b, p.X, p.Y, 35, 35);

            RefreshScene();
        }
        private void RefreshScene()
        {
            pb_Scene.Image = bmp;
            graph.Dispose();
        }

       

        private void TurnOFFCarRed()
        {
            DrawCircle(brushList[0], pointLightsList[0]);
            DrawCircle(brushList[0], pointLightsList[3]);

        }
        private void TurnOFFCarOrange()
        {
            DrawCircle(brushList[1], pointLightsList[1]);
            DrawCircle(brushList[1], pointLightsList[4]);
        }
        private void TurnOFFCarGreen()
        {
            DrawCircle(brushList[2], pointLightsList[2]);
            DrawCircle(brushList[2], pointLightsList[5]);
        }
        private void TurnONCarRed()
        {
            DrawCircle(brushList[3], pointLightsList[0]);
            DrawCircle(brushList[3], pointLightsList[3]);
        }
        private void TurnONCarOrange()
        {
            DrawCircle(brushList[4], pointLightsList[1]);
            DrawCircle(brushList[4], pointLightsList[4]);
        }
        private void TurnONCarGreen()
        {
            DrawCircle(brushList[5], pointLightsList[2]);
            DrawCircle(brushList[5], pointLightsList[5]);
        }

        private void TurnOFFPedestrianRed()
        {
            DrawCircle(brushList[0], pointLightsList[6]);
            DrawCircle(brushList[0], pointLightsList[8]);
        }
        private void TurnOFFPedestrianGreen()
        {
            DrawCircle(brushList[2], pointLightsList[7]);
            DrawCircle(brushList[2], pointLightsList[9]);
        }
        private void TurnONPedestrianRed()
        {
            DrawCircle(brushList[3], pointLightsList[6]);
            DrawCircle(brushList[3], pointLightsList[8]);
        }
        private void TurnONPedestrianGreen()
        {
            DrawCircle(brushList[5], pointLightsList[7]);
            DrawCircle(brushList[5], pointLightsList[9]);
        }


        private void TrafficLightsChange()
        {
            timerForAll.Stop();

            if (mode == "CarGreen")
            {
                TurnONCarGreen();
                timerForAll.Interval = 20000;
                mode = "CarGreenBlink";
                stateCounter = false;

                //ped
                TurnONPedestrianRed();

                timeCounter = 0;
                timerStopage.Start();

            }
            else if (mode == "CarGreenBlink")
            {
                //treba upaliti zeleno
                if (stateCounter == true)
                {
                    TurnONCarGreen();
                    stateCounter = false;
                }
                //treba ugasiti zeleno
                else
                {
                    TurnOFFCarGreen();
                    stateCounter = true;
                }
                timeBlinkCounter++;
                timerForAll.Interval = 500;

                if (timeBlinkCounter == 7)
                {                
                    timeBlinkCounter = 0;
                    TurnOFFCarGreen();
                    TurnONCarOrange();
                    mode = "AfterCarOrange";
                    timerForAll.Interval = 2000;
                    stateCounter = false;
                }
            }
            else if (mode == "AfterCarOrange")
            {
                TurnOFFCarOrange();
                TurnONCarRed();
                mode = "TurnOnPedGreen";
                timerForAll.Interval = 2000;
            }
            else if (mode == "TurnOnPedGreen")
            {
                TurnOFFPedestrianRed();
                TurnONPedestrianGreen();
                mode = "PedGreenBlink";
                timerForAll.Interval = 8000;
            }
            else if (mode == "PedGreenBlink")
            {
                //treba upaliti zeleno
                if (stateCounter == true)
                {
                    TurnONPedestrianGreen();
                    stateCounter = false;
                }
                //treba ugasiti zeleno
                else
                {
                    TurnOFFPedestrianGreen();
                    stateCounter = true;
                }
                timeBlinkCounter++;
                timerForAll.Interval = 500;

                if (timeBlinkCounter == 7)
                {
                    timeBlinkCounter = 0;
                    TurnONPedestrianRed();
                    mode = "AfterCarRed";
                    timerForAll.Interval = 3000;
                    stateCounter = false;
                }

            }
            else if (mode == "AfterCarRed")
            {
                TurnONCarOrange();
                mode = "AfterCarRedOrangeToGreen";
                timerForAll.Interval = 2000;
            }
            else if (mode == "AfterCarRedOrangeToGreen")
            {
                TurnOFFCarRed();
                TurnOFFCarOrange();
                TurnONCarGreen();

                mode = "CarGreenBlink";
                timerForAll.Interval = 20000;

                timeCounter = 0;
                timerStopage.Start();

            }
            else if (mode == "OrangeBlinkAllTheTime")
            {
                timerForAll.Interval = 500;

                //treba upaliti narandasto
                if (stateCounter == true)
                {
                    TurnONCarOrange();
                    stateCounter = false;
                }
                //treba ugasiti narandasto
                else
                {
                    TurnOFFCarOrange();
                    stateCounter = true;
                }
  
            }
            
            timerForAll.Start();
        }
        
        private void timerForAll_Tick(object sender, EventArgs e)
        {
            TrafficLightsChange();
        }

        private void btnStartScene_Click(object sender, EventArgs e)
        {
            if (sceneIsOn == false)
            {
                mode = "AfterCarRed";
                TurnONCarRed();
                TurnONPedestrianRed();
                TurnOFFCarOrange();

                timerForAll.Interval = 3000;
                timerForAll.Start();
                sceneIsOn = true;
                btnStartScene.Text = "Turn OFF traffic lights";
            }
            else if(sceneIsOn == true)
            {
                sceneIsOn = false;
                btnStartScene.Text = "Turn ON traffic lights";
                TurnOFFCarGreen();
                TurnOFFCarOrange();
                TurnOFFCarRed();
                TurnOFFPedestrianGreen();
                TurnOFFPedestrianRed();
                timerForAll.Stop();
                timerStopage.Stop();
                mode = "OrangeBlinkAllTheTime";

                pressPedButton = false;
                stateCounter = false;
                timeCounter = 0;
                stateCounter = false;
                TrafficLightsChange();


            }

        }
        private void btn_TurnONPedGreen_Click(object sender, EventArgs e)
        {
            if((timeCounter >= 10) && (mode == "CarGreenBlink"))
            {
                timerStopage.Stop();
                timerForAll.Stop();
                lb_PedWait.Text = "";
                timeCounter = 0;
                stateCounter = false;
                mode = "CarGreenBlink";
                TrafficLightsChange();         
            }
            else if(mode == "CarGreenBlink")
            {
                pressPedButton = true;
            }
            
        }

        private void timerStopage_Tick(object sender, EventArgs e)
        {
            if(mode == "CarGreenBlink")
            {
                timeCounter++;
                lb_PedWait.Text = 20 - timeCounter  + "";
            }
            if(timeCounter >= 20)
            {
                timerStopage.Stop();
                lb_PedWait.Text = "";
            }
            if(pressPedButton && timeCounter < 10)
            {
                lb_PedWait.Text = 10 - timeCounter + "";
            }
            if(timeCounter >= 10 && pressPedButton)
            {
                timerStopage.Stop();
                timerForAll.Stop();
                lb_PedWait.Text = "";
                timeCounter = 0;
                stateCounter = false;
                mode = "CarGreenBlink";
                TrafficLightsChange();
            }
            
        }

       
    }
}
