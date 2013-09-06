using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using NationalInstruments.UI.WindowsForms;

namespace SampleControls
{
    class SaveTransparentGIF
    {
        public void SaveImage(Image inputImage, String fileName)
        {
            ConvertImage(inputImage, fileName, Color.White);
        }

        public void SaveImage(String fileName, Color transparentColor, ControlBase control)
        {
            //This sets the plot area and other aspects of the plot to
            //the color that was specified as transparent so that these
            //items will be transparent in the output image. Can be useful
            //if you have other items that are white in your control. 
            //Otherwise these can be interpreted as transparent.
          
            control.BeginUpdate();
            Color PlotAreaColor = Color.Transparent;
            Color BackColor = control.BackColor;
            Color CaptionBackColor = control.CaptionBackColor;

            if (control is Graph)
            {
                PlotAreaColor = ((Graph)control).PlotAreaColor;
                ((Graph)control).PlotAreaColor = transparentColor;
            }
            control.BackColor = transparentColor;
            control.CaptionBackColor = transparentColor;
            
            ConvertImage(control.ToImage(), fileName, transparentColor);

            //Resetting everything back as it originally was
            if (control is Graph)
                ((Graph)control).PlotAreaColor = PlotAreaColor;
            control.BackColor = BackColor;
            control.CaptionBackColor = CaptionBackColor;

            control.EndUpdate();
        }

        private void ConvertImage(Image inputImage, String fileName, Color transparentColor)
        {
            //This quantizer is an octree quantizer which is supposed
            //to be fairly efficient at converting colors for Gifs.          
            ImageManipulation.OctreeQuantizer quantizer = new ImageManipulation.OctreeQuantizer(255, 8);

            Bitmap myBitmap;
            //This converts our image using the Octree Quantizer.
            //It creates a new color palette object for the bmp.
            myBitmap = quantizer.Quantize(inputImage);

            //Taking the palette object and changing it to set
            //what we want to be transparent
            ColorPalette pal = myBitmap.Palette;

            //This loop goes through the whole color palette
            //and sets the alpha value for all entries that contain
            //the white color to 0 making them transparent.
            for (int i = 0; i < pal.Entries.Length; i++)
            {
                int myColor = pal.Entries[i].ToArgb();
                                
                if (myColor == transparentColor.ToArgb())
                {                   
                    //Leaving the RGB values the same but changing alpha to 0
                    pal.Entries[i] = Color.FromArgb(0, pal.Entries[i].R, pal.Entries[i].G, pal.Entries[i].B);
                }
            }

            //Set the palette to be the new palette that we modified
            myBitmap.Palette = pal;
            //Write out to file
            myBitmap.Save(fileName, ImageFormat.Gif);
        }
    }
}
