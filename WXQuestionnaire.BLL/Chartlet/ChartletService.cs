using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WXQuestionnaire.DAL;
using WXQuestionnaire.Tool;
using mChartlet = WXQuestionnaire.Model.Chartlet;

namespace WXQuestionnaire.BLL.Chartlet
{
    public class ChartletService
    {
        public mChartlet.Chartlet GenerateChartlet(string serverID, string msg, string signName)
        {
            try
            {
                if (string.IsNullOrEmpty(serverID)) return null;
                using (EFContext context = new EFContext())
                {
                    var charlet = new mChartlet.Chartlet
                    {
                        ServerIDWX = serverID,
                        MsgText = msg,
                        SignName = signName,
                    };

                    // 从微信服务器下载图片
                    var oriImgPath = WXUtil.DownloadFile(serverID,".jpg");
                    if (oriImgPath == null) return null;
                    charlet.OriginalImgPath = oriImgPath;

                    // 生成图片
                    var suc = DrawChartlet(charlet);
                    if (!suc) return null;

                    charlet.CreateDate = DateTime.Now;
                    context.Chartlets.Add(charlet);
                    context.SaveChanges();

                    return charlet;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return null;
            }
            
        }

        public mChartlet.Chartlet GetChartlet(int id)
        {
            using (EFContext context = new EFContext())
            {
               var chartlet = context.Chartlets.Where(c => c.ID == id).FirstOrDefault();
               return chartlet;
            }
        }

        private bool DrawChartlet(mChartlet.Chartlet chartlet) 
        {
            try
            {
                string srcImgPath = HttpContext.Current.Server.MapPath(chartlet.OriginalImgPath);

                Bitmap srcBitmap = new Bitmap(srcImgPath);
                var fonts = new System.Drawing.Text.PrivateFontCollection();
                fonts.AddFontFile(HttpContext.Current.Server.MapPath("/fonts/新蒂黑板报.ttf"));
                Font f = new Font(fonts.Families[0],9);
                Brush b = Brushes.Black;
                int paddingInner = 15; 
                int spaceImg = 20;
                int spaceMsg = 5;
                int spaceName = 50;
                int spaceNameRight=15;
                int spaceBottom = 0;

                // 目标图的宽=原图的宽
                // 目标图的高 = 原图的高+间隙+所有文字的高+间隙+签名的高
                int dstWith = srcBitmap.Width < 320 ? 320 : srcBitmap.Width;
                dstWith = dstWith > 420 ? 420 : dstWith;

                float rate = (float)dstWith / srcBitmap.Width;
                int rateHeight = Convert.ToInt32(rate * srcBitmap.Height);

                int dstHeight = rateHeight;
                List<string> msgList = new List<string>();
                List<string> oriMsgList = chartlet.MsgText.Split(new string[] { "\n"}, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var item in oriMsgList)
                {
                    msgList.AddRange(StrUtil.SplitStringByWidth(item,dstWith, f));
                }
                int normalTextHeight = StrUtil.MeasureString(oriMsgList[0], f).Height;
                dstHeight = rateHeight + spaceImg + msgList.Count * normalTextHeight +
                    (msgList.Count - 1) * spaceMsg + spaceName +normalTextHeight+ spaceBottom;

                // 开始绘图
                Bitmap dstBitmap = new Bitmap(dstWith + paddingInner * 2, dstHeight + paddingInner * 2);
                using (Graphics g = Graphics.FromImage(dstBitmap))
                {
                    int x = paddingInner;
                    int y = paddingInner;
                    g.FillRectangle(Brushes.White, 0, 0, dstBitmap.Width, dstBitmap.Height);
                    Rectangle r = new Rectangle(new Point(x, y), new Size(dstWith, rateHeight));
                    g.DrawImage(srcBitmap, r);
                    y = y+rateHeight + spaceImg;
                    for (int i = 0; i < msgList.Count; i++)
                    {
                        Size currentSize= StrUtil.MeasureString(msgList[i],f);
                        g.DrawString(msgList[i], f, b, new PointF((dstWith - currentSize.Width) / 2 +x, y));

                        y += (currentSize.Height + ((i == (msgList.Count - 1)) ? spaceName : spaceMsg));
                    }
                    var nameSize = StrUtil.MeasureString("by  "+chartlet.SignName,f);
                    g.DrawString("by  "+chartlet.SignName, f, b, new PointF(dstWith - nameSize.Width - spaceNameRight +paddingInner, y));
                }

                // 为图片加相框
                //int paddingOutterTop = 60;
                //int paddingOutterLeft = 60;
                //int paddingOutterRight = 20;
                //int paddingOutterBottom = 20;
                //Bitmap frameBitmap = new Bitmap(dstBitmap.Width+paddingOutterLeft+paddingOutterRight,dstBitmap.Height+paddingOutterTop+paddingOutterBottom);
                //using (Graphics g = Graphics.FromImage(frameBitmap))
                //{
                //    string frameBgImgPath = HttpContext.Current.Server.MapPath("/img/bg-chartlet.jpg");
                //    Bitmap frameBgImg = new Bitmap(frameBgImgPath);
                //    g.DrawImage(frameBgImg, 0, 0);
                //    Rectangle r = new Rectangle(new Point(paddingOutterLeft, paddingOutterTop), new Size(dstBitmap.Width, dstBitmap.Height));
                //    g.DrawImage(dstBitmap, r);
                //    frameBgImg.Dispose();
                //}

                string dstVirtualPath = "/Data/Chartlets/" + chartlet.ServerIDWX + ".jpg";
                string dstPath = HttpContext.Current.Server.MapPath(dstVirtualPath);
                dstBitmap.Save(dstPath);
                chartlet.BuildImgPath = dstVirtualPath;
                srcBitmap.Dispose();
                dstBitmap.Dispose();
                //frameBitmap.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                return false;
            }
        }
    }
}
