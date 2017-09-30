/* See the file "LICENSE" for the full license governing this code. */

using System;
using System.Collections.Generic;
using System.Linq;
using CSChatworkAPI.Communicators;
using CSChatworkAPI.Extensions;
using CSChatworkAPI.Models;
using RestSharp;

namespace CSChatworkAPI
{
    /// <summary>
    /// Chatwork Client
    /// </summary>
    public class ChatworkClient
    {
        private readonly ApiCommunicator _api;

        /// <summary>
        /// ChatworkClient
        /// </summary>
        /// <param name="apiToken"></param>
        public ChatworkClient(string apiToken)
        {
            if (string.IsNullOrEmpty(apiToken)) throw new ArgumentException($"{nameof(apiToken)} must not be NullOrEmpty.");

            _api = new ApiCommunicator(apiToken);
        }

#region endpoint /me
        /// <summary>
        /// 自分自身の情報を取得
        /// </summary>
        /// <returns>自分自身の情報</returns>
        public Me GetMe()
        {
            const string resource = @"me";
            return _api.Get<Me>(resource); 
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
            return _api.Get<MyStatus>(resource); 
        }

        /// <summary>
        /// 自分のタスク一覧を取得する。(※100件まで取得可能。今後、より多くのデータを取得する為のページネーションの仕組みを提供予定)
        /// </summary>
        /// <param name="assigned_by_account_id">タスクの依頼者のアカウントID</param>
        /// <param name="statuses">タスクのステータス</param>
        /// <returns>自分のタスク一覧</returns>
        public IEnumerable<MyTask> GetTasks(string assigned_by_account_id, IEnumerable<string> statuses)
        {
            if (statuses == null)
            {
                throw new ArgumentNullException("statuses");
            }
            if (!statuses.Any())
            {
                throw new InvalidOperationException("statuses is empty(add open/close).");
            }

            const string resource = @"my/tasks";
            
            var parameters = new Dictionary<string, object>
            {
                {"assigned_by_account_id", assigned_by_account_id},
                {@"status", string.Join(",", statuses)},
            };

            return _api.Get<IEnumerable<MyTask>>(resource); 
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
            return _api.Get<IEnumerable<Contact>>(resource); 
        }
#endregion endpoint /contacts



#region endpoint /rooms
        /// <summary>
        /// 自分のチャット一覧の取得
        /// </summary>
        public IEnumerable<Room> GetRooms()
        {
            const string resource = @"rooms";
            return _api.Get<IEnumerable<Room>>(resource);
        }

        /// <summary>
        /// グループチャットを新規作成
        /// </summary>
        public Room AddRoom(string description, string iconPreset,
            IEnumerable<string> membersAdminIds, IEnumerable<string> membersMemberIds, IEnumerable<string> membersReadonlyIds,
            string name)
        {
            const string resource = @"rooms";

            var parameters = new Dictionary<string, object>
            {
                {"description", description},
                {"icon_preset", iconPreset},
                {"members_admin_ids", string.Join(",", membersAdminIds)},
                {"members_member_ids", membersMemberIds != null ? string.Join(",", membersMemberIds) : ""},
                {"members_readonly_ids", membersReadonlyIds != null ? string.Join(",", membersReadonlyIds) : ""},
                {"name", name},
            };

            return _api.Post<Room>(resource, parameters);
        }

        /// <summary>
        /// チャットの名前、アイコン、種類(my/direct/group)を取得
        /// </summary>
        public Room GetRoom(string roomId)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}";
            return _api.Get<Room>(resource);
        }

        /// <summary>
        /// チャットの名前、アイコンをアップデート
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="description">グループチャットの概要説明テキスト</param>
        /// <param name="iconPreset">グループチャットのアイコン種類</param>
        /// <param name="name">グループチャットのチャット名</param>
        /// <returns>ルームId</returns>
        public ResponseRoomId UpdateRoom(string roomId, string description, string iconPreset, string name)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}";

            var parameters = new Dictionary<string, object>
            {
                {"description", description},
                {"icon_preset", iconPreset},
                {"name", name},
            };

            return _api.Send<ResponseRoomId>(resource, parameters, Method.PUT);
        }

        /// <summary>
        /// グループチャットを退席する
        /// </summary>
        /// <param name="roomId">ルームId</param>
        public void LeaveRoom(string roomId)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}";
            
            var parameters = new Dictionary<string, object>
            {
                {"action_type", "leave"},
            };

            _api.Send<object>(resource, parameters, Method.DELETE);
        }

        /// <summary>
        /// グループチャットを削除する
        /// </summary>
        public void DeleteRoom(string roomId)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}";

            var parameters = new Dictionary<string, object>
            {
                {"action_type", "delete"},
            };

            _api.Send<object>(resource, parameters, Method.DELETE);
        }

        /// <summary>
        /// チャットのメンバー一覧を取得
        /// </summary>
        public IEnumerable<Member> GetRoomMembers(string roomId)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}/members";
            return _api.Get<IEnumerable<Member>>(resource);
        }

        /// <summary>
        /// チャットのメンバーを一括変更
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="membersAdminIds">作成したチャットに参加メンバーのうち、管理者権限にしたいユーザーのアカウントIDの配列。最低1人は指定する必要がある。</param>
        /// <param name="membersMemberIds">作成したチャットに参加メンバーのうち、メンバー権限にしたいユーザーのアカウントIDの配列。</param>
        /// <param name="membersReadonlyIds">作成したチャットに参加メンバーのうち、閲覧のみ権限にしたいユーザーのアカウントIDの配列。</param>
        /// <returns>一括変更結果</returns>
        public MemberRoles UpdateRoomMembers(string roomId,
            IEnumerable<string> membersAdminIds, IEnumerable<string> membersMemberIds, IEnumerable<string> membersReadonlyIds)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}/members";

            var parameters = new Dictionary<string, object>
            {
                {"members_admin_ids", string.Join(",", membersAdminIds)},
                {"members_member_ids", string.Join(",", membersMemberIds)},
                {"members_readonly_ids", string.Join(",", membersReadonlyIds)},
            };

            return _api.Send<MemberRoles>(resource, parameters, Method.PUT);
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
        public IEnumerable<Message> GetMessages(string roomId, bool force = false)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}/messages?force={(force ? 1 : 0)}";
            return _api.Get<IEnumerable<Message>>(resource);
        }

        /// <summary>
        /// チャットに新しいメッセージを追加
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="messageBody">新しいメッセージ</param>
        /// <returns>新しいメッセージId</returns>
        public ResponseMessage SendMessage(string roomId, string messageBody)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}/messages";

            var parameters = new Dictionary<string, object>
            {
                {"body", messageBody},
            };

            return _api.Post<ResponseMessage>(resource, parameters);
        }

        /// <summary>
        /// メッセージ情報を取得
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="messageId">メッセージId</param>
        /// <returns>メッセージ</returns>
        public Message GetMessage(string roomId, string messageId)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");
            if (string.IsNullOrEmpty(messageId)) throw new ArgumentException($"{nameof(messageId)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}/messages/{messageId}";
            return _api.Get<Message>(resource);
        }

        /// <summary>
        /// チャットのタスク一覧を取得 (※100件まで取得可能。今後、より多くのデータを取得する為のページネーションの仕組みを提供予定)
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="accountId">タスクの担当者のアカウントID</param>
        /// <param name="assignedByAccountId">タスクの依頼者のアカウントID</param>
        /// <param name="status">
        /// <para>タスクのステータス</para>
        /// <para>正しい値の一覧：open, done</para>
        /// </param>
        /// <returns></returns>
        public IEnumerable<Task> GetTasks(string roomId, string accountId, string assignedByAccountId, string status)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");
            if (string.IsNullOrEmpty(status)) throw new ArgumentException($"{nameof(status)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}/tasks";

            var parameters = new Dictionary<string, object>
            {
                {"account_id", accountId},
                {"assigned_by_account_id", assignedByAccountId},
                {"status", status}
            };

            return _api.Get<IEnumerable<Task>>(resource, parameters);
        }

        /// <summary>
        /// チャットに新しいタスクを追加
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="body">タスクの内容</param>
        /// <param name="limit">タスクの期限</param>
        /// <param name="toIds">
        /// <para>担当者のアカウントID</para>
        /// <para>担当者のアカウントIDをカンマ区切りで</para>
        /// <para>※リストはカンマ区切りで複数の値を指定してください</para>
        /// </param>
        /// <returns>新しいタスクId</returns>
        public ResponseTaskIds AddTask(string roomId, string body, DateTime? limit, IEnumerable<string> toIds)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}/tasks";

            var parameters = new Dictionary<string, object>
            {
                {"body", body},
                {"to_ids", string.Join(",", toIds)},
            };
            if (limit.HasValue)
            {
                parameters.Add("limit", limit.Value.ToUnixTime());
            }

            return _api.Send<ResponseTaskIds>(resource, parameters, Method.POST);
        }

        /// <summary>
        /// タスク情報を取得
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="taskId">タスクId</param>
        /// <returns>タスク情報</returns>
        public Task GetTask(string roomId, string taskId)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException($"{nameof(taskId)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}/tasks/{taskId}";
            return _api.Get<Task>(resource);
        }

        /// <summary>
        /// チャットのファイル一覧を取得 (※100件まで取得可能。今後、より多くのデータを取得する為のページネーションの仕組みを提供予定)
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="accountId">アップロードしたユーザーのアカウントID</param>
        /// <returns>ファイル情報一覧</returns>
        public IEnumerable<File> GetFiles(string roomId, string accountId)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");
            if (string.IsNullOrEmpty(accountId)) throw new ArgumentException($"{nameof(accountId)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}/files";

            var parameters = new Dictionary<string, object>
            {
                {"account_id", accountId},
            };

            return _api.Get<IEnumerable<File>>(resource, parameters);
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
        public File GetFile(string roomId, string fileId, bool createDownloadUrl)
        {
            if (string.IsNullOrEmpty(roomId)) throw new ArgumentException($"{nameof(roomId)} must not be NullOrEmpty.");
            if (string.IsNullOrEmpty(fileId)) throw new ArgumentException($"{nameof(fileId)} must not be NullOrEmpty.");

            var resource = $"rooms/{roomId}/files/{fileId}";

            var parameters = new Dictionary<string, object>
            {
                {"createDownloadUrl", createDownloadUrl},
            };

            return _api.Get<File>(resource, parameters);
        }
#endregion endpoint /rooms
    }
}
