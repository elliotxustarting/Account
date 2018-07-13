﻿using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ESP.Core.Account.Web.Models
{
    public class RestApiResult
    {
        /// <summary>
        /// 返回代码
        /// </summary>
        [JsonProperty("code")]
        [DataMember(Name = "code")]
        public int Code { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        [JsonProperty("message")]
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// 错误信息详情的StackTrace
        /// </summary>
        [JsonProperty("error")]
        [DataMember(Name = "error")]
        public string Error { get; set; }

        /// <summary>
        /// 数据 
        /// </summary>
        [JsonProperty("data")]
        [DataMember(Name = "data")]
        public object Data { get; set; }
    }
}
