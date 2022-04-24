using Xiaoheihe_Core.Data;

namespace Xiaoheihe_Core.APIs
{
    public static class LikeAPI
    {
        /// <summary>
        /// ���޻���ȡ����������
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <param name="like"></param>
        /// <returns></returns>
        private static BasicResponse LikeNewsAction(this XiaoheiheClient xhh, uint linkID, AwardType like)
        {
            return xhh.LikeNewsAction(linkID, -1, like);
        }

        /// <summary>
        /// ���޻���ȡ����������
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <param name="index"></param>
        /// <param name="like"></param>
        /// <returns></returns>
        private static BasicResponse LikeNewsAction(this XiaoheiheClient xhh, uint linkID, int index, AwardType like)
        {
            string subPath = "/bbs/app/profile/award/link";

            string hSrc = Utils.Base64Encode($"news_feeds_-1__link_id__{linkID}");

            Dictionary<string, string> extendParams = new(2)
            {
                { "h_src", hSrc },
                { "index", index.ToString() },
            };

            Dictionary<string, string> formData = new(2)
            {
                { "link_id", linkID.ToString() },
                { "award_type", ((int)like).ToString() },
            };

            FormUrlEncodedContent content = new(formData);

            BasicResponse response = xhh.BasicRequest<BasicResponse>(HttpMethod.Post, subPath, extendParams, content);

            return response;
        }

        /// <summary>
        /// �������»������Ż�������
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <returns></returns>
        public static BasicResponse LikeNews(this XiaoheiheClient xhh, uint linkID)
        {
            return xhh.LikeNewsAction(linkID, AwardType.Like);
        }

        /// <summary>
        /// �������»������Ż�������
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static BasicResponse LikeNews(this XiaoheiheClient xhh, uint linkID, int index)
        {
            return xhh.LikeNewsAction(linkID, index, AwardType.Like);
        }

        /// <summary>
        /// ȡ���������»������Ż�������
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <returns></returns>
        public static BasicResponse DislikeNews(this XiaoheiheClient xhh, uint linkID)
        {
            return xhh.LikeNewsAction(linkID, AwardType.Cancel);
        }

        /// <summary>
        /// ȡ���������»������Ż�������
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static BasicResponse DislikeNews(this XiaoheiheClient xhh, uint linkID, int index)
        {
            return xhh.LikeNewsAction(linkID, index, AwardType.Cancel);
        }

        /// <summary>
        /// ���޵�Ȼ���ȡ����������
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <param name="commentID"></param>
        /// <param name="like"></param>
        /// <returns></returns>
        private static BasicResponse LikeCommentAction(this XiaoheiheClient xhh, uint linkID, uint commentID, SupportType like)
        {
            return xhh.LikeCommentAction(linkID, commentID, -1, like);
        }

        /// <summary>
        /// ���޵�Ȼ���ȡ����������
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <param name="index"></param>
        /// <param name="like"></param>
        /// <returns></returns>
        private static BasicResponse LikeCommentAction(this XiaoheiheClient xhh, uint linkID, uint commentID, int index, SupportType like)
        {
            string subPath = "/bbs/app/comment/support";

            string hSrc = Utils.Base64Encode($"bbs_app_feeds__link_id__{linkID}");

            Dictionary<string, string> extendParams = new(1)
            {
                { "index", index.ToString() },
            };

            Dictionary<string, string> formData = new(3)
            {
                { "h_src", hSrc },
                { "comment_id", commentID.ToString() },
                { "support_type", ((int)like).ToString() },
            };

            FormUrlEncodedContent content = new(formData);

            BasicResponse response = xhh.BasicRequest<BasicResponse>(HttpMethod.Post, subPath, extendParams, content);

            return response;
        }

        /// <summary>
        /// ���޻ظ�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <returns></returns>
        public static BasicResponse LikeComment(this XiaoheiheClient xhh, uint linkID, uint commentID)
        {
            return xhh.LikeCommentAction(linkID, commentID, SupportType.Like);
        }

        /// <summary>
        /// ���޻ظ�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static BasicResponse LikeComment(this XiaoheiheClient xhh, uint linkID, uint commentID, int index)
        {
            return xhh.LikeCommentAction(linkID, commentID, index, SupportType.Like);
        }

        /// <summary>
        /// ��Ȼظ�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <returns></returns>
        public static BasicResponse DislikeComment(this XiaoheiheClient xhh, uint linkID, uint commentID)
        {
            return xhh.LikeCommentAction(linkID, commentID, SupportType.Dislike);
        }

        /// <summary>
        /// ��Ȼظ�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static BasicResponse DislikeComment(this XiaoheiheClient xhh, uint linkID, uint commentID, int index)
        {
            return xhh.LikeCommentAction(linkID, commentID, index, SupportType.Dislike);
        }

        /// <summary>
        /// ȡ������/��Ȼظ�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <returns></returns>
        public static BasicResponse CanclelikeComment(this XiaoheiheClient xhh, uint linkID, uint commentID)
        {
            return xhh.LikeCommentAction(linkID, commentID, SupportType.Cancel);
        }

        /// <summary>
        /// ȡ������/��Ȼظ�
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static BasicResponse CanclelikeComment(this XiaoheiheClient xhh, uint linkID, uint commentID, int index)
        {
            return xhh.LikeCommentAction(linkID, commentID, index, SupportType.Cancel);
        }

        /// <summary>
        /// ���޻���ȡ��������Ϸ����
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <param name="like"></param>
        /// <returns></returns>
        private static BasicResponse LikeGameCommentAction(this XiaoheiheClient xhh, uint linkID, AwardType like)
        {
            string subPath = "/bbs/app/link/game/comment/up";

            string hSrc = Utils.Base64Encode($"follow__link_id__{linkID}");

            Dictionary<string, string> formData = new(3)
            {
                { "link_id", linkID.ToString() },
                { "support_type", ((int)like).ToString() },
                { "h_src", hSrc },
            };

            FormUrlEncodedContent content = new(formData);

            BasicResponse response = xhh.BasicRequest<BasicResponse>(HttpMethod.Post, subPath, content);

            return response;
        }

        /// <summary>
        /// ������Ϸ����
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <returns></returns>
        public static BasicResponse LikeGameComment(this XiaoheiheClient xhh, uint linkID)
        {
            return xhh.LikeGameCommentAction(linkID, AwardType.Like);
        }

        /// <summary>
        /// ȡ��������Ϸ����
        /// </summary>
        /// <param name="xhh"></param>
        /// <param name="linkID"></param>
        /// <returns></returns>
        public static BasicResponse DislikeGameComment(this XiaoheiheClient xhh, uint linkID)
        {
            return xhh.LikeGameCommentAction(linkID, AwardType.Cancel);
        }
    }
}
