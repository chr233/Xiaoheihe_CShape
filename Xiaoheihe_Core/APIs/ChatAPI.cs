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


    }
}
