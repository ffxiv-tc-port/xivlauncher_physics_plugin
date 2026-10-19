# High FPS Physics Fix

[ItsLunaYup/xivlauncher_physics_plugin](https://github.com/ItsLunaYup/xivlauncher_physics_plugin) 的台服移植版。
把布料、頭髮等物理效果的更新頻率限制在設定的「物理效果 FPS」（預設 60），緩解高 FPS 下物理效果異常的問題。

## 使用

- `/physics`：開關設定視窗（可調整「物理效果 FPS」）
- `/physics on` 啟用物理效果修正
- `/physics off` 停用物理效果修正
- `/physics t` 切換開關

為避免造成問題（或版本更新後行為改變），插件啟動時預設為**停用**，可在設定視窗開啟「啟動時啟用」。
過場動畫中可能出現短暫的顯示異常，若遇到問題請停用本插件。

## 台服版的修改

只做台服相容性修正（Dalamud 版本、繁中翻譯），功能與上游相同。

## 安裝

在 Dalamud 設定的「自訂插件庫」加入
`https://raw.githubusercontent.com/ffxiv-tc-port/DalamudPluginsTC/main/repo.json` 並啟用，
再從插件列表安裝。

原作者：[ItsLunaYup](https://github.com/ItsLunaYup)
