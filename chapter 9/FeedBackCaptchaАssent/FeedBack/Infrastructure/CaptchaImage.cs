using SkiaSharp;

namespace FeedBack.Infrastructure
{
    public class CaptchaImage
    {
        private string text; // текст капчи
        private int width; // ширина картинки
        private int height; // высота картинки
        public SKBitmap image { get; set; } = null!; // изображение капчи
        public CaptchaImage(string s, int width, int height)
        {
            text = s;
            this.width = width;
            this.height = height;
            GenerateImage();
        }
        // создаем изображение
        private void GenerateImage()
        {
            image = new SKBitmap(width, height);
            using (var canvas = new SKCanvas(image))
            {
                canvas.Clear(SKColors.White);
                using (var paint = new SKPaint())
                {
                    paint.TextSize = 32;
                    paint.IsAntialias = true;
                    paint.Typeface = SKTypeface.FromFamilyName("Arial", SKFontStyleWeight.Bold, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright);
                    paint.Color = SKColors.Red;
                    canvas.DrawText(text, image.Width / 4, 3 * image.Height / 4, paint);
                }
            }
        }
        ~CaptchaImage()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) image.Dispose();
        }
    }
}
