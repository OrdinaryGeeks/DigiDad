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
    public  class ThumbnailedView :  ImageView
    {

        Paint textPaint;
        Android.Graphics.Point textLocation;
        Typeface textTypeFace;
        String text;
        public float textWidth;
        public float textHeight;

        int width;
        int height;
        public ThumbnailedView(Context context, IAttributeSet attrs) : base(context, attrs)
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
            Rect bounds = new Rect();
            textPaint.GetTextBounds(text, 0, text.Length, bounds);
            textHeight = bounds.Height();
            textWidth = bounds.Width();
         //   return new float[] { };
        }
        public void Initialize()
        {
            textLocation = new Android.Graphics.Point();
           

            textPaint = new Paint(PaintFlags.AntiAlias);
            textPaint.TextSize = 40;
            textPaint.SetTypeface(Typeface.SansSerif);
            textPaint.Color = Android.Graphics.Color.White;

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

            //       getTextSize();
            //layoutUtils.setViewTextLocation(this);

            layoutUtils.setThumbnailTextLocation(this);
            //  canvas.DrawText()
            //if (text!="Cooking")
            canvas.DrawText(text,textLocation.X, textLocation.Y,textPaint);

          //  PostInvalidate();
        }

    }
}