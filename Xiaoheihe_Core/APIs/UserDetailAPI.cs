using Xiaoheihe_Core.Data;

namespace Xiaoheihe_Core.APIs
{
    public static class UserDetailAPI
    {
        /// <summary>
        /// ��ȡ�Լ��Ĺ�ע�����б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <returns></returns>
        public static async Task<FollowListResponse> GetFollowingList(this XiaoheiheClient xhh)
        {
            return await xhh.GetFollowingList(xhh.HeyboxID, 0).ConfigureAwait(false);
        }

        /// <summary>
        /// ��ȡ��ע�����б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static async Task<FollowListResponse> GetFollowingList(this XiaoheiheClient xhh, uint userID)
        {
            return await xhh.GetFollowingList(userID, 0).ConfigureAwait(false);
        }

        /// <summary>
        /// ��ȡ��ע�����б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static async Task<FollowListResponse> GetFollowingList(this XiaoheiheClient xhh, uint userID, uint offset)
        {
            string subPath = "/bbs/app/profile/following/list";

            Dictionary<string, string> extraParams = new(3)
            {
                { "userid", userID.ToString() },
                { "offset", offset.ToString() },
                { "limit", "30" },
            };

            FollowListResponse response = await xhh.BasicRequestAsync<FollowListResponse>(HttpMethod.Get, subPath, extraParams).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// ��ȡ�Լ��ķ�˿�б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <returns></returns>
        public static async Task<FollowListResponse> GetFollowerList(this XiaoheiheClient xhh)
        {
            return await xhh.GetFollowerList(xhh.HeyboxID, 0).ConfigureAwait(false);
        }

        /// <summary>
        /// ��ȡ��˿�б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static async Task<FollowListResponse> GetFollowerList(this XiaoheiheClient xhh, uint userID)
        {
            return await xhh.GetFollowerList(userID, 0).ConfigureAwait(false);
        }

        /// <summary>
        /// ��ȡ��˿�б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static async Task<FollowListResponse> GetFollowerList(this XiaoheiheClient xhh, uint userID, uint offset)
        {
            string subPath = "/bbs/app/profile/follower/list";

            Dictionary<string, string> extraParams = new(3)
            {
                { "userid", userID.ToString() },
                { "offset", offset.ToString() },
                { "limit", "30" },
            };

            FollowListResponse response = await xhh.BasicRequestAsync<FollowListResponse>(HttpMethod.Get, subPath, extraParams).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// ��ע����ȡ���û�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="isFollow"></param>
        /// <returns></returns>
        private static async Task<BasicResponse> FollowAction(this XiaoheiheClient xhh, uint userID, bool isFollow)
        {
            string subPath = isFollow ? "/bbs/app/profile/follow/user" : "/bbs/app/profile/follow/user/cancel";

            Dictionary<string, string> formData = new(1)
            {
                { "following_id", userID.ToString() },
            };

            FormUrlEncodedContent content = new(formData);

            FollowListResponse response = await xhh.BasicRequestAsync<FollowListResponse>(HttpMethod.Post, subPath, content).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// ��ע�û�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static async Task<BasicResponse> FollowUser(this XiaoheiheClient xhh, uint userID)
        {
            return await xhh.FollowAction(userID, true).ConfigureAwait(false);
        }

        /// <summary>
        /// ȡ���û�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static async Task<BasicResponse> UnfollowUser(this XiaoheiheClient xhh, uint userID)
        {
            return await xhh.FollowAction(userID, false).ConfigureAwait(false);
        }

        /// <summary>
        /// ��ȡ�û���̬
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static async Task<UserEventsResponse> GetUserEvents(this XiaoheiheClient xhh, uint userID)
        {
            return await xhh.GetUserEvents(userID, 0).ConfigureAwait(false);
        }

        /// <summary>
        /// ��ȡ�û���̬
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static async Task<UserEventsResponse> GetUserEvents(this XiaoheiheClient xhh, uint userID, uint offset)
        {
            string subPath = "/bbs/app/profile/events";

            Dictionary<string, string> extraParams = new(3)
            {
                { "userid", userID.ToString() },
                { "offset", offset.ToString() },
                { "limit", "30" },
            };

            UserEventsResponse response = await xhh.BasicRequestAsync<UserEventsResponse>(HttpMethod.Get, subPath, extraParams).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// ��ȡ�Լ��ķ����б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <returns></returns>
        public static async Task<UserPostLinkResponse> GetUserPostLinks(this XiaoheiheClient xhh, bool onlyArticle)
        {
            return await xhh.GetUserPostLinks(xhh.HeyboxID, onlyArticle).ConfigureAwait(false);
        }


        /// <summary>
        /// ��ȡ�û������б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static async Task<UserPostLinkResponse> GetUserPostLinks(this XiaoheiheClient xhh, uint userID, bool onlyArticle)
        {
            return await xhh.GetUserPostLinks(userID, 0, onlyArticle).ConfigureAwait(false);
        }


        /// <summary>
        /// ��ȡ�û������б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="offset"></param>
        /// <param name="onlyArticle">����ʾ����</param>
        /// <returns></returns>
        public static async Task<UserPostLinkResponse> GetUserPostLinks(this XiaoheiheClient xhh, uint userID, uint offset, bool onlyArticle)
        {
            string subPath = "/bbs/app/profile/user/link/list";

            Dictionary<string, string> extraParams = new(4)
            {
                { "userid", userID.ToString() },
                { "offset", offset.ToString() },
                { "limit", "30" },
            };

            if (onlyArticle)
            {
                extraParams.Add("list_type", "article");
            }

            UserPostLinkResponse response = await xhh.BasicRequestAsync<UserPostLinkResponse>(HttpMethod.Get, subPath, extraParams).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// ��ȡ�Լ��������б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="onlyCy"></param>
        /// <returns></returns>
        public static async Task<UserCommentListResponse> GetUserComments(this XiaoheiheClient xhh, bool onlyCy)
        {
            return await xhh.GetUserComments(xhh.HeyboxID, onlyCy, 0).ConfigureAwait(false);
        }

        /// <summary>
        /// ��ȡ�û������б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="onlyCy"></param>
        /// <returns></returns>
        public static async Task<UserCommentListResponse> GetUserComments(this XiaoheiheClient xhh, uint userID, bool onlyCy)
        {
            return await xhh.GetUserComments(userID, onlyCy, 0).ConfigureAwait(false);
        }

        /// <summary>
        /// ��ȡ�û������б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="onlyCy">�Ƿ����</param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static async Task<UserCommentListResponse> GetUserComments(this XiaoheiheClient xhh, uint userID, bool onlyCy, uint offset)
        {
            string subPath = "/bbs/app/profile/bbs/comment/list";

            Dictionary<string, string> extraParams = new(4)
            {
                { "userid", userID.ToString() },
                { "offset", offset.ToString() },
                { "limit", "30" },
                { "only_cy", onlyCy ? "1" : "0" },
            };

            UserCommentListResponse response = await xhh.BasicRequestAsync<UserCommentListResponse>(HttpMethod.Get, subPath, extraParams).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// ��ȡ�Լ���Steam�����б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <returns></returns>
        public static async Task<FriendListResponse> GetSteamFriendList(this XiaoheiheClient xhh)
        {
            return await xhh.GetSteamFriendList(xhh.HeyboxID).ConfigureAwait(false);
        }

        /// <summary>
        /// ��ȡSteam�����б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static async Task<FriendListResponse> GetSteamFriendList(this XiaoheiheClient xhh, uint userID)
        {
            return await xhh.GetSteamFriendList(userID, 0);
        }

        /// <summary>
        /// ��ȡSteam�����б�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="userID"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static async Task<FriendListResponse> GetSteamFriendList(this XiaoheiheClient xhh, uint userID, uint offset)
        {
            string subPath = "/account/friend_list_v2/";

            Dictionary<string, string> extraParams = new(5)
            {
                { "key", "online" },
                { "userid", userID.ToString() },
                { "offset", offset.ToString() },
                { "limit", "30" },
                { "type_filter", "following" },
            };

            FriendListResponse response = await xhh.BasicRequestAsync<FriendListResponse>(HttpMethod.Get, subPath, extraParams).ConfigureAwait(false);

            return response;
        }
    }
}
