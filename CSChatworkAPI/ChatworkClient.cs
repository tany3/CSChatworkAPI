/* See the file "LICENSE" for the full license governing this code. */
using System;
using System.Collections.Generic;
using CSChatworkAPI.Communicators;
using CSChatworkAPI.Models;

namespace CSChatworkAPI
{
    /// <summary>
    /// Chatwork Client
    /// </summary>
    public class ChatworkClient : AbstractCommunicator
    {
        public ChatworkClient(string apiToken) : base(apiToken)
        {}

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
        public Room AddRoom(Room room)
        {
            throw new NotImplementedException();
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
        public Room UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// グループチャットを退席する
        /// </summary>
        public void LeaveRoom(int roomId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// グループチャットを削除する
        /// </summary>
        public void DeleteRoom(int roomId)
        {
            throw new NotImplementedException();
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
        public MemberRoles UpdateRoomMembers(MemberRoles roles)
        {
            throw new NotImplementedException();
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
            return PostT<ResponseMessage>(resource, messageBody);
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
        /// <returns>チャットのタスク一覧</returns>
        public IEnumerable<Task> GetTasks(int roomId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// チャットに新しいタスクを追加
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="task">新しいタスク</param>
        /// <returns>新しいタスクId</returns>
        public ResponseMessage AddTask(int roomId, Task task)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// タスク情報を取得
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="taskId">タスクId</param>
        /// <returns>タスク情報</returns>
        public Task GetTask(int roomId, int taskId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// チャットのファイル一覧を取得 (※100件まで取得可能。今後、より多くのデータを取得する為のページネーションの仕組みを提供予定)
        /// </summary>
        /// <param name="roomId">ルームId</param>
        /// <param name="accountId">アップロードしたユーザーのアカウントID</param>
        /// <returns>ファイル情報一覧</returns>
        public IEnumerable<File> GetFiles(int roomId, int accountId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
