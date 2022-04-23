using Xiaoheihe_Core.Data;

namespace Xiaoheihe_Core.APIs
{
    public static class UserAPI
    {
        /// <summary>
        /// ��ȡ�Լ��Ĺ�ע�����б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <returns></returns>
        public static FollowListResponse GetFollowingList(this XiaoheiheClient xhh)
        {
            return xhh.GetFollowingList(xhh.HeyboxID, 0);
        }

        /// <summary>
        /// ��ȡ��ע�����б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static FollowListResponse GetFollowingList(this XiaoheiheClient xhh, uint userID)
        {
            return xhh.GetFollowingList(userID, 0);
        }

        /// <summary>
        /// ��ȡ��ע�����б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static FollowListResponse GetFollowingList(this XiaoheiheClient xhh, uint userID, uint offset)
        {
            string subPath = "/bbs/app/profile/following/list";

            Dictionary<string, string> extraParams = new(3)
            {
                { "userid", userID.ToString() },
                { "offset", offset.ToString() },
                { "limit", "30" },
            };

            FollowListResponse response = xhh.BasicRequest<FollowListResponse>(HttpMethod.Get, subPath, extraParams);

            return response;
        }

        /// <summary>
        /// ��ȡ�Լ��ķ�˿�б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <returns></returns>
        public static FollowListResponse GetFollowerList(this XiaoheiheClient xhh)
        {
            return xhh.GetFollowerList(xhh.HeyboxID, 0);
        }

        /// <summary>
        /// ��ȡ��˿�б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static FollowListResponse GetFollowerList(this XiaoheiheClient xhh, uint userID)
        {
            return xhh.GetFollowerList(userID, 0);
        }

        /// <summary>
        /// ��ȡ��˿�б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static FollowListResponse GetFollowerList(this XiaoheiheClient xhh, uint userID, uint offset)
        {
            string subPath = "/bbs/app/profile/follower/list";

            Dictionary<string, string> extraParams = new(3)
            {
                { "userid", userID.ToString() },
                { "offset", offset.ToString() },
                { "limit", "30" },
            };

            FollowListResponse response = xhh.BasicRequest<FollowListResponse>(HttpMethod.Get, subPath, extraParams);

            return response;
        }

        /// <summary>
        /// ��ע�û�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static BasicResponse FollowUser(this XiaoheiheClient xhh, uint userID)
        {
            string subPath = "/bbs/app/profile/follow/user";

            Dictionary<string, string> formData = new(1)
            {
                { "following_id", userID.ToString() },
            };

            FormUrlEncodedContent content = new(formData);

            FollowListResponse response = xhh.BasicRequest<FollowListResponse>(HttpMethod.Post, subPath, content);

            return response;
        }

        /// <summary>
        /// ȡ���û�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static BasicResponse UnfollowUser(this XiaoheiheClient xhh, uint userID)
        {
            string subPath = "/bbs/app/profile/follow/user/cancel";

            Dictionary<string, string> formData = new(1)
            {
                { "following_id", userID.ToString() },
            };

            FormUrlEncodedContent content = new(formData);

            FollowListResponse response = xhh.BasicRequest<FollowListResponse>(HttpMethod.Post, subPath, content);

            return response;
        }

        /// <summary>
        /// ��ȡ�û���̬
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static UserEventsResponse GetUserEvents(this XiaoheiheClient xhh, uint userID)
        {
            return xhh.GetUserEvents(userID, 0);
        }

        /// <summary>
        /// ��ȡ�û���̬
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static UserEventsResponse GetUserEvents(this XiaoheiheClient xhh, uint userID, uint offset)
        {
            string subPath = "/bbs/app/profile/events";

            Dictionary<string, string> extendParams = new(3)
            {
                { "userid", userID.ToString() },
                { "offset", offset.ToString() },
                { "limit", "30" },
            };

            UserEventsResponse response = xhh.BasicRequest<UserEventsResponse>(HttpMethod.Get, subPath, extendParams);

            return response;
        }

        /// <summary>
        /// ��ȡ�Լ��ķ����б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <returns></returns>
        public static PostLinkResponse GetUserPostLinks(this XiaoheiheClient xhh)
        {
            return xhh.GetUserPostLinks(xhh.HeyboxID);
        }


        /// <summary>
        /// ��ȡ�û������б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static PostLinkResponse GetUserPostLinks(this XiaoheiheClient xhh, uint userID)
        {
            return xhh.GetUserPostLinks(userID, 0);
        }

        /// <summary>
        /// ��ȡ�û������б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static PostLinkResponse GetUserPostLinks(this XiaoheiheClient xhh, uint userID, uint offset)
        {
            string subPath = "/bbs/app/profile/user/link/list";

            Dictionary<string, string> extendParams = new(3)
            {
                { "userid", userID.ToString() },
                { "offset", offset.ToString() },
                { "limit", "30" },
            };

            PostLinkResponse response = xhh.BasicRequest<PostLinkResponse>(HttpMethod.Get, subPath, extendParams);

            return response;
        }


    }
}
