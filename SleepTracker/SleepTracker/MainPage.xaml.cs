using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SleepTracker
{
    public partial class MainPage : ContentPage
    {   
        bool tickedOnce = false;
        DateTime futureDate;

        public MainPage()
        {
            InitializeComponent();
            
            Device.StartTimer(TimeSpan.FromSeconds(1 / 60f), () =>
            {
                canvasView.InvalidateSurface();
                return true;
            });

            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                slider.TranslationX = -80;
                slider.TranslateTo(80, 0, 800, Easing.Linear);

                return true;
            });

            DateTime alarmDate = TimeSelect.userSelectedDateTime;
            futureDate = alarmDate;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                OnTimerTick();
                return true; // runs again, or false to stop
            });

        }

        SKPath path = new SKPath();
        float arcLength = 105;
        

        private bool OnTimerTick()
        {
            Console.WriteLine("Sylas this is the time " + futureDate);
            if (DateTime.Now >= futureDate && tickedOnce == false)
            {
                DisplayAlert("Timer Alert", "The timer has elapsed", "OK");
                tickedOnce = true;
                return true;
            }
            else
                return false;
        }

        private SKPaint GetPaintColor(SKPaintStyle style, string hexColor, float strokeWidth = 0, SKStrokeCap cap = SKStrokeCap.Round, bool IsAntialias = true)
        {
            return new SKPaint
            {
                Style = style,
                StrokeWidth = strokeWidth,
                Color = string.IsNullOrWhiteSpace(hexColor) ? SKColors.White : SKColor.Parse(hexColor),
                StrokeCap = cap,
                IsAntialias = IsAntialias
            };
        }

        private void canvas_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            SKPaint strokePaint = GetPaintColor(SKPaintStyle.Stroke, null, 10, SKStrokeCap.Square);
            SKPaint dotPaint = GetPaintColor(SKPaintStyle.Fill, "#DE0469");
            SKPaint hrPaint = GetPaintColor(SKPaintStyle.Stroke, "#262626", 4, SKStrokeCap.Square);
            SKPaint minPaint = GetPaintColor(SKPaintStyle.Stroke, "#DE0469", 2, SKStrokeCap.Square);
            SKPaint bgPaint = GetPaintColor(SKPaintStyle.Fill, "#FFFFFF");

            canvas.Clear();

            SKRect arcRect = new SKRect(10, 10, info.Width - 10, info.Height - 10);
            SKRect bgRect = new SKRect(25, 25, info.Width - 25, info.Height - 25);
            canvas.DrawOval(bgRect, bgPaint);

            strokePaint.Shader = SKShader.CreateLinearGradient(
                               new SKPoint(arcRect.Left, arcRect.Top),
                               new SKPoint(arcRect.Right, arcRect.Bottom),
                               new SKColor[] { SKColor.Parse("#DE0469"), SKColors.Transparent },
                               new float[] { 0, 1 },
                               SKShaderTileMode.Repeat);

            path.ArcTo(arcRect, 45, arcLength, true);
            canvas.DrawPath(path, strokePaint);

            canvas.Translate(info.Width / 2, info.Height / 2);
            canvas.Scale(info.Width / 200f);

            canvas.Save();
            canvas.RotateDegrees(240);
            canvas.DrawCircle(0, -75, 2, dotPaint);
            canvas.Restore();

            DateTime dateTime = DateTime.Now;

            //Draw hour hand
            canvas.Save();
            canvas.RotateDegrees(30 * dateTime.Hour + dateTime.Minute / 2f);
            canvas.DrawLine(0, 5, 0, -60, hrPaint);
            canvas.Restore();

            //Draw minute hand
            canvas.Save();
            canvas.RotateDegrees(6 * dateTime.Minute + dateTime.Second / 10f);
            canvas.DrawLine(0, 10, 0, -90, minPaint);
            canvas.Restore();

            canvas.DrawCircle(0, 0, 5, dotPaint);

            secondsTxt.Text = dateTime.Second.ToString("00");
            timeTxt.Text = dateTime.ToString("hh:mm");
            periodTxt.Text = dateTime.Hour >= 12 ? "PM" : "AM";

            var alarmDiff = futureDate - dateTime;
            alarmTxt.Text = $"{alarmDiff.Hours}h {alarmDiff.Minutes}m until next alarm";

        }
    }
}
