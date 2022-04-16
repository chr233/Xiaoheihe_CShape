﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Xiaoheihe_Core.Data;

namespace Xiaoheihe_Core.APIs
{
    public static class TaskAPI
    {
        /// <summary>
        /// 获取签到日历
        /// </summary>
        /// <param name="xhh"></param>
        /// <returns></returns>
        public static TaskSignListResponse GetTaskSignList(this XiaoheiheClient xhh)
        {
            string subPath = "/task/sign_list/";

            TaskSignListResponse response = xhh.BasicRequest<TaskSignListResponse>
                (HttpMethod.Get, subPath, null, null);

            return response;
        }

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="xhh"></param>
        /// <returns></returns>
        public static TaskListResponse GetTaskList(this XiaoheiheClient xhh)
        {
            string subPath = "/task/list/";

            TaskListResponse response = xhh.BasicRequest<TaskListResponse>
                (HttpMethod.Get, subPath, null, null);

            return response;
        }

        /// <summary>
        /// 每日签到
        /// </summary>
        /// <param name="xhh"></param>
        /// <returns></returns>
        public static TaskSignResponse TaskSign(this XiaoheiheClient xhh)
        {
            string subPath = "/task/sign/";

            TaskSignResponse response = xhh.BasicRequest<TaskSignResponse>
                (HttpMethod.Get, subPath, null, null);

            return response;
        }
    }
}