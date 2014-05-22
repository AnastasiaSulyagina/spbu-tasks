 //Anastasia Sulyagina (c) 2014
// ChatWithBot

open System
open System.Windows.Forms
open AIMLbot

let myBot = new Bot()
myBot.loadSettings()
let myUser = new AIMLbot.User("senderUser", myBot);
myBot.loadAIMLFromFiles();

let chatForm = new Form(Text = "ChatWithBot 1.0", Height = 700, Width = 600, FormBorderStyle = FormBorderStyle.FixedDialog)
let messageBox = new TextBox(Text = "Type your text", Dock = DockStyle.Bottom, Left = 50, Width = 400)
let messageSpace = new Label(Top = 20, Left = 20, Height = chatForm.Height - 100, Width = chatForm.Width - 30)

chatForm.Controls.AddRange [| messageSpace; messageBox|]
chatForm.Show()

messageBox.KeyDown.Add (fun f -> if f.KeyCode = Keys.Enter then
                                    let s = messageBox.Text
                                    let r = new Request(s, myUser, myBot)
                                    let res = myBot.Chat(r)
                                    messageSpace.Text <- messageSpace.Text + "\nYou: " + s + "\nBot: " + res.Output.ToString() 
                                    messageBox.Text <- ""
                                 )

Application.Run()
