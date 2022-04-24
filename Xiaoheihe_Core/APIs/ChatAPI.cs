using Xiaoheihe_Core.Data;

namespace Xiaoheihe_Core.APIs
{
    public static class ChatAPI
    {
        /// <summary>
        /// ��ȡ��ָ���û��������¼
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static UserMessageResponse GetUserMessageList(this XiaoheiheClient xhh, uint userID)
        {
            return xhh.GetUserMessageList(userID, 0, false);
        }

        /// <summary>
        /// ��ȡ��ָ���û��������¼
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="pointer">ʱ��ָ��</param>
        /// <param name="isNewer">�ǲ���newer, ����Ϊolder</param>
        /// <returns></returns>
        public static UserMessageResponse GetUserMessageList(this XiaoheiheClient xhh, uint userID, uint pointer, bool isNewer)
        {
            string subPath = "/chat/get_message_list/";

            Dictionary<string, string> extendParams = new(2)
            {
                { "userid", userID.ToString() },
            };

            if (pointer != 0)
            {
                extendParams.Add(isNewer ? "newer" : "older", pointer.ToString());
            }

            UserMessageResponse response = xhh.BasicRequest<UserMessageResponse>(HttpMethod.Get, subPath, extendParams);

            return response;
        }

        /// <summary>
        /// ����˽����Ϣ
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static BasicResponse SendMessage(this XiaoheiheClient xhh, uint userID, string text)
        {
            return xhh.SendMessage(userID, text, "");
        }

        /// <summary>
        /// ����˽����Ϣ
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="text">��Ϣ����</param>
        /// <param name="img">ͼƬ��ַ</param>
        /// <returns></returns>
        public static BasicResponse SendMessage(this XiaoheiheClient xhh, uint userID, string text, string img)
        {
            string subPath = "/chat/send_message/";

            Dictionary<string, string> extendParams = new(1)
            {
                { "userid", userID.ToString() },
            };

            Dictionary<string, string> formData = new(2)
            {
                { "text", text },
                { "img", img },
            };

            FormUrlEncodedContent content = new(formData);

            BasicResponse response = xhh.BasicRequest<BasicResponse>(HttpMethod.Post, subPath, extendParams, content);

            return response;
        }
    }
}
