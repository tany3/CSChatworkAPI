# テストの実行方法
- TestData.template.json をコピーして TestData.json を作る
- TestData.json に API token など自身の環境設定を行う
- テストをビルドし実行する

# 注意
- "CSChatworkAPI.Test.E2E" で始まる Room をテスト実行前に削除する
- リクエストを超過(TooManyRequestsException)するとゴミが残る場合がある
  - 自動化は注意
- マイチャットに1つファイルを添付しておくこと
- マイチャットのタスクが増えていくので注意
  - API が無いので追加したタスクを tear down できない...