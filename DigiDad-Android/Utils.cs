using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using static Android.Views.ViewGroup;

namespace DigiDad_Android
{
    public class Utils
    {
        int numDifferentHeightSizes;
      //  int[] numEachSize;
        int[] bottomPaddingEachSizeMinusFooter;
        int[] topMarginAmounts;
        int[] heightEachSize;
        int widthEachGalleryImage;
        //float[] sideMarginEachSize;
        int height;
        int width;

        public Utils(int width, int height)
        {
            this.height = height;
            this.width = width;


        }

        public int getIntSizeFromPercentage(int valueMax, double percentage)
        {
            return int.Parse(Math.Floor((double)valueMax * percentage).ToString());


        }

        public void setHeightClasses(int numHeights)
        {
            numDifferentHeightSizes = numHeights;

            topMarginAmounts = new int[numHeights];
            bottomPaddingEachSizeMinusFooter = new int[numHeights - 1];
            heightEachSize = new int[numHeights];

        }

        public void setSingularWidth(double Percentage)
        {
            widthEachGalleryImage = getIntSizeFromPercentage(width, .333);

        }

        public void setGalleryItemViewDimensions(View v)
        {
            MarginLayoutParams mlp = (MarginLayoutParams)v.LayoutParameters;
            // mlp.TopMargin = getTopMargin(heightIndex);
            mlp.Height = widthEachGalleryImage - 40;
            mlp.Width = widthEachGalleryImage - 40;
            mlp.LeftMargin = 10;
            mlp.RightMargin = 10;
            v.LayoutParameters = mlp;
            



        }
        public void setHeight(int heightIndex, double percentage)
        {
            heightEachSize[heightIndex] = getIntSizeFromPercentage(height, percentage);


        }
        public void setTopMargin(int marginIndex, double percentage)
        {
            topMarginAmounts[marginIndex] = getIntSizeFromPercentage(height, percentage);
        }
        public void setViewDimensionsHeight(View v, int heightIndex)
        {


            MarginLayoutParams mlp = (MarginLayoutParams)v.LayoutParameters;
          // mlp.TopMargin = getTopMargin(heightIndex);
            mlp.Height = getHeightSize(heightIndex);
           
            v.LayoutParameters = mlp;

        }

       
        public void setViewTopMargins(View v, int heightIndex)
        {
            MarginLayoutParams mlp = (MarginLayoutParams)v.LayoutParameters;
            mlp.TopMargin = getTopMargin(heightIndex);
            v.LayoutParameters = mlp;

        }
        public void setViewDimensions(View v, int heightIndex)
        {
          //  v.LayoutParameters.Height = getHeightSize(heightIndex);
         //   v.LayoutParameters.Width = getHeightSize(heightIndex);
            // MarginLa v.LayoutParameters as ViewGroup.MarginLayoutParams;

            MarginLayoutParams mlp = (MarginLayoutParams)v.LayoutParameters;
            mlp.TopMargin = getTopMargin(heightIndex);
            mlp.Height = getHeightSize(heightIndex)- mlp.TopMargin ;
            mlp.Width = getHeightSize(heightIndex) - mlp.TopMargin ;
            v.LayoutParameters = mlp;
        }
        public void setTextViewDimensions(View v, int heightIndex)
        {
            //  v.LayoutParameters.Height = getHeightSize(heightIndex);
            //   v.LayoutParameters.Width = getHeightSize(heightIndex);
            // MarginLa v.LayoutParameters as ViewGroup.MarginLayoutParams;

            MarginLayoutParams mlp = (MarginLayoutParams)v.LayoutParameters;
            mlp.TopMargin = getTopMargin(heightIndex);
            mlp.Height = getHeightSize(heightIndex) - mlp.TopMargin;
            //  mlp.Width =int.Parse(((TextView)v).TextSize.ToString()) * ((TextView)v).Text.Length;
            mlp.Width = 200;
            //mlp.Width = getHeightSize(heightIndex) - mlp.TopMargin;
            v.LayoutParameters = mlp;
        }



        public int getHeightSize(int heightIndex)
        {

            return heightEachSize[heightIndex];
        }
        public int getTopMargin(int heightIndex)
        {

            return topMarginAmounts[heightIndex];

        }
    }
}