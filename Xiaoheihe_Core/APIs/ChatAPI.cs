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
        public static async Task<UserMessageResponse> GetUserMessageList(this XiaoheiheClient xhh, uint userID)
        {
            return await xhh.GetUserMessageList(userID, 0, false).ConfigureAwait(false);
        }

        /// <summary>
        /// ��ȡ��ָ���û��������¼
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="pointer">ʱ��ָ��</param>
        /// <param name="isNewer">�ǲ���newer, ����Ϊolder</param>
        /// <returns></returns>
        public static async Task<UserMessageResponse> GetUserMessageList(this XiaoheiheClient xhh, uint userID, uint pointer, bool isNewer)
        {
            string subPath = "/chat/get_message_list/";

            Dictionary<string, string> extraParams = new(2)
            {
                { "userid", userID.ToString() },
            };

            if (pointer != 0)
            {
                extraParams.Add(isNewer ? "newer" : "older", pointer.ToString());
            }

            UserMessageResponse response = await xhh.BasicRequest<UserMessageResponse>(HttpMethod.Get, subPath, extraParams).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// ����˽����Ϣ
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static async Task<BasicResponse> SendMessage(this XiaoheiheClient xhh, uint userID, string text)
        {
            return await xhh.SendMessage(userID, text, "").ConfigureAwait(false);
        }

        /// <summary>
        /// ����˽����Ϣ
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="text">��Ϣ����</param>
        /// <param name="img">ͼƬ��ַ</param>
        /// <returns></returns>
        public static async Task<BasicResponse> SendMessage(this XiaoheiheClient xhh, uint userID, string text, string img)
        {
            string subPath = "/chat/send_message/";

            Dictionary<string, string> extraParams = new(1)
            {
                { "userid", userID.ToString() },
            };

            Dictionary<string, string> formData = new(2)
            {
                { "text", text },
                { "img", img },
            };

            FormUrlEncodedContent content = new(formData);

            BasicResponse response = await xhh.BasicRequest<BasicResponse>(HttpMethod.Post, subPath, extraParams, content).ConfigureAwait(false);

            return response;
        }
    }
}
