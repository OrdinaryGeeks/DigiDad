using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DigiDad_Android
{
    public  class VideoThumbnailedView :  ImageView
    {

        Paint textPaint;
        Paint ovalPaint;
        Android.Graphics.Point textLocation;
        Typeface textTypeFace;
        Rect tempBounds;
        string text;
        public float textWidth;
        public float textHeight;

        RectF bounds;

        int width;
        int height;
        public VideoThumbnailedView(Context context, IAttributeSet attrs) : base(context, attrs)
        {


            Initialize();

        }

        public void setWidthAndHeight(int Width, int Height)
        {
            width = Width;
            height = Height;
        }
        public void setTextLocation(int x, int y)
        {

            textLocation.X = x;
            textLocation.Y = y;

        }

        public void setText(String Text)
        {
            text = Text;

            getTextSize();

        }
        public void getTextSize()
        {

            /*  using (Graphics graphics =Graphics.FromImage(new System.Drawing.Bitmap(1, 1)))
              {
                  System.Drawing.SizeF size = graphics.MeasureString(text, new Font("Sans Serif", 40, FontStyle.Regular, GraphicsUnit.Point));

                  float[] sizeFloat = new float[2];
                  textWidth = size.Width;
                  textHeight= size.Height;
                 // return  sizeFloat;
              }
            */
            //  tempBounds = new Rect();

           
            textPaint.GetTextBounds(text, 0, text.Length, tempBounds);
            textHeight = tempBounds.Height();
            textWidth = tempBounds.Width();
            bounds.Bottom = tempBounds.Bottom + textLocation.Y;
            bounds.Left = tempBounds.Left + textLocation.X;
            bounds.Right = tempBounds.Right + textLocation.X;
            bounds.Top = tempBounds.Top + textLocation.Y;
            //   return new float[] { };
        }
        public void Initialize()
        {
            textLocation = new Android.Graphics.Point();

            ovalPaint = new Paint(PaintFlags.AntiAlias);
            ovalPaint.Color = Android.Graphics.Color.Black;
            tempBounds = new Rect();
            textPaint = new Paint(PaintFlags.AntiAlias);
            textPaint.TextSize = 40;
            textPaint.SetTypeface(Typeface.SansSerif);
            textPaint.Color = Android.Graphics.Color.White;
            bounds = new RectF();

        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);

        

            
        }

       


        override
            protected void OnDraw(Canvas canvas)
        {

            base.OnDraw(canvas);


            Utils layoutUtils = new Utils(this.LayoutParameters.Width, this.LayoutParameters.Height);

          //  getTextSize();
            layoutUtils.setVideoThumbnailTextLocation(this);
            getBounds();
            //  canvas.DrawText()
            canvas.DrawOval(bounds, ovalPaint);
           canvas.DrawText(text, textLocation.X, textLocation.Y,textPaint);
  
          //  PostInvalidate();
        }
        public void getBounds()
        {
            bounds.Bottom = tempBounds.Bottom + textLocation.Y +10;
            bounds.Left = tempBounds.Left + textLocation.X - 10;
            bounds.Right = tempBounds.Right + textLocation.X +10;
            bounds.Top = tempBounds.Top + textLocation.Y -10;
        }
    }
}