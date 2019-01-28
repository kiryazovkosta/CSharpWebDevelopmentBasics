// 	<copyright file=IHttpSession.cs company="Business Management Systems Ltd.">
//		Copyright (c) 2019 All Rights Reserved
// 	</copyright>
// 	<author>Kosta.Kiryazov</author>
// 	<date>1/23/2019 1:14:55 PM</date>
// 	<summary>Definition of a IHttpSession interface</summary>
namespace SIS.HTTP.Sessions.Contracts
{
    using System;

    public interface IHttpSession
    {
        string Id { get; }
        object GetParameter(string key);
        bool ContainsParameter(string name);
        void AddParameter(string name, object parameter);
        void ClearParameters();
    }
}
