module AIMLbot
open System
open System.Drawing
open System.Windows.Forms
open AIMLbot

let myBot = new Bot()
myBot.loadSettings()
let myUser = new AIMLbot.User("User", myBot)
myBot.loadAIMLFromFiles()

let askBot str =
    let r = new Request(str, myUser, myBot)
    let res = myBot.Chat(r)
    res.Output.ToString()

let enterMessage (tbInput: #TextBox) (tbLog: #TextBox) (e: KeyEventArgs) =
    if (e.KeyCode = Keys.Enter)
    then tbLog.AppendText("You: " + tbInput.Text+"\n")
         tbLog.AppendText("Eva: " + (askBot tbInput.Text)+"\n")
         tbInput.Clear()

let chatWithBot() =

    let tbInput = new TextBox()
    tbInput.Dock <- DockStyle.Bottom
    

    let tbLog = new TextBox(Top = 0, Left = 0, Height = 450, Width = 585)
    tbLog.Dock <- DockStyle.Fill
    tbLog.Multiline <- true
    tbLog.WordWrap <- true
    tbLog.ReadOnly <- true

    let form = new Form(Text="Eva Bot", Visible=true)

    let lbHowSendMessage = new Label (Text = "Press Enter to send message")
    lbHowSendMessage.Dock <- DockStyle.Bottom

    let lbHowExit = new Label (Text = "Press ESC to Exit")
    lbHowExit.Dock <- DockStyle.Bottom

    form.Controls.AddRange[|tbLog; tbInput; lbHowSendMessage; lbHowExit |]

    tbInput.KeyDown.Add(enterMessage tbInput tbLog)

    let gotfocus = tbInput.Focus()

    tbInput.KeyDown.Add(fun e -> if e.KeyCode = Keys.Escape then form.Close())
    tbLog.KeyDown.Add(fun e -> if e.KeyCode = Keys.Escape then form.Close())
    form


let form = chatWithBot()


Application.Run(form)