﻿using System;
using System.Drawing;
using CoreGraphics;
using Foundation;
using InPowerIOS.Model;
using UIKit;

namespace InPowerIOS.NewChat
{

    public class GroupChatBubbleCell : UITableViewCell
    {
        public static NSString KeyLeft = new NSString("Incoming");
        public static NSString KeyRight = new NSString("Outgoing");
        public static UIImage bleft, bright, left, right;
        public static UIImage singleGray, doubleGray, doubleBlue, wait;
        public static UIFont font = UIFont.SystemFontOfSize(14);
        public static UIFont fontSenderName = UIFont.SystemFontOfSize(12,UIFontWeight.Bold);
        public static UIFont fontDateStamp = UIFont.SystemFontOfSize(10);
        UIView view;
        UIView imageView;
        UIImageView StatusTick;
        UILabel lblSenderName;
        UILabel lblMessage;
        UILabel lblTime;
        bool isLeft;

        static GroupChatBubbleCell()
        {
            bright = UIImage.FromFile("green.png");
            bleft = UIImage.FromFile("grey.png");
            singleGray = UIImage.FromFile("singleGray.png");
            doubleGray = UIImage.FromFile("grey.png");
            doubleBlue = UIImage.FromFile("doubleBlue.png");
            wait = UIImage.FromFile("grey.png");

            // buggy, see https://bugzilla.xamarin.com/show_bug.cgi?id=6177
            //left = bleft.CreateResizableImage (new UIEdgeInsets (10, 16, 18, 26));
            //right = bright.CreateResizableImage (new UIEdgeInsets (11, 11, 17, 18));
            left = bleft.StretchableImage(26, 16);
            right = bright.StretchableImage(11, 11);
        }

        public GroupChatBubbleCell(bool isLeft)
            : base(UITableViewCellStyle.Default, isLeft ? KeyLeft : KeyRight)
        {
            var rect = new RectangleF(0, 0, 1, 1);
            this.isLeft = isLeft;
            view = new UIView(rect);
            imageView = new UIImageView(isLeft ? left : right);
            view.AddSubview(imageView);
            lblSenderName = new UILabel(rect)
            {
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0,
                Font = fontSenderName,
                BackgroundColor = UIColor.Clear,
                TextColor = UIColor.Purple,

            };
            view.AddSubview(lblSenderName);
            lblMessage = new UILabel(rect)
            {
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0,
                Font = font,
                BackgroundColor = UIColor.Clear
            };
            view.AddSubview(lblMessage);
            lblTime = new UILabel(rect)
            {
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0,
                Font = fontDateStamp,
                TextColor = UIColor.LightGray,
                BackgroundColor = UIColor.Clear,
                TextAlignment = UITextAlignment.Right
            };
            view.AddSubview(lblTime);
            if (!this.isLeft)
            {
                StatusTick = new UIImageView(doubleBlue);
                view.AddSubview(StatusTick);
            }
            ContentView.Add(view);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            var frame = ContentView.Frame;
            var sizeSenderName = GetSizeForText(this, lblSenderName.Text) + BubblePadding;
            var sizeMessage = GetSizeForText(this, lblMessage.Text) + BubblePadding;
            var sizeTime = GetSizeForText(this, lblTime.Text)+ BubblePadding;

            SizeF StatusImageSize = new SizeF(sizeTime.Height + 5, sizeTime.Height);
            float ImageSizeWidth =(sizeSenderName.Width > sizeMessage.Width) ? sizeSenderName.Width : (sizeMessage.Width > sizeTime.Width) ? sizeMessage.Width :  (sizeTime.Width + StatusImageSize.Width);
            SizeF TimeLabelSize= new SizeF(ImageSizeWidth-sizeTime.Height + 10, sizeTime.Height );
          
            SizeF ImageSize = new SizeF(ImageSizeWidth,sizeSenderName.Height + sizeMessage.Height + sizeTime.Height - BubblePadding.Height);
            imageView.Frame = new RectangleF(new PointF((float)(isLeft ? 10 : frame.Width - ImageSizeWidth - 10), (float)frame.Y), ImageSize);
            view.SetNeedsDisplay();
            frame = imageView.Frame;
            lblSenderName.Frame = new RectangleF(new PointF((float)(frame.X + (isLeft ? 12 : 8)), (float)(frame.Y + 5)), sizeSenderName - BubblePadding);
            lblMessage.Frame = new RectangleF(new PointF((float)(frame.X + (isLeft ? 12 : 8)), (float)(frame.Y + sizeSenderName.Height)), sizeMessage - BubblePadding );
            lblTime.Frame = new RectangleF(new PointF((float)(frame.X + (isLeft ? 10 : 8)), (float)(frame.Y + sizeSenderName.Height+ sizeMessage.Height -10)), TimeLabelSize - BubblePadding);
            if (!this.isLeft)
            {
                StatusTick.Frame = new RectangleF(new PointF((float)(frame.X + (isLeft ? frame.Width - BubblePadding.Width + 5 - frame.X : frame.Width - BubblePadding.Width - 10)), (float)(frame.Y + sizeSenderName.Height + sizeMessage.Height - 10)), StatusImageSize - BubblePadding);
            }
        }

        static internal SizeF BubblePadding = new SizeF(22, 16);
        //static internal SizeF label1Padding = new SizeF(10, 0);
        static internal SizeF TimeLablePadding = new SizeF(22, 60);

        static internal SizeF GetSizeForText(UIView tv, string text)
        {
            SizeF textSize;
            if (text == null)
                text = "";
            using (NSString nssSomeString = new NSString(text))
            {
                textSize = (System.Drawing.SizeF)nssSomeString.StringSize(font, new SizeF((float)tv.Bounds.Width * .7f - 10 - 22, 99999), UILineBreakMode.WordWrap);
                //Console.WriteLine(textSize);
            }
            return textSize;
            // return tv.StringSize(text, font, new SizeF((float)tv.Bounds.Width * .7f - 10 - 22, 99999));
        }

        public void Update(GroupMessage item)
        {
            lblSenderName.Text = item.senderName + " : ";
            lblMessage.Text = item.MessageText;
            lblTime.Text = item.MessageTime.ToString("hh:mm tt"); ;

            var Status = (item.MessageId != 0) ? Repositories.GroupRepository.GetGroupMessageOverallStatusbyid(item.MessageId) : new GroupMessageStatus();
            if (!this.isLeft)
            {
                if (Status.IsRead)
                {
                    StatusTick.Image = doubleBlue;
                }

                else if (Status.IsRecieved)
                {
                    StatusTick.Image = doubleGray;
                }

                else if (Status.IsSend)
                {
                    StatusTick.Image = singleGray;
                }
                else
                {
                    StatusTick.Image = singleGray;
                }
            }
            SetNeedsLayout();
        }

        public static  SizeF GetHeight(UIView tv, string text1, string text2)
        {
            var sizeSenderName = GetSizeForText(tv, text1) + BubblePadding;
            var size1 = GetSizeForText(tv, text1) + BubblePadding;
            var size2 = GetSizeForText(tv, text2) + BubblePadding;

            SizeF SmallPadding = new SizeF(0, 5);

            return sizeSenderName + size1 + size2 + SmallPadding ;
        }
    }
  
}