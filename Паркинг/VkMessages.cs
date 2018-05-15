using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using VkNet;
using VkNet.Model.RequestParams;
using System.Drawing;
using System.IO;
using System.Collections.ObjectModel;
using VkNet.Model.Attachments;

namespace Паркинг
{
    public class VkMessages
    {
        private VkApi vkAcc;

        private ReadOnlyCollection<Photo> ImageToVK(Image img)
        {
            var uploadServer = vkAcc.Photo.GetMessagesUploadServer(486948783);
            MemoryStream stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            stream.Position = 0;
            BinaryReader binaryReader = new BinaryReader(stream);
            byte[] data = binaryReader.ReadBytes((int)stream.Length);

            var response = UploadImage(uploadServer.UploadUrl, data);
            response.Wait();
            return vkAcc.Photo.SaveMessagesPhoto(response.Result.ToString());
        }

        private async Task<string> UploadImage(string url, byte[] data)
        {
            using (var client = new HttpClient())
            {
                var requestContent = new MultipartFormDataContent();
                var imageContent = new ByteArrayContent(data);
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                requestContent.Add(imageContent, "photo", "image.jpg");

                var response = await client.PostAsync(url, requestContent);

                return await response.Content.ReadAsStringAsync();
            }
        }

        public VkMessages(VkApi value)
        {
            vkAcc = value;
        }

        public void SendMsg(int id, string msg)
        {
            vkAcc.Messages.SendAsync(new MessagesSendParams
            {
                UserId = id,
                Message = msg
            });
        }

        public void SendMsg(int id, string msg, long answer)
        {
            vkAcc.Messages.SendAsync(new MessagesSendParams
            {
                UserId = id,
                Message = msg,
                ForwardMessages = new long[] { answer }
            });
        }

        public void SendMsg(int id, string msg, Image img)
        {
            ReadOnlyCollection<Photo> photo = ImageToVK(img);
            vkAcc.Messages.SendAsync(new MessagesSendParams
            {
                UserId = id,
                Message = msg,
                Attachments = photo
            });
        }

        public void SendMsg(int id, string msg, Image img, long answer)
        {
            ReadOnlyCollection<Photo> photo = ImageToVK(img);
            vkAcc.Messages.SendAsync(new MessagesSendParams
            {
                UserId = id,
                Message = msg,
                Attachments = photo,
                ForwardMessages = new long[] { answer }
            });
        }
    }
}
