/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSChatworkAPI.Communicators;
using CSChatworkAPI.Extensions;
using CSChatworkAPI.Models;
using RestSharp;

namespace CSChatworkAPI
{
    /// <summary>
    /// Chatwork Client
    /// </summary>
    public class ChatworkClient : AbstractCommunicator
    {
        public ChatworkClient(string apiToken) : base(apiToken)
        {}

#region endpoint /me
        /// <summary>
        /// 自分自身の情報を取得
        /// </summary>
        /// <returns>自分自身の情報</returns>
        public Me GetMe()
        {
            const string resource = @"me";
            return GetT<Me>(resource); 
        }
#endregion endpoint /me



#region endpoint /my
        /// <summary>
        /// 自分の未読数、未読To数、未完了タスク数を返す
        /// </summary>
        /// <returns>自分の状態</returns>
        public MyStatus GetStatus()
        {
            const string resource = @"my/status";
            return GetT<MyStatus>(resource); 
        }

        /// <summary>
        /// 自分のタスク一覧を取得する。(※100件まで取得可能。今後、より多くのデータを取得する為のページネーションの仕組みを提供予定)
        /// </summary>
        /// <param name="assigned_by_account_id">タスクの依頼者のアカウントID</param>
        /// <param name="statuses">タスクのステータス</param>
        /// <returns>自分のタスク一覧</returns>
        public IEnumerable<MyTask> GetTasks(int assigned_by_account_id, IEnumerable<string> statuses)
        {
            const string resource = @"my/status";
            
            var parameters = new Dictionary<string, object>
            {
                {"assigned_by_account_id", assigned_by_account_id},
            };
            foreach (var status in statuses)
            {
                parameters.Add(@"status", status);
            }

            return GetT<IEnumerable<MyTask>>(resource); 
        }
#endregion endpoint /my



#region endpoint /contacts
        /// <summary>
        /// 自分のコンタクト一覧を取得
        /// </summary>
        /// <returns>自分のコンタクト一覧</returns>
        public IEnumerable<Contact> GetContacts()
        {
            const string resource = @"contacts";
            return GetT<IEnumerable<Contact>>(resource); 
        }
#endregion endpoint /contacts



#region endpoint /rooms
        /// <summary>
        /// 自分のチャット一覧の取得
        /// </summary>
        public IEnumerable<Room> GetRooms()
        {
            const string resource = @"rooms";
            return GetT<IEnumerable<Room>>(resource);
        }

        /// <summary>
        /// グループチャットを新規作成
        /// </summary>
        public Room AddRoom(string description, string icon_preset,
            IEnumerable<int> members_admin_ids, IEnumerable<int> members_member_ids, IEnumerable<int> members_readonly_ids,
            string name)
        {
            const string resource = @"rooms";

            var parameters = new Dictionary<string, object>
            {
                {"description", description},
                {"icon_preset", icon_preset},
                {"members_admin_ids", string.Join(",", members_admin_ids)},
                {"members_member_ids", members_member_ids != null ? string.Join(",", members_member_ids) : ""},
                {"members_readonly_ids", members_readonly_ids != null ? string.Join(",", members_readonly_ids) : ""},
                {"name", name},
            };

            return PostT<Room>(resource, parameters);
        }

        /// <summary>
        /// チャットの名前、アイコン、種類(my/direct/group)を取得
        /// </summary>
        public Room GetRoom(int roomId)
        {
            var resource = string.Format("rooms/{0}", roomId);
            return GetT<Room>(resource);
        }

        /// <summary>
        /// チャットの名前、アイコンをアップデート
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="description">グループチャットの概要説明テキスト</param>
        /// <param name="icon_preset">グループチャットのアイコン種類</param>
        /// <param name="name">グループチャットのチャット名</param>
        /// <returns>ルームId</returns>
        public ResponseMessage UpdateRoom(int roomId, string description, string icon_preset, string name)
        {
            var resource = string.Format("rooms/{0}", roomId);

            var parameters = new Dictionary<string, object>
            {
                {"description", description},
                {"icon_preset", icon_preset},
                {"name", name},
            };

            return SendT<ResponseMessage>(resource, parameters, Method.PUT);
        }

        /// <summary>
        /// グループチャットを退席する
        /// </summary>
        /// <param name="roomId">ルームId</param>
        public void LeaveRoom(int roomId)
        {
            var resource = string.Format("rooms/{0}", roomId);
            
            var parameters = new Dictionary<string, object>
            {
                {"action_type", "leave"},
            };

            var resp = SendT<ResponseMessage>(resource, parameters, Method.DELETE);
            Debug.WriteLine(resp);
        }

        /// <summary>
        /// グループチャットを削除する
        /// </summary>
        public void DeleteRoom(int roomId)
        {
            var resource = string.Format("rooms/{0}", roomId);

            var parameters = new Dictionary<string, object>
            {
                {"action_type", "delete"},
            };

            var resp = SendT<ResponseMessage>(resource, parameters, Method.DELETE);
            Debug.WriteLine(resp);
        }

        /// <summary>
        /// チャットのメンバー一覧を取得
        /// </summary>
        public IEnumerable<Member> GetRoomMembers(int roomId)
        {
            var resource = string.Format("rooms/{0}/members", roomId);
            return GetT<IEnumerable<Member>>(resource);
        }

        /// <summary>
        /// チャットのメンバーを一括変更
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="members_admin_ids">作成したチャットに参加メンバーのうち、管理者権限にしたいユーザーのアカウントIDの配列。最低1人は指定する必要がある。</param>
        /// <param name="members_member_ids">作成したチャットに参加メンバーのうち、メンバー権限にしたいユーザーのアカウントIDの配列。</param>
        /// <param name="members_readonly_ids">作成したチャットに参加メンバーのうち、閲覧のみ権限にしたいユーザーのアカウントIDの配列。</param>
        /// <returns>一括変更結果</returns>
        public MemberRoles UpdateRoomMembers(int roomId,
            IEnumerable<int> members_admin_ids, IEnumerable<int> members_member_ids, IEnumerable<int> members_readonly_ids)
        {
            var resource = string.Format("rooms/{0}/members", roomId);

            var parameters = new Dictionary<string, object>
            {
                {"members_admin_ids", string.Join(",", members_admin_ids)},
                {"members_member_ids", string.Join(",", members_member_ids)},
                {"members_readonly_ids", string.Join(",", members_readonly_ids)},
            };

            return PostT<MemberRoles>(resource, parameters);
        }

        /// <summary>
        /// チャットのメッセージ一覧を取得。パラメータ未指定だと前回取得分からの差分のみを返します。(最大100件まで取得)
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="force">
        /// <para>未取得にかかわらず最新の100件を取得するか</para>
        /// <para>1を指定すると未取得にかかわらず最新の100件を取得します（デフォルトは0）</para>
        /// </param>
        /// <returns>チャットのメッセージ一覧</returns>
        public IEnumerable<Message> GetMessages(int roomId, bool force = false)
        {
            var resource = string.Format("rooms/{0}/messages?force={1}", roomId, force ? 1 : 0);
            return GetT<IEnumerable<Message>>(resource);
        }

        /// <summary>
        /// チャットに新しいメッセージを追加
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="messageBody">新しいメッセージ</param>
        /// <returns>新しいメッセージId</returns>
        public ResponseMessage SendMessage(int roomId, string messageBody)
        {
            var resource = string.Format("rooms/{0}/messages", roomId);

            var parameters = new Dictionary<string, object>
            {
                {"body", messageBody},
            };

            return PostT<ResponseMessage>(resource, parameters);
        }

        /// <summary>
        /// メッセージ情報を取得
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="messageId">メッセージId</param>
        /// <returns>メッセージ</returns>
        public Message GetMessage(int roomId, int messageId)
        {
            var resource = string.Format("rooms/{0}/messages/{1}", roomId, messageId);
            return GetT<Message>(resource);
        }

        /// <summary>
        /// チャットのタスク一覧を取得 (※100件まで取得可能。今後、より多くのデータを取得する為のページネーションの仕組みを提供予定)
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="account_id">タスクの担当者のアカウントID</param>
        /// <param name="assigned_by_account_id">タスクの依頼者のアカウントID</param>
        /// <param name="status">
        /// <para>タスクのステータス</para>
        /// <para>正しい値の一覧：open, done</para>
        /// </param>
        /// <returns></returns>
        public IEnumerable<Task> GetTasks(int roomId, int account_id, int assigned_by_account_id, int status)
        {
            var resource = string.Format("rooms/{0}/tasks", roomId);

            var parameters = new Dictionary<string, object>
            {
                {"account_id", account_id},
                {"assigned_by_account_id", assigned_by_account_id},
                {"status", status},
            };

            return GetT<IEnumerable<Task>>(resource, parameters);
        }

        /// <summary>
        /// チャットに新しいタスクを追加
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="body">タスクの内容</param>
        /// <param name="limit">タスクの期限</param>
        /// <param name="to_ids">
        /// <para>担当者のアカウントID</para>
        /// <para>担当者のアカウントIDをカンマ区切りで</para>
        /// <para>※リストはカンマ区切りで複数の値を指定してください</para>
        /// </param>
        /// <returns>新しいタスクId</returns>
        public ResponseTaskIds AddTask(int roomId, string body, DateTime? limit, IEnumerable<int> to_ids)
        {
            var resource = string.Format("rooms/{0}/tasks", roomId);

            var parameters = new Dictionary<string, object>
            {
                {"body", body},
                {"to_ids", string.Join(",", to_ids)},
            };
            if (limit.HasValue)
            {
                parameters.Add("limit", limit.Value.ToUnixTime());
            }

            return SendT<ResponseTaskIds>(resource, parameters, Method.POST);
        }

        /// <summary>
        /// タスク情報を取得
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="taskId">タスクId</param>
        /// <returns>タスク情報</returns>
        public Task GetTask(int roomId, int taskId)
        {
            var resource = string.Format("rooms/{0}/tasks/{1}", roomId, taskId);
            return GetT<Task>(resource);
        }

        /// <summary>
        /// チャットのファイル一覧を取得 (※100件まで取得可能。今後、より多くのデータを取得する為のページネーションの仕組みを提供予定)
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="account_id">アップロードしたユーザーのアカウントID</param>
        /// <returns>ファイル情報一覧</returns>
        public IEnumerable<File> GetFiles(int roomId, int account_id)
        {
            var resource = string.Format("rooms/{0}/files", roomId);

            var parameters = new Dictionary<string, object>
            {
                {"account_id", account_id},
            };

            return GetT<IEnumerable<File>>(resource, parameters);
        }

        /// <summary>
        /// ファイル情報を取得
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="fileId">ファイルId</param>
        /// <param name="createDownloadUrl">
        /// <para>ダウンロードする為のURLを生成するか</para>
        /// <para>30秒間だけダウンロード可能なURLを生成します</para>
        /// </param>
        /// <returns>ファイル情報</returns>
        public File GetFile(int roomId, int fileId, bool createDownloadUrl)
        {
            var resource = string.Format("rooms/{0}/files/{1}", roomId, fileId);

            var parameters = new Dictionary<string, object>
            {
                {"createDownloadUrl", createDownloadUrl},
            };

            return GetT<File>(resource, parameters);
        }
#endregion endpoint /rooms
    }
}
